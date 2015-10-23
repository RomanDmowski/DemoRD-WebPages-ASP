using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace DemoRD
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {



        }

        void Application_Error(object sender, EventArgs e)
        {


            Server.Transfer("~/Error.aspx");
           //Context.RewritePath("~/Error.aspx");


        }
    }
}