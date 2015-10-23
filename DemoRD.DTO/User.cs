using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DemoRD.DTO
{
    public class User
    {
        public Guid User_ID { get; set; }
        public Guid Parent_User_id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Login { get; set; }
        public Byte[] Salt1 { get; set; }
        public Byte[] Salt2 { get; set; }
        public Byte[] Hash { get; set; }

    }
}