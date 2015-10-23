using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using DemoRD.DB;


namespace DemoRD.Domain
{
    public class Credential
    {
        public static int IsLoginInDatabase(string loginToTestDomain)
        {
            return RepositoryDB.IsLoginInDatabaseDB(loginToTestDomain);
        }



    }
}