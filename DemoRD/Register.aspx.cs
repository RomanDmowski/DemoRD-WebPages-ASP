using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using DemoRD.Domain;
using System.Web.Security;


namespace DemoRD
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void registryButton_Click(object sender, EventArgs e)
        {

            string _result = "";


            if (!RequiredFieldValidatorFirstName.IsValid || !RequiredFieldValidatorLastName.IsValid || !RequiredFieldValidatorEmail.IsValid)
            {
                _result += "<b>Please Enter:</b> ";
                _result += (RequiredFieldValidatorFirstName.IsValid) ? "" : "<br />" + RequiredFieldValidatorFirstName.ErrorMessage;
                _result += (RequiredFieldValidatorLastName.IsValid) ? "" : "<br />" + RequiredFieldValidatorLastName.ErrorMessage;
                _result += (RequiredFieldValidatorEmail.IsValid) ? "" : "<br />" + RequiredFieldValidatorEmail.ErrorMessage;

                msgBox(_result);
                return;
            }
            else if (!RegularExpressionValidatorEmail.IsValid)
            {
                _result += "Please enter valid Email address";

                msgBox(_result);
                return;
            }
            else if (!RequiredFieldValidatorPassword.IsValid)
            {
                _result += "<b>Please Enter:</b> ";
                _result += "<br />Password";

                msgBox(_result);
                return;

            }
            else if (!RegularExpressionValidatorPassword.IsValid)
            {
                _result += "Please enter Password in correct format.";

                msgBox(_result);
                return;
            }
            else
            {
                Literal1.Text = "";
            }


            //Server.HtmlEncode(
            string firstName = firstNameTextBox.Text.Trim();
            string lastName = lastNameTextBox.Text.Trim();
            string email = email2TextBox.Text.Trim();
            string password = password2TextBox.Text.Trim();





            if (Credential.IsLoginInDatabase(email) > 0)
            {
                //check if user name (email) exist
                _result += "Email - Login exists in a system. Please use a different one.";
                msgBox(_result);

                return;
            }


            if (Crypto.SavePassword(firstName, lastName, email, password))
                //Response.Redirect("~/WebForm2");
                FormsAuthentication.RedirectFromLoginPage(email, false);

        }

        private void msgBox(string _message)
        {
            Literal1.Text = @"<div class=""alert alert-info fade in""><a href = ""#"" class=""close"" data-dismiss=""alert"" aria-label=""close"">&times;</a>" + _message + @".</div>";
        }
    }
}