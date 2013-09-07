using Bootstrap.NET.Helpers;
using Bootstrap.NET.HTML;
using System.ComponentModel;
using System.Web.UI;

namespace Bootstrap.NET.Controls
{
    [ParseChildren(ChildrenAsProperties=true)]
    [ToolboxData("<{0}:Modal runat=server></{0}:Modal>")]
    public class Modal : Control, INamingContainer
    {
        #region Fields
        
        private ITemplate _bodyTemplate;
        private ITemplate _footerTemplate;

        private Control _footerControls;
        private Control _bodyControls;

        private string _title = "Modal Title";
        private ButtonStyle _toggleButtonStyle = ButtonStyle.Default;
        private string _toggleButtonTitle = "Show Modal";
        private ToggleEffect _toggleEffect = ToggleEffect.Fade;
        private string _closeButtonText = "&times;";
        private bool _showCloseButton = true;
        private bool _isModalVisible = false;
        private bool? _showFooter;

        protected bool isBodyTemplateInstantiated = false;
        protected bool isFooterTemplateInstantiated = false;

        #endregion

        #region Properties
        
        [Bindable(true), Category("Appearance"), DefaultValue("Modal Title"), Localizable(true)]
        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }
                
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [TemplateInstance(TemplateInstance.Single)]
        public ITemplate BodyTemplate
        {
            get { return _bodyTemplate; }
            set { _bodyTemplate = value; }
        }

