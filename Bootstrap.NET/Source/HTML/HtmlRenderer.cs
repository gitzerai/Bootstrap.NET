using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;

namespace Bootstrap.NET.HTML
{
    internal static class HtmlRenderer
    {
        public static void WriteHtmlElement(this HtmlTextWriter output, HtmlTextWriterTag element, string elementContent, params HtmlAttribute[] attributes)
        {
            if (attributes != null && attributes.Length > 0)
            {
                foreach (HtmlAttribute attribute in attributes)
                {
                    output.AddAttribute(attribute.Name, attribute.Value);         
                }
            }
            output.RenderBeginTag(element);
                output.Write(elementContent);
            output.RenderEndTag();
        }

        public static void WriteHtmlElement(this HtmlTextWriter output, HtmlElement element, bool renderEndTag = true)
        {
            if (!element.IsRendered)
                return;

            if (element.Attributes != null && element.Attributes.Count > 0)
            {
                foreach (HtmlAttribute attribute in element.Attributes)
                {
                    if (attribute.IsRendered)
                        output.AddAttribute(attribute.Name, attribute.Value);
                }
            }

            output.RenderBeginTag(element.Name);

            if (element.Elements != null && element.Elements.Count > 0)
            {
                foreach (HtmlElement childElement in element.Elements)
                {
                    if (childElement.IsRendered)
                        output.WriteHtmlElement(childElement);
                }
            }

            if (element.Controls != null && element.Controls.Count > 0)
            {
                foreach (Control control in element.Controls)
                {
                    if (control.Visible)
                        control.RenderControl(output);
                }
            }

            if (renderEndTag)
                output.RenderEndTag();
        }
    }
}
