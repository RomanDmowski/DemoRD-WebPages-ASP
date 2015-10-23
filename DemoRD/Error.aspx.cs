using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DemoRD
{
    public partial class Error : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Exception ex = Server.GetLastError();
            Exception innerEx = ex.InnerException;

            if (innerEx !=null)
            {
                errorLabel.Text = "Technical description: " + innerEx.Message;
            }
            else if (ex != null)
            {
                errorLabel.Text = "Technical description: " + ex.Message;
            }
            else
            {
                errorLabel.Text = "Something went wrong...";
            }
            Server.ClearError();
        }
    }
}