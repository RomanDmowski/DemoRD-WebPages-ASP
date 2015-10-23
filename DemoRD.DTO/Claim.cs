using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DemoRD.DTO
{
   
        public class Claim
        {
            public long ClaimNumber { get; set; }
            public Guid User_Id { get; set; }
            public string PatientFirstName { get; set; }
            public string PatientLastName { get; set; }
            public string FacilityName { get; set; }
            public DateTime DateClaim { get; set; }
            public List<ServiceClaim> ServicesClaimList { get; set; }
            public List<StatusClaim> StatusesClaimList { get; set; }
        }

        public class ClaimListItem : Claim
        {
            public string EncryptedClaimNumber { get; set; }

            private decimal? _discount;
            private decimal? _planPaid;
            private decimal? _amount;
            private decimal? _reponsibility;

            public decimal? PlanDiscountSum
            {
                get { return _discount != null ? (decimal)_discount : 0; }
                set { _discount = value; }
            }


            public decimal? PlanPaidSum
            {
                get { return _planPaid != null ? (decimal)_planPaid : 0; }
                set { _planPaid = value; }
            }




            public decimal? AmountBilledSum
            {
                get { return _amount != null ? (decimal)_amount : 0; }
                set { _amount = value; }
            }


            public decimal? PatientResponsibilitySum
            {
                get { return _reponsibility != null ? (decimal)_reponsibility : 0; }
                set { _reponsibility = value; }
            }

            public static ClaimListItem ConvertClaimToClaimListItem(Claim claim)
            {
                ClaimListItem _claimListItem = new ClaimListItem();

                _claimListItem.ClaimNumber = claim.ClaimNumber;
                _claimListItem.DateClaim = claim.DateClaim;
                _claimListItem.FacilityName = claim.FacilityName;
                _claimListItem.PatientFirstName = claim.PatientFirstName;
                _claimListItem.PatientLastName = claim.PatientLastName;
                _claimListItem.ServicesClaimList = claim.ServicesClaimList;
                _claimListItem.StatusesClaimList = claim.StatusesClaimList;
                _claimListItem.User_Id = claim.User_Id;

                return _claimListItem;
            }

        }
    }
