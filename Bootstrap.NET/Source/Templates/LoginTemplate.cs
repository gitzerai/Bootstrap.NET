using Bootstrap.NET.Controls;
using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Bootstrap.NET.Templates
{    
    internal class LoginTemplate : ITemplate
    {
        public Bootstrap.NET.Controls.Button LoginButton;
        public Input UsernameBox;
        public Input PasswordBox;

        public LoginTemplate
            (string usernameTitle, string usernamePlaceholder, string passwordTitle, string passwordPlaceholder,
            ButtonStyle loginButtonStyle, IconType loginButtonIcon, string loginButtonText)
        {
            LoginButton = new Bootstrap.NET.Controls.Button();            

            UsernameBox = new Input();
            UsernameBox.Label = usernameTitle;
            UsernameBox.Placeholder = usernamePlaceholder;            
            UsernameBox.IsRequired = true;
            UsernameBox.ValidationGroup = "login-validation-group";

            PasswordBox = new Input();
            PasswordBox.Label = passwordTitle;
            PasswordBox.Placeholder = passwordPlaceholder;
            PasswordBox.IsRequired = true;
            PasswordBox.ValidationGroup = "login-validation-group";
            PasswordBox.TextMode = TextBoxMode.Password;

            Icon icon = new Icon();
            icon.IconType = loginButtonIcon;

            LoginButton.Text = loginButtonText;
            LoginButton.Icon = icon;
            LoginButton.CssStyle = loginButtonStyle;
            LoginButton.ValidationGroup = "login-validation-group";
            LoginButton.CausesValidation = true;
        }

        public void InstantiateIn(Control container)
        {   
            container.Controls.Add(UsernameBox);
            container.Controls.Add(PasswordBox);
            container.Controls.Add(LoginButton);
        }
    }
}
