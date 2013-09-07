using Bootstrap.NET.Helpers;
using Bootstrap.NET.HTML;
using System.ComponentModel;
using System.Web.UI;

namespace Bootstrap.NET.Controls
{
    [ToolboxData("<{0}:DropdownButton runat=server></DropdownButton>")]
    [ParseChildren(true)]
    public class DropdownButton : Button
    {
        private const string CARET = "<span class='caret'></span>";

        private bool _hasSeparatedArrow = false;
        private DropdownDirection _direction = DropdownDirection.Down;
        private DropdownMenu _menu;        

        [Bindable(true)]
        public bool HasSeparatedArrow
        {
            get { return _hasSeparatedArrow; }
            set { _hasSeparatedArrow = value; }
        }

        [Bindable(true)]
        public DropdownDirection Direction
        {
            get { return _direction; }
            set { _direction = value; }
        }

        [Bindable(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]        
        public DropdownMenu Menu
        {
            get { this.EnsureChildControls(); return _menu; }
            set { this.EnsureChildControls(); _menu = value; }
        }

        protected override void Render(HtmlTextWriter writer)
        {
            HtmlClassAttribute titleClass =
                HasSeparatedArrow ?
                new HtmlClassAttribute("btn", CssStyle.ToRender(), Size.ToRender()):
                new HtmlClassAttribute("btn", CssStyle.ToRender(), Size.ToRender(), "dropdown-toggle");

            writer.WriteHtmlElement(new HtmlElement(
                attributes: new HtmlAttribute[] {
                    new HtmlClassAttribute("btn-group", Direction.ToRender())
                },
                elements: new HtmlElement[] {
                    new HtmlElement(
                        type: HtmlTextWriterTag.Button,
                        attributes: new HtmlAttribute[] {
                            new HtmlTypeAttribute("button"),
                            titleClass,
                            new HtmlAttribute("data-toggle", "dropdown", !HasSeparatedArrow)
                        },
                        content: this.Text,
                        elements: new HtmlElement[] {
                            new HtmlCaretElement(!HasSeparatedArrow)
                        }
                    ),
                    new HtmlElement(
                        isRendered: HasSeparatedArrow,
                        type: HtmlTextWriterTag.Button,
                        attributes: new HtmlAttribute[] {
                            new HtmlTypeAttribute("button"),
                            new HtmlClassAttribute("btn", CssStyle.ToRender(), "dropdown-toggle"),
                            new HtmlAttribute("data-toggle", "dropdown")
                        },
                        content: CARET
                    )
                },
                controls: new Control[] {
                    Menu
                }
            ));
        }

        protected override void CreateChildControls()
        {
            base.CreateChildControls();

            Menu = new DropdownMenu();

            this.Controls.Add(Menu);
        }
    }
}
