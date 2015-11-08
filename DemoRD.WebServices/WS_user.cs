using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DemoRD.DTO;

namespace DemoRD.WebServices
{
    public class WS_user
    {
        public Guid User_ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Login { get; set; } 

        private static WS_user convertUserToWS_user (User _user)
        {
            WS_user _wsUser = new WS_user();

            _wsUser.FirstName = _user.FirstName;
            _wsUser.LastName = _user.LastName;
            _wsUser.Login = _user.Login;
            _wsUser.User_ID = _user.User_ID;

            return _wsUser;
        }


        public static List<WS_user> ConvertListUserToListWS_user (List<User> _listUser)
        {

            List<WS_user> _wsList = new List<WS_user>();

            foreach (User _user in _listUser)
            {
                _wsList.Add(convertUserToWS_user(_user));
            }

            return _wsList;


        }
    }
}
