using Bootstrap.NET.Helpers;
using Bootstrap.NET.HTML;
using System.Web.UI;

namespace Bootstrap.NET.Controls
{
    [ToolboxData("<{0}:Icon></{0}:Icon>")]
    public class Icon : Control, INamingContainer
    {
        private IconType _iconType = IconType.None;
        public IconType IconType
        {
            get { return _iconType; }
            set { _iconType = value; }
        }

        protected override void Render(HtmlTextWriter writer)
        {
            if (IconType == IconType.None)
                return;

            writer.WriteHtmlElement(new HtmlElement(
                type: HtmlTextWriterTag.Span,
                attributes: new HtmlAttribute[] { 
                    new HtmlClassAttribute("glyphicon", IconType.ToRender())
                }
            ));

            writer.Write(" ");
        }
    }
}
