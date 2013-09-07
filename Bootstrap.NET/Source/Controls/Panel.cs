using Bootstrap.NET.Helpers;
using Bootstrap.NET.HTML;
using System.ComponentModel;
using System.Web.UI;

namespace Bootstrap.NET.Controls
{
    [ParseChildren(true)]
    [ToolboxData("<{0}:Panel runat=server></{0}:Panel>")]
    public class Panel : Control, INamingContainer
    {
        private Control _footerControls;
        private Control _bodyControls;
        private Control _headerControls;

        private ITemplate _bodyTemplate;
        private ITemplate _footerTemplate;
        private ITemplate _headerTemplate;

        private bool? _showFooter;

        private string _cssClass = "";
        private PanelStyle _panelStyle = PanelStyle.Default;

        [Bindable(true), Category("Apperance"), DefaultValue("")]
        public string CssClass
        {
            get { return _cssClass; }
            set { _cssClass = value; }
        }

        [Bindable(true), Category("Apperance"), DefaultValue(PanelStyle.Default)]
        public PanelStyle CssStyle
        {
            get { return _panelStyle; }
            set { _panelStyle = value; }
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

        [PersistenceMode(PersistenceMode.InnerProperty)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [TemplateInstance(TemplateInstance.Single)]        
        public ITemplate HeaderTemplate
        {
            get { return _headerTemplate; }
            set { _headerTemplate = value; }
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

        public Control HeaderControls
        {
            get
            {
                if (_headerControls == null)
                    _headerControls = new Control();

                return _headerControls;
            }
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

        protected override void Render(HtmlTextWriter writer)
        {
            this.EnsureChildControls();

            Control[] headerCtrls = new Control[this.HeaderControls.Controls.Count];
            this.HeaderControls.Controls.CopyTo(headerCtrls, 0);

            Control[] bodyCtrls = new Control[this.BodyControls.Controls.Count];
            this.BodyControls.Controls.CopyTo(bodyCtrls, 0);

            Control[] footerCtrls = new Control[this.FooterControls.Controls.Count];
            this.FooterControls.Controls.CopyTo(footerCtrls, 0);

            writer.WriteHtmlElement(new HtmlElement(
                    attributes: new HtmlAttribute[] { 
                        new HtmlClassAttribute("panel", CssStyle.ToRender(), CssClass)
                    },
                    elements: new HtmlElement[] { 
                        new HtmlElement(
                            attributes: new HtmlAttribute[] { 
                                new HtmlClassAttribute("panel-heading")
                            },
                            controls: headerCtrls
                        ),
                        new HtmlElement(
                            attributes: new HtmlAttribute[] { 
                                new HtmlClassAttribute("panel-body")
                            },
                            controls: bodyCtrls
                        ),
                        new HtmlElement(
                            isRendered: this.ShowFooter,
                            attributes: new HtmlAttribute[] { 
                                new HtmlClassAttribute("panel-footer")
                            },
                            controls: footerCtrls
                        ),
                    }
                ));
        }

        protected override void CreateChildControls()
        {            
            this.Controls.Clear();

            if (this.HeaderTemplate != null) { this.HeaderTemplate.InstantiateIn(HeaderControls); }
            if (this.BodyTemplate != null) { this.BodyTemplate.InstantiateIn(BodyControls); }
            if (this.FooterTemplate != null) { this.FooterTemplate.InstantiateIn(FooterControls); }

            this.Controls.Add(HeaderControls);
            this.Controls.Add(BodyControls);
            this.Controls.Add(FooterControls);

            base.CreateChildControls();
        }
    }
}
