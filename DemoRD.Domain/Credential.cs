using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using DemoRD.Entity;


namespace DemoRD.Domain
{
    public class Credential
    {
        public static int IsLoginInDatabase(string loginToTestDomain)
        {
            return RepositoryEF.IsLoginInDatabaseEF(loginToTestDomain);
        }



    }
}