using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace DemoRD.WebServices
{
    [ServiceContract(Namespace = "http://Microsoft.ServiceModel.Samples")]
    public interface IDemoRDWS
    {
        [OperationContract]
        List<WS_user> GetListUsers();
    }
}
