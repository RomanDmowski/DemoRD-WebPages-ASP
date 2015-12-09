using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using DemoRD.DTO;

using DemoRD.Entity;

namespace DemoRD.Domain
{
    public class UsersData
    {
        public static List<DemoRD.DTO.User> GetListUsers()
        {
            return RepositoryEF.getListUser();
        }

        public static bool UpdateUser(string login, string firstName, string lastName)
        {
            return RepositoryEF.updateUser(login, firstName, lastName);
        }
    }
}