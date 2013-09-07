using Bootstrap.NET.Events;
using Bootstrap.NET.Templates;
using System;
using System.Collections;
using System.ComponentModel;
using System.Web.UI;

namespace Bootstrap.NET.Controls
{
    [ParseChildren(false)]    
    [ToolboxData("<{0}:Login runat=server></{0}:Login>")]
    public class Login : Modal
    {
        #region Fields

        private static readonly object EventIdentifier = new object();
        private IEnumerable _providers;
        private ButtonStyle _loginButtonStyle = ButtonStyle.Success;
        private string _usernameTitle = "User Name";
        private string _usernamePlaceholder = "User name";
        private string _passwordTitle = "Password";
        private string _passwordPlaceholder = "Password";
        private string _loginButtonText = "Login";
        private bool? _showProviders = null;
        private IconType _loginButtonIcon = IconType.Login;

        #endregion

        #region Properties
        
        [Bindable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [TemplateInstance(TemplateInstance.Single)]
        public IEnumerable Providers
        {
            get { return _providers; }
            set { _providers = value; }
        }

        [Bindable(true)]
        public ButtonStyle LoginButtonStyle { get { return _loginButtonStyle; } set { _loginButtonStyle = value; } }

        [Bindable(true)]
        public IconType LoginButtonIcon { get { return _loginButtonIcon; } set { _loginButtonIcon = value; } }

        [Bindable(true), Localizable(true)]
        public string UsernameTitle { get { return _usernameTitle; } set { _usernameTitle = value; } }

        [Bindable(true), Localizable(true)]
        public string UsernamePlaceholder { get { return _usernamePlaceholder; } set { _usernamePlaceholder = value; } }

        [Bindable(true), Localizable(true)]
        public string PasswordTitle { get { return _passwordTitle; } set { _passwordTitle = value; } }

        [Bindable(true), Localizable(true)]
        public string PasswordPlaceholder { get { return _passwordPlaceholder; } set { _passwordPlaceholder = value; } }

        [Bindable(true), Localizable(true)]
        public string LoginButtonText { get { return _loginButtonText; } set { _loginButtonText = value; } }

        [Bindable(true), Localizable(true)]
        public bool ShowProviders
        {
            get
            {
                if (_showProviders.HasValue)
                    return _showProviders.Value;

                return (Providers != null);
            }
            set
            {
                _showProviders = value;
            }
        }        

        #endregion

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            this.Title = "Login";
            this.ToggleButtonTitle = "Login";
        }

        protected override void CreateChildControls()
        {            
            this.ToggleButtonStyle = ButtonStyle.Link;

            this.Controls.Clear();

            if (BodyTemplate == null)
            {
                BodyTemplate = new LoginTemplate(UsernameTitle, UsernamePlaceholder, PasswordTitle, PasswordPlaceholder, LoginButtonStyle, LoginButtonIcon, LoginButtonText);
                ((LoginTemplate)BodyTemplate).LoginButton.Click += onClick;   
            }
    
            base.CreateChildControls();            
        }

        public event LoginEventHandler UserLogin
        {
            add { Events.AddHandler(EventIdentifier, value); }
            remove { Events.RemoveHandler(EventIdentifier, value); }
        }

        public delegate void LoginEventHandler(object sender, LoginEventArgs arg);

        private void onUserLogin(object sender, LoginEventArgs e)
        {
            LoginEventHandler clickEventDelegate = (LoginEventHandler)Events[EventIdentifier];
            if (clickEventDelegate != null)
                clickEventDelegate(this, e);
        }

        private void onClick(object sender, EventArgs e)
        {
            onUserLogin(this, new LoginEventArgs(((LoginTemplate)BodyTemplate).UsernameBox.Text, ((LoginTemplate)BodyTemplate).PasswordBox.Text));
        }
    }
}
