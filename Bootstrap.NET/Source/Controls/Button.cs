using Bootstrap.NET.Helpers;
using Bootstrap.NET.HTML;
using System.Collections.Generic;
using System.Web.UI;

namespace Bootstrap.NET.Controls
{
    [ToolboxData("<{0}:Button></{0}:Button>")]
    [ParseChildren(true)]
    public class Button : System.Web.UI.WebControls.Button
    {
        private ButtonSize _size = ButtonSize.Default;
        private ButtonStyle _cssStyle = ButtonStyle.Default;
        private Icon _icon;
        private string _cssClass = "btn";
        private bool _isToggleable = false;
        private HtmlTextWriterTag _type = HtmlTextWriterTag.Button;
        private Position _iconPosition = Position.Left;

        public ButtonSize Size
        {
            get { return _size; }
            set { _size = value; }
        }

        public HtmlTextWriterTag Type
        {
            get { return _type; }
            set { _type = value; }
        }

        public Position IconPosition
        {
            get { return _iconPosition; }
            set { _iconPosition = value; }
        }

        public bool IsToggleable
        {
            get { return _isToggleable; }
            set { _isToggleable = value; }
        }

        public ButtonStyle CssStyle
        {
            get { return _cssStyle; }
            set { _cssStyle = value; }
        }

        public override string CssClass
        {
            get { return _cssClass; }
            set { _cssClass = value; }
        }

        [PersistenceMode(PersistenceMode.InnerProperty)]
        public Icon Icon
        {
            get { return _icon; }
            set { _icon = value; }
        }

        protected override void Render(HtmlTextWriter writer)
        {         
            List<Control> iconAndTextControls = new List<Control>();

            if (this.Icon != null && this.IconPosition == Position.Left)
                iconAndTextControls.Add(Icon);

            iconAndTextControls.Add(new LiteralControl(this.Text));

            if (this.Icon != null && this.IconPosition == Position.Right)
                iconAndTextControls.Add(Icon);

            string onClick = "";

            if (Page != null)
            {
                if (CausesValidation || ValidationGroup.IsSet())
                {
                    PostBackOptions options = new PostBackOptions(this);
                    options.ValidationGroup = this.ValidationGroup;
                    options.PerformValidation = true;
                    onClick = Page.ClientScript.GetPostBackEventReference(options, true);
                }
                else
                {
                    onClick = Page.ClientScript.GetPostBackClientHyperlink(this, "");
                }
            }
        
            writer.WriteHtmlElement(new HtmlElement(
                type: Type,
                attributes: new HtmlAttribute[] { 
                    new HtmlClassAttribute(CssClass, Size.ToRender(), CssStyle.ToRender()),
                    new HtmlTypeAttribute("submit"),
                    new HtmlNameAttribute(this.UniqueID),
                    new HtmlAttribute("disabled", "disabled", !IsEnabled),
                    new HtmlAttribute("data-toggle", "button", IsToggleable),
                    new HtmlAttribute("onclick", onClick, !UseSubmitBehavior)
                },
                controls: iconAndTextControls.ToArray()
            ));
        }
    }
}
