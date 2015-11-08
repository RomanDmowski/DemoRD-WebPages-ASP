using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace DemoRD.WebServices
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class DemoRDWS : IDemoRDWS
    {

        public List<WS_user> GetListUsers()
        {
            return WS_user.ConvertListUserToListWS_user(DemoRD.Domain.UsersData.GetListUsers());
        }
        
    }
}
