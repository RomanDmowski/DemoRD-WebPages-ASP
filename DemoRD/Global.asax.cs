﻿using System;
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



        //protected void Application_BeginRequest(object sender, EventArgs e)
        //{
        //    HttpContext.Current.Response.AddHeader("Access-Control-Allow-Origin",  "*");
        //    if (HttpContext.Current.Request.HttpMethod == "OPTIONS")
        //    {
        //        //These headers are handling the "pre-flight" OPTIONS call sent by the browser
        //        HttpContext.Current.Response.AddHeader("Access-Control-Allow-Methods", "GET, POST");
        //        HttpContext.Current.Response.AddHeader("Access-Control-Allow-Headers", "Content-Type, Accept");
        //        HttpContext.Current.Response.AddHeader("Access-Control-Max-Age", "1728000");
        //        HttpContext.Current.Response.End();
        //    }
        //}




























        void Application_Error(object sender, EventArgs e)
        {


            Server.Transfer("~/Error.aspx");
           //Context.RewritePath("~/Error.aspx");


        }
    }
}