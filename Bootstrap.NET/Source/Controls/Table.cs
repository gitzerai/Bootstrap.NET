using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using Bootstrap.NET.Helpers;

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

            this.GridLines = System.Web.UI.WebControls.GridLines.None;

            this.EnsureClass("table");

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
