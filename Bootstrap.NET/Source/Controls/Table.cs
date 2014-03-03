using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Bootstrap.NET.Controls
{
    [ToolboxData("<{0}:Table runat=server></{0}:Table>")]
    public class Table : GridView
    {
        //TODO: IsStriped, IsResponsive, IsHover

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            this.UseAccessibleHeader = true;            
            if (this.HeaderRow == null)
                return;

            this.CssClass = "table " + this.CssClass;

            this.HeaderRow.TableSection = TableRowSection.TableHeader;
            this.PagerStyle.CssClass = "pagination";            
        }

        protected override void Render(HtmlTextWriter writer)
        {
            base.PrepareControlHierarchy();
            base.RenderContents(writer);
        }
    }
}
