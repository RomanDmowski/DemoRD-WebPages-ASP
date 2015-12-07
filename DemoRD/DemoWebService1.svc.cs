using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;

using DemoRD.DTO;
using DemoRD.Domain;


namespace DemoRD
{
    [ServiceContract(Namespace = "")]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class DemoWebService1
    {

        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]


        public List<WS_user> GetUserList()

        {
            
            /*
            List<WS_user> _wsuserList = new List<WS_user>()
                        {       new WS_user {  FirstName="James", LastName="Zet", Login="werr@wer.xc" },
                                new WS_user {  FirstName="Paul", LastName="Alfa", Login="paul.wer@wer.zd" }
                        };

            return _wsuserList;

            */

            return (WS_user.ConvertListUserToListWS_user(UsersData.GetListUsers()));

        }


        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]

        public Boolean UpdateUser(string login, string firstName, string lastName) {

            string _input = login + " " + firstName + " " + lastName;

            return UsersData.UpdateUser(login, firstName, lastName);


        }

    }
}
