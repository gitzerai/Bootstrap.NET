using System;

namespace Bootstrap.NET.Events
{
    public class LoginEventArgs : EventArgs
    {
        public string UserName { get; set; }
        public string Password { get; set; }

        public LoginEventArgs(string userName, string password)
            : base()
        {
            this.UserName = userName;
            this.Password = password;
        }
    }
}
