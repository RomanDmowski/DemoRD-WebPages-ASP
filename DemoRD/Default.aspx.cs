using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Web.Security;
using System.Web.ModelBinding;


namespace DemoRD
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Session["FirstName"] = firstName;

            //if (!Page.IsPostBack)
            //{
                
            //}

            String s = Request.QueryString["x"];
            if (s == "1")
            {
                // it means logout
                FormsAuthentication.SignOut();
                Response.Redirect("default.aspx");
                //Response.Redirect("WebForm2.aspx");

            }
        }
    }
}