using Bootstrap.NET.HTML;
using Bootstrap.NET.Helpers;
using System.ComponentModel;
using System.Web.UI;
using System;

namespace Bootstrap.NET.Controls
{
    [ParseChildren(true)]
    public class Navbar : Control, INamingContainer
    {
        private static readonly object EventIdentifier = new object();
        private NavbarStyle _cssStyle = NavbarStyle.Default;
        private ITemplate _leftBar;
        private ITemplate _rightBar;
        private Control _leftControls;
        private Control _rightControls;
        private string _brandText = "";
        private NavbarPosition _positon = NavbarPosition.StaticTop;
        private string _brandNavigateUrl = "";
        private bool _showSearch = false;
        private Position _searchBarPosition = Bootstrap.NET.Position.Left;
        private string _searchButtonText = "Search";
        private string _searchPlaceholder = "Search";

        [Bindable(true)]
        public NavbarStyle CssStyle
        {
            get { return _cssStyle; }
            set { _cssStyle = value; }
        }

        [Bindable(true)]
        public NavbarPosition Position
        {
            get { return _positon; }
            set { _positon = value; }
        }

        [PersistenceMode(PersistenceMode.InnerProperty)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [TemplateInstance(TemplateInstance.Single)] 
        public ITemplate LeftBar
        {
            get { return _leftBar; }
            set { _leftBar = value; }
        }

        [Bindable(true)]
        public bool ShowSearch
        {
            get { return _showSearch; }
            set { _showSearch = value; }
        }

        [Bindable(true)]
        public Position SearchBarPosition
        {
            get { return _searchBarPosition; }
            set { _searchBarPosition = value; }
        }

        [PersistenceMode(PersistenceMode.InnerProperty)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [TemplateInstance(TemplateInstance.Single)]
        public ITemplate RightBar
        {
            get { return _rightBar; }
            set { _rightBar = value; }
        }

        [Bindable(true)]
        public string BrandText
        {
            get { return _brandText; }
            set { _brandText = value; }
        }

        [Bindable(true)]
        public string BrandNavigateUrl
        {
            get { return _brandNavigateUrl; }
            set { _brandNavigateUrl = value; }
        }

        [Bindable(true)]
        public string SearchPlaceholder
        {
            get { return _searchPlaceholder; }
            set { _searchPlaceholder = value; }
        }

        [Bindable(true)]
        public string SearchButtonText
        {
            get { return _searchButtonText; }
            set { _searchButtonText = value; }
        }

        private Input searchInput;
        private Button searchButton;

        public Control LeftControls
        {
            get
            {
                if (_leftControls == null)
                    _leftControls = new Control();

                return _leftControls;
            }
        }

        public Control RightControls
        {
            get
            {
                if (_rightControls == null)
                    _rightControls = new Control();

                return _rightControls;
            }
        }

        protected override void Render(HtmlTextWriter writer)
        {
            this.EnsureChildControls();

            Control[] leftCtrls = new Control[this.LeftControls.Controls.Count];
            this.LeftControls.Controls.CopyTo(leftCtrls, 0);

            Control[] rightCtrls = new Control[this.RightControls.Controls.Count];
            this.RightControls.Controls.CopyTo(rightCtrls, 0);

            writer.WriteHtmlElement(new HtmlElement(
                    name: "nav",
                    attributes: new HtmlAttribute[] {
                        new HtmlClassAttribute("navbar", CssStyle.ToRender(), Position.ToRender()),
                        new HtmlAttribute("role", "navigation")
                    },
                    elements: new HtmlElement[] {
                        new HtmlElement(
                            attributes: new HtmlAttribute[] {
                                new HtmlClassAttribute("navbar-header")
                            },
                            elements: new HtmlElement[] {
                                new HtmlElement(
                                    type: HtmlTextWriterTag.A,
                                    attributes: new HtmlAttribute[] {
                                        new HtmlClassAttribute("navbar-brand"),
                                        new HtmlHrefAttribute(this.BrandNavigateUrl),
                                    },
                                    content: this.BrandText
                                )
                            }
                        ),
                        new HtmlElement(
                            attributes: new HtmlAttribute[] {
                                new HtmlClassAttribute("collapse", "navbar-collapse", "navbar-ex1-collapse")
                            },
                            elements: new HtmlElement[] {
                                new HtmlElement(
                                    type: HtmlTextWriterTag.Ul,
                                    attributes: new HtmlAttribute[] {
                                        new HtmlClassAttribute("nav", "navbar-nav")
                                    },
                                    controls: leftCtrls
                                ),
                                new HtmlElement(
                                    isRendered: this.ShowSearch,                            
                                    attributes: new HtmlAttribute[] {
                                        new HtmlClassAttribute("navbar-form", this.SearchBarPosition == Bootstrap.NET.Position.Left ? "navbar-left" : "navbar-right"),
                                        new HtmlAttribute("role", "search")
                                    },
                                    controls: new Control[] {
                                        searchInput,
                                        searchButton
                                    }
                                ),
                                new HtmlElement(
                                    type: HtmlTextWriterTag.Ul,
                                    attributes: new HtmlAttribute[] {
                                        new HtmlClassAttribute("nav", "navbar-nav", "navbar-right")
                                    },
                                    controls: rightCtrls
                                )
                            }
                        )
                    }
                ));
        }

        public event EventHandler Search
        {
            add { Events.AddHandler(EventIdentifier, value); }
            remove { Events.RemoveHandler(EventIdentifier, value); }
        }

        public delegate void EventHandler(object sender, EventArgs arg);

        private void onSearch(object sender, EventArgs e)
        {
            EventHandler clickEventDelegate = (EventHandler)Events[EventIdentifier];
            if (clickEventDelegate != null)
                clickEventDelegate(this, e);
        }

        protected override void CreateChildControls()
        {
            this.Controls.Clear();

            if (this.LeftBar != null) { this.LeftBar.InstantiateIn(LeftControls); }
            if (this.RightBar != null) { this.RightBar.InstantiateIn(RightControls); }

            if (this.ShowSearch)
            {
                searchInput = new Bootstrap.NET.Controls.Input();
                searchInput.Placeholder = this.SearchPlaceholder;

                searchButton = new Bootstrap.NET.Controls.Button();         
                searchButton.Text = this.SearchButtonText;
                searchButton.Click += onSearch;

                this.Controls.Add(searchInput);
                this.Controls.Add(searchButton);
            }

            this.Controls.Add(LeftControls);
            this.Controls.Add(RightControls);

            base.CreateChildControls();
        }
    }
}
