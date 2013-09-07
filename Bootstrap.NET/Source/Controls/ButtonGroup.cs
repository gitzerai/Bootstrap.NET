using Bootstrap.NET.Helpers;
using Bootstrap.NET.HTML;
using System.Collections.Generic;
using System.ComponentModel;
using System.Web.UI;

namespace Bootstrap.NET.Controls
{
    [ToolboxData("<{0}:ButtonGroup runat=server></ButtonGroup>")]
    [ParseChildren(true)]
    public class ButtonGroup : Control, INamingContainer
    {
        private List<Button> _buttons;
        private ButtonGroupDirection _direction = ButtonGroupDirection.Horizontal;
        private ButtonGroupSize _size = ButtonGroupSize.Default;
        private bool _isStretched = false;

        [Bindable(true)]        
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public List<Button> Buttons
        {
            get { this.EnsureChildControls(); return _buttons; }
            set { this.EnsureChildControls(); _buttons = value; }
        }

        [Bindable(true)]
        public ButtonGroupDirection Direction
        {
            get { return _direction; }
            set { _direction = value; }
        }

        [Bindable(true)]
        public ButtonGroupSize Size
        {
            get { return _size; }
            set { _size = value; }
        }

        [Bindable(true)]
        public bool IsStretched
        {
            get { return _isStretched; }
            set { _isStretched = value; }
        }

        protected override void Render(HtmlTextWriter writer)
        {
            string stretchedClass = (IsStretched) ? "btn-group-justified" : string.Empty;

            writer.WriteHtmlElement(new HtmlElement(
                attributes: new HtmlAttribute[]{
                    new HtmlClassAttribute(Direction.ToRender(), Size.ToRender(), stretchedClass)
                },
                controls: Buttons.ToArray()
            ));
        }

        protected override void CreateChildControls()
        {
            base.CreateChildControls();
            Buttons = new List<Button>();

            foreach (Button btn in Buttons)
                this.Controls.Add(btn);
        }
    }
}