        [PersistenceMode(PersistenceMode.InnerProperty)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [TemplateInstance(TemplateInstance.Single)]
        public ITemplate FooterTemplate
        {
            get { return _footerTemplate; }
            set { _footerTemplate = value; }
        }
        
        public Control FooterControls
        {
            get
            {
                if (_footerControls == null)
                    _footerControls = new Control();

                return _footerControls;
            }
        }
        public Control BodyControls
        {
            get
            {
                if (_bodyControls == null)
                    _bodyControls = new Control();

                return _bodyControls;
            }
        }

        [Bindable(true), Category("Apperance"), DefaultValue(ButtonStyle.Default)]
        public ButtonStyle ToggleButtonStyle
        {
            get { return _toggleButtonStyle; }
            set { _toggleButtonStyle = value; }
        }

        [Bindable(true), Category("Apperance"), DefaultValue("Show Modal"), Localizable(true)]
        public string ToggleButtonTitle
        {
            get { return _toggleButtonTitle; }            
            set { _toggleButtonTitle = value; }
        }

        [Bindable(true), Category("Apperance"), DefaultValue(ToggleEffect.Fade)]
        public ToggleEffect ToggleEffect
        {
            get { return _toggleEffect; }
            set { _toggleEffect = value; }
        }
                
        [Bindable(true), Category("Apperance"), DefaultValue(false)]
        public bool IsModalVisible
        {
            get { return _isModalVisible; }
            set { _isModalVisible = value; }
        }

        [Bindable(true), Category("Apperance"), DefaultValue(true)]
        public bool ShowCloseButton
        {
            get { return _showCloseButton; }
            set { _showCloseButton = value; }
        }
        
        [Bindable(true), Category("Apperance"), DefaultValue("&times;")]
        public string CloseButtonText
        {
            get { return _closeButtonText; }
            set { _closeButtonText = value; }
        }        
        
        [Bindable(true), Category("Footer"), DefaultValue(false)]
        public bool ShowFooter
        {
            get
            {
                if (_showFooter.HasValue)
                    return _showFooter.Value;

                return FooterControls.Controls.Count > 0;
            }
            set { _showFooter = value; }
        }

        #endregion
        
        protected override void Render(HtmlTextWriter writer)
        {            
            this.EnsureChildControls();

            string clientId = string.Format("#{0}", this.ClientID);
            string clientAreaId = string.Format("{0}-label", this.ClientID);
            string isOpenedRender = this.IsModalVisible ? "in" : "";

            Control[] bodyCtrls = new Control[this.BodyControls.Controls.Count];
            this.BodyControls.Controls.CopyTo(bodyCtrls, 0);

            Control[] footerCtrls = new Control[this.FooterControls.Controls.Count];
            this.FooterControls.Controls.CopyTo(footerCtrls, 0);

            // Modal button
            writer.WriteHtmlElement(new HtmlElement(
                type: HtmlTextWriterTag.A,
                content: this.ToggleButtonTitle,
                attributes: new HtmlAttribute[] {
                    new HtmlClassAttribute("btn", this.ToggleButtonStyle.ToRender()),
                    new HtmlHrefAttribute(clientId),
                    new HtmlAttribute("data-toggle", "modal"),
                    new HtmlAttribute("data-show", this.IsModalVisible.ToString().ToLower(), this.IsModalVisible)
                } ));

            // Modal window
            writer.WriteHtmlElement(new HtmlElement(                
                attributes: new HtmlAttribute[] {
                    new HtmlIdAttribute(this.ClientID),
                    new HtmlClassAttribute(string.Format("modal {0} {1}", this.ToggleEffect.ToRender(), isOpenedRender)),
                    new HtmlAttribute("tabindex", "-1"),
                    new HtmlAttribute("role", "dialog"),
                    new HtmlAttribute("aria-labelledby", clientAreaId),
                    new HtmlAttribute("aria-hidden", (!this.IsModalVisible).ToString().ToLower()),                    
                },
                elements: new HtmlElement[] {
                    new HtmlElement(
                        attributes: new HtmlAttribute[] {
                            new HtmlClassAttribute("modal-dialog")
                        },
                        elements: new HtmlElement[] {
                            new HtmlElement(
                                attributes: new HtmlAttribute[] {
                                    new HtmlClassAttribute("modal-content")
                                },
                                elements: new HtmlElement[] {
                                    new HtmlElement(
                                        attributes: new HtmlAttribute[] {
                                            new HtmlClassAttribute("modal-header")
                                        },
                                        elements: new HtmlElement[] {
                                            new HtmlElement(
                                                isRendered: this.ShowCloseButton,
                                                type: HtmlTextWriterTag.Button,                                                                                        
                                                attributes: new HtmlAttribute[] {
                                                    new HtmlClassAttribute("close"),
                                                    new HtmlAttribute("type", "button"),
                                                    new HtmlAttribute("data-dismiss", "modal"),
                                                    new HtmlAttribute("aria-hidden", (!this.IsModalVisible).ToString().ToLower())
                                                },
                                                content: this.CloseButtonText
                                            ),
                                            new HtmlElement(
                                                type: HtmlTextWriterTag.H4,                                                
                                                attributes: new HtmlAttribute[] {
                                                    new HtmlClassAttribute("modal-title"),
                                                    new HtmlIdAttribute(clientAreaId)
                                                },
                                                content: this.Title
                                            )
                                        }
                                    ),
                                    new HtmlElement(
                                        attributes: new HtmlAttribute[] {
                                            new HtmlClassAttribute("modal-body")
                                        },
                                        controls: bodyCtrls
                                    ),
                                    new HtmlElement(
                                        isRendered: this.ShowFooter,
                                        attributes: new HtmlAttribute[] {
                                            new HtmlClassAttribute("modal-footer")
                                        },
                                        controls: footerCtrls
                                    )
                                }
                            )
                        }
                    )                    
                }
            ));
        }

        protected override void CreateChildControls()
        {
            this.Controls.Clear();

            if (this.BodyTemplate != null) {
                this.BodyTemplate.InstantiateIn(BodyControls);
                isBodyTemplateInstantiated = true;
            }
            if (this.FooterTemplate != null) {
                this.FooterTemplate.InstantiateIn(FooterControls);
                isFooterTemplateInstantiated = true;
            }

            this.Controls.Add(BodyControls);
            this.Controls.Add(FooterControls);

            base.CreateChildControls();
        }
    }
}
