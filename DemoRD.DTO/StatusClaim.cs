using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DemoRD.DTO
{
    public class StatusClaim
    {
        public long ClaimNumber { get; set; }
        public string Status { get; set; }
        public DateTime DateStatus { get; set; }

    }
}