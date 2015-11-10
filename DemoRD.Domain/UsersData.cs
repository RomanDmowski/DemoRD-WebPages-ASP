using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using DemoRD.DTO;
using DemoRD.DB;

namespace DemoRD.Domain
{
    public class UsersData
    {
        public static List<User> GetListUsers()
        {
            return RepositoryDB.getListUser();
        }

        public static bool UpdateUser(string login, string firstName, string lastName)
        {
            return RepositoryDB.updateUser(login, firstName, lastName);
        }
    }
}