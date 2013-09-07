using Bootstrap.NET.HTML;
using System.Collections.Generic;
using System.ComponentModel;
using System.Web.UI;

namespace Bootstrap.NET.Controls
{
    [ToolboxData("<{0}:ButtonToolbar runat=server></ButtonToolbar>")]
    [ParseChildren(true)]
    public class ButtonToolbar : Control, INamingContainer
    {
        private List<ButtonGroup> _buttonGroups;

        [Bindable(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public List<ButtonGroup> ButtonGroups
        {
            get { this.EnsureChildControls(); return _buttonGroups; }
            set { this.EnsureChildControls(); _buttonGroups = value; }
        }

        protected override void Render(HtmlTextWriter writer)
        {
            writer.WriteHtmlElement(new HtmlElement(
                attributes: new HtmlAttribute[]{
                    new HtmlClassAttribute("btn-toolbar")
                },
                controls: ButtonGroups.ToArray()
            ));
        }

        protected override void CreateChildControls()
        {
            base.CreateChildControls();
            ButtonGroups = new List<ButtonGroup>();

            foreach (ButtonGroup group in ButtonGroups)
                this.Controls.Add(group);
        }
    }
}
