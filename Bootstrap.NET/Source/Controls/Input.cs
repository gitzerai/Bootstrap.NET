using Bootstrap.NET.HTML;
using Bootstrap.NET.Helpers;
using System.ComponentModel;
using System.Web.UI;
using System.Web.UI.WebControls;
using System;

namespace Bootstrap.NET.Controls
{
    [DefaultProperty("Text")]
    [ParseChildren(false)]
    [ToolboxData("<{0}:LabeledInput runat=server />")]
    public class Input : TextBox
    {
        private string _label = "";
        private string _placeholder = "";
        private string _cssClass = "form-control";
        private bool _isFormGroup = true;
        private string _requiredErrorMessage = "Field is required.";
        private bool _isRequired = false;
        private bool? _showAddon = null;
        private string _addon = "";
        private Position _addonPosition = Position.Left;
        private Bootstrap.NET.TextBoxMode _textMode = TextBoxMode.Singleline;

        private RequiredFieldValidator _requiredFieldValidator;
        public RequiredFieldValidator RequiredFieldValidator
        {
            get { this.EnsureChildControls();  return _requiredFieldValidator; }
            set { _requiredFieldValidator = value; }
        }

        [Bindable(true), Category("Appearance"), DefaultValue(""), Localizable(true)]
        public string Label
        {
            get { return _label; }
            set { _label = value; }
        }

        [Bindable(true), Category("Appearance"), DefaultValue(""), Localizable(true)]
        public bool IsRequired
        {
            get { return _isRequired; }
            set { _isRequired = value; }
        }

        [Bindable(true), Category("Appearance"), DefaultValue(""), Localizable(true)]
        public string RequiredErrorMessage
        {
            get { return _requiredErrorMessage; }
            set { _requiredErrorMessage = value; }
        }

        [Bindable(true), Category("Appearance"), DefaultValue(""), Localizable(true)]
        public string Placeholder
        {
            get { return _placeholder; }
            set { _placeholder = value; }
        }
        
        [Bindable(true), Category("Appearance"), DefaultValue("form-control"), Localizable(true)]
        public override string CssClass
        {
            get { return _cssClass; }
            set { _cssClass = value; }        
        }

        [Bindable(true), Category("Appearance"), DefaultValue(true), Localizable(true)]
        public bool IsFormGroup
        {
            get { return _isFormGroup; }
            set { _isFormGroup = value; }   
        }

        [Bindable(true), Category("Appearance"), DefaultValue(false), Localizable(true)]
        public bool ShowAddon
        {
            get
            {
                if (_showAddon.HasValue)
                    return _showAddon.Value;
                return Addon.IsSet();
            }
            set { _isFormGroup = value; }
        }

        [Bindable(true), Category("Content"), DefaultValue(""), Localizable(true)]
        public string Addon
        {
            get { return _addon; }
            set { _addon = value; }
        }

        [Bindable(true), Category("Appearance"), DefaultValue(Position.Left), Localizable(true)]
        public Position AddonPosition
        {
            get { return _addonPosition; }
            set { _addonPosition = value; }
        }

        [Bindable(true), Category("Appearance"), DefaultValue(Position.Left), Localizable(true)]
        public new Bootstrap.NET.TextBoxMode TextMode
        {
            get { return _textMode; }
            set { _textMode = value; }
        }

        protected override void OnInit(EventArgs e)
        {
            if (Page != null)
                Page.RegisterRequiresPostBack(this);
            
            base.OnInit(e);
            EnsureChildControls();
        }
                        
        protected override void Render(HtmlTextWriter writer)
        {
            if (IsFormGroup)
                writer.WriteHtmlElement(new HtmlElement(
                    attributes: new HtmlAttribute[] { 
                        new HtmlClassAttribute("form-group")
                    }
                ), false);

            writer.WriteHtmlElement(new HtmlElement(
                isRendered: this.Label.IsSet(),
                type: HtmlTextWriterTag.Label,
                attributes: new HtmlAttribute[] { 
                        new HtmlAttribute("for", this.ClientID)
                    },
                content: this.Label                
            ));

            if (ShowAddon)
            {
                if (AddonPosition == Position.Left)
                    HtmlAddonElement.Render(writer, this.Addon, false);
                else
                     writer.WriteHtmlElement(new HtmlElement(
                        attributes: new HtmlAttribute[] { 
                            new HtmlClassAttribute("input-group")
                        }), false);
            }

            if (TextMode != TextBoxMode.Multiline)
                writer.WriteHtmlElement(new HtmlElement(
                    type: HtmlTextWriterTag.Input,
                    attributes: new HtmlAttribute[] { 
                        new HtmlIdAttribute(this.ClientID),
                        new HtmlClassAttribute(this.CssClass),
                        new HtmlNameAttribute(this.UniqueID),
                        new HtmlAttribute("placeholder", this.Placeholder),
                        new HtmlAttribute("type", this.TextMode.ToRender()),
                        new HtmlAttribute("value", this.Text)
                }
                ));
            else
            {
                writer.WriteHtmlElement(new HtmlElement(
                    type: HtmlTextWriterTag.Textarea,
                    attributes: new HtmlAttribute[] { 
                        new HtmlIdAttribute(this.ClientID),
                        new HtmlClassAttribute(this.CssClass),
                        new HtmlNameAttribute(this.UniqueID),
                        new HtmlAttribute("placeholder", this.Placeholder),
                        new HtmlAttribute("value", this.Text)
                }
                ));
            }

            if (ShowAddon && AddonPosition == Position.Right)
                writer.WriteHtmlElement(new HtmlElement(
                        type: HtmlTextWriterTag.Span,
                        attributes: new HtmlAttribute[] { 
                            new HtmlClassAttribute("input-group-addon")
                        },
                        content: this.Addon)
                );

            if (ShowAddon)
                writer.RenderEndTag();

            if (IsRequired)
                RequiredFieldValidator.RenderControl(writer);
            
            if (IsFormGroup)
                writer.RenderEndTag();
        }

        protected override void CreateChildControls()
        {
            this.EnsureID();
            base.CreateChildControls();   
            CreateRequiredValidator();                     
        }
        
        private void CreateRequiredValidator()
        {
            if (!IsRequired)
                return;

            RequiredFieldValidator = new RequiredFieldValidator();

            this.Controls.Add(RequiredFieldValidator);

            RequiredFieldValidator.ID = string.Format("{0}{1}", this.ID, "-rfv");
            RequiredFieldValidator.ControlToValidate = this.ID;
            RequiredFieldValidator.ErrorMessage = this.RequiredErrorMessage;
            RequiredFieldValidator.EnableClientScript = true;
            RequiredFieldValidator.EnableViewState = true;
            RequiredFieldValidator.ValidationGroup = this.ValidationGroup;
            RequiredFieldValidator.Text = this.RequiredErrorMessage;
            RequiredFieldValidator.Display = ValidatorDisplay.Dynamic;            
        }
    }    
}
