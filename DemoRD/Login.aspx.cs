using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Web.Security;
using DemoRD.Domain;

namespace DemoRD
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Logon_Click(object sender, EventArgs e)
        {
            string _login = UserEmail.Text;
            string _password = UserPass.Text;

            if (Crypto.VerifyPassword(_login, _password))
            {
                FormsAuthentication.RedirectFromLoginPage(_login, Persist.Checked);
            }
            else
            {
                Msg.Text = "Invalid credentials. Please try again.";
            }
        }
    }
}