using System;
using System.Collections.Generic;
using System.Web;


using DemoRD.DTO;
using DemoRD.Domain;

namespace DemoRD.user
{
    public partial class ClaimDetails : System.Web.UI.Page
    {
        public ClaimListItem claim { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {

            string _queryString = Request.QueryString["c"];
            if (_queryString != null)
            {
                string _userName = HttpContext.Current.User.Identity.Name;


                //==============================================================
                //hardcoded for demo only:

                _userName = "j.smith@mail.com";
                //==============================================================


                claim = ClaimsData.GetClaimsDetail(_queryString, _userName);
                calculateTotal();
            }
            else
            {
                throw new Exception("There was a problem with a system. There was no Claim number.");
            }
        }


        public List<ServiceClaim> GetServiceList()
        {
            //to.do: protect against empty, null claim
            //---------------------------------------

            List<ServiceClaim> _listServices = new List<ServiceClaim>();
            _listServices = claim.ServicesClaimList;
            return _listServices;
        }

        public List<StatusClaim> GetStatusList()
        {
            //to.do: protect against empty, null claim
            //---------------------------------------

            List<StatusClaim> _listStatuses = new List<StatusClaim>();
            _listStatuses = claim.StatusesClaimList;
            return _listStatuses;
        }

        private void calculateTotal()
        {
            decimal _discount = 0;
            decimal _planPaid = 0;
            decimal _amount = 0;
            decimal _responsibility = 0;

            foreach (var item in this.claim.ServicesClaimList)
            {
                _discount += item.PlanDiscount;
                _planPaid += item.PlanPaid;
                _amount += item.AmountBilled;
                _responsibility += item.PatientResponsibility;
            }

            claim.AmountBilledSum = _amount;
            claim.PatientResponsibilitySum = _responsibility;
            claim.PlanDiscountSum = _discount;
            claim.PlanPaidSum = _planPaid;


        }
    }
}