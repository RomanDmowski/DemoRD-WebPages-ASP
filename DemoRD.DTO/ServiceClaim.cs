using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DemoRD.DTO
{
    public class ServiceClaim
    {
        public long ClaimNumber { get; set; }
        public string DetailsText { get; set; }
        public DateTime DateVisited { get; set; }
        public decimal AmountBilled { get; set; }
        public decimal PlanPaid { get; set; }
        public decimal PlanDiscount { get; set; }
        public decimal PatientResponsibility { get; set; }

    }
}