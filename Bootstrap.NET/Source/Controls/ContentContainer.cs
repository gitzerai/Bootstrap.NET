using Bootstrap.NET.Helpers;
using System.ComponentModel;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Bootstrap.NET.Controls
{    
    [ParseChildren(ChildrenAsProperties=true)]
    [ToolboxData("<{0}:ContentContainer></{0}:ContentContainer>")]
    public class ContentContainer : WebControl
    {
        private Control _footerControls;
        private Control _bodyControls;
        private Control _headerControls;

        public Control HeaderControls
        {
            get
            {
                if (_headerControls == null)
                    _headerControls = new Control();

                return _headerControls;
            }
        }

        public Control FooterControls
        {
            get
            {
                if (_footerControls == null)
                    _footerControls = new Control();

                return _footerControls;
            }
        }
        
        public Control BodyControls
        {
            get
            {
                if (_bodyControls == null)
                    _bodyControls = new Control();

                return _bodyControls;
            }
        }

        [PersistenceMode(PersistenceMode.InnerProperty)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [TemplateInstance(TemplateInstance.Single)]
        public ITemplate HeaderContent
        {
            get { return ViewState.GetValue<ITemplate>("HeaderContent", null); }
            set { ViewState["HeaderContent"] = value; }
        }

        [PersistenceMode(PersistenceMode.InnerProperty)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [TemplateInstance(TemplateInstance.Single)]
        public ITemplate BodyContent
        {
            get { return ViewState.GetValue<ITemplate>("BodyContent", null); }
            set { ViewState["BodyContent"] = value; }
        }

        [PersistenceMode(PersistenceMode.InnerProperty)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [TemplateInstance(TemplateInstance.Single)]
        public ITemplate FooterContent
        {
            get { return ViewState.GetValue<ITemplate>("FooterContent", null); }
            set { ViewState["FooterContent"] = value; }
        }

        protected override void CreateChildControls()
        {
            this.Controls.Clear();

            if (this.HeaderContent != null) { this.HeaderContent.InstantiateIn(HeaderControls); }
            if (this.BodyContent != null) { this.BodyContent.InstantiateIn(BodyControls); }
            if (this.FooterContent != null) { this.FooterContent.InstantiateIn(FooterControls); }

            this.Controls.Add(HeaderControls);
            this.Controls.Add(BodyControls);
            this.Controls.Add(FooterControls);

            base.CreateChildControls();
        }

        public void CreateChildren()
        {
            EnsureChildControls();
        }        
    }
}
