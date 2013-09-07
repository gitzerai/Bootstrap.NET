using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;

namespace Bootstrap.NET.HTML
{
    internal class HtmlElement
    {
        public bool IsRendered { get; private set; }
        public string Name { get; private set; }

        private List<HtmlAttribute> _attributes;
        public List<HtmlAttribute> Attributes
        {
            get
            {
                if (_attributes == null)
                    _attributes = new List<HtmlAttribute>();

                return _attributes;
            }
        }

        private List<HtmlElement> _elements;
        public List<HtmlElement> Elements
        {
            get
            {
                if (_elements == null)
                    _elements = new List<HtmlElement>();

                return _elements;
            }
        }

        private List<Control> _controls;
        public List<Control> Controls
        {
            get
            {
                if (_controls == null)
                    _controls = new List<Control>();

                return _controls;
            }
        }

        public HtmlElement(HtmlTextWriterTag type = HtmlTextWriterTag.Div)
            : this(string.Format("{0}", type)) { }

        public HtmlElement(HtmlTextWriterTag type = HtmlTextWriterTag.Div, string className = "", string id = "", string content = null, HtmlElement[] elements = null, HtmlAttribute[] attributes = null, bool isRendered = true, Control[] controls = null)
            : this(string.Format("{0}", type), className, id, content, elements, attributes, isRendered, controls) { }

        public HtmlElement(string name, string className = "", string id = "", string content = "", HtmlElement[] elements = null, HtmlAttribute[] attributes = null, bool isRendered = true, Control[] controls = null)
        {
            this.Name = name;
            this.IsRendered = isRendered;

            if (!string.IsNullOrWhiteSpace(className))
                this.Attributes.Add(new HtmlClassAttribute(className));

            if (!string.IsNullOrWhiteSpace(id))
                this.Attributes.Add(new HtmlIdAttribute(id));

            if (elements != null && elements.Length > 0)
                this.Elements.AddRange(elements);

            if (attributes != null && attributes.Length > 0)
                this.Attributes.AddRange(attributes);

            if (content != null)
                this.Controls.Add(new LiteralControl(content));

            if (controls != null && controls.Length > 0)
                this.Controls.AddRange(controls);

        }
    }

    internal class HtmlCaretElement : HtmlElement
    {
        public HtmlCaretElement(bool isRendered = true)
            : base(type: HtmlTextWriterTag.Button, content: "<span class='caret'></span>", isRendered: isRendered)
        {
        }
    }

    internal class HtmlAddonElement
    {
        public static void Render(HtmlTextWriter writer, string addon, bool renderEndTag = true)
        {
            writer.WriteHtmlElement(new HtmlElement(
                        attributes: new HtmlAttribute[] { 
                        new HtmlClassAttribute("input-group")
                    },
                        elements: new HtmlElement[] {
                        new HtmlElement(
                            type: HtmlTextWriterTag.Span,
                            attributes: new HtmlAttribute[] {
                                new HtmlClassAttribute("input-group-addon")
                            },
                            content: addon
                        )
                    }
              ), renderEndTag);
        }
    }
}
