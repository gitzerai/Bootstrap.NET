using Bootstrap.NET.Helpers;
using Bootstrap.NET.HTML;
using System.ComponentModel;
using System.Web.UI;

namespace Bootstrap.NET.Controls
{
    [ToolboxData("<{0}:MenuItem runat=server></MenuItem>")]
    [ParseChildren(true)]
    public class MenuItem : Control, INamingContainer
    {
        private string _text;
        private string _navigateUrl = "#";
        private bool _isEnabled = true;
        private MenuItemType _type = MenuItemType.Link;

        [Bindable(true)]
        public string Text
        {
            get { return _text; }
            set { _text = value; }
        }

        [Bindable(true)]
        public string NavigateUrl
        {
            get { return _navigateUrl; }
            set { _navigateUrl = value;  }
        }

        [Bindable(true)]
        public MenuItemType Type
        {
            get { return _type; } 
            set { _type = value; }
        }

        [Bindable(true)]
        public bool IsEnabled
        {
            get { return _isEnabled; }
            set { _isEnabled = value; }
        }

        protected override void Render(HtmlTextWriter writer)
        {
            string disabledClass = IsEnabled ? "" : "disabled";

            writer.WriteHtmlElement(new HtmlElement(
                type: HtmlTextWriterTag.Li,
                attributes: new HtmlAttribute[] {
                    new HtmlClassAttribute(Type.ToRender(), disabledClass),
                    new HtmlAttribute("role", "presentation")
                },
                elements: new HtmlElement[] {
                    new HtmlElement(
                        isRendered: Type == MenuItemType.Link,
                        type: HtmlTextWriterTag.A,
                        attributes: new HtmlAttribute[] {
                            new HtmlHrefAttribute(NavigateUrl),
                            new HtmlAttribute("role", "menuitem"),
                            new HtmlAttribute("tabindex", "-1")
                        },
                        content: this.Text
                    )                    
                },
                content: (Type == MenuItemType.Header) ? this.Text : string.Empty
            ));
        }
    }
}
