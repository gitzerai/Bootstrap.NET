using Bootstrap.NET.HTML;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;

namespace Bootstrap.NET.Controls
{
    [ToolboxData("<{0}:DropdownMenu runat=server></DropdownMenu>")]
    [ParseChildren(true)]
    public class DropdownMenu : Control, INamingContainer
    {
        private List<MenuItem> _items;

        [Bindable(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]        
        public List<MenuItem> Items
        {
            get { this.EnsureChildControls(); return _items; }
            set { this.EnsureChildControls(); _items = value; }
        }

        protected override void Render(HtmlTextWriter writer)
        {
            writer.WriteHtmlElement(new HtmlElement(
                   type: HtmlTextWriterTag.Ul,
                   isRendered: (Items != null) && (Items.Count > 0),
                   attributes: new HtmlAttribute[] {
                        new HtmlClassAttribute("dropdown-menu"),
                        new HtmlAttribute("role", "menu"),
                        new HtmlAttribute("aria-labelledby", string.Format("{0}-{1}", this.UniqueID, "ddm"))
                   },
                   controls: Items.ToArray()
            ));
        }

        protected override void CreateChildControls()
        {
            base.CreateChildControls();

            Items = new List<MenuItem>();
            foreach (MenuItem menuItem in Items)
                this.Controls.Add(menuItem);            
        }
    }
}
