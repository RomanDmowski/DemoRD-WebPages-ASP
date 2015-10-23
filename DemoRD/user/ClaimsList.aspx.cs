using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

//using DemoRD.DB;
using DemoRD.DTO;

using DemoRD.Domain;

namespace DemoRD.user
{
    public partial class ClaimsList : System.Web.UI.Page
    {
        
        public decimal TotalAmountBilled { get; set; }
        public decimal TotalYourResponsibility { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void DataPager1_PreRender(object sender, EventArgs e)
        {


            string _userName = HttpContext.Current.User.Identity.Name;

            //==============================================================
            //hardcoded for demo only:

            _userName = "j.smith@mail.com";
            //==============================================================


            var claims = ClaimsData.GetListClaimsFinal(_userName); 
            calculateTotal(claims);



            ListView1.DataSource = claims;
            ListView1.DataBind();
        }

        protected void ListView1_DataBound(object sender, EventArgs e)
        {
            DataPager1.Visible = (DataPager1.PageSize < DataPager1.TotalRowCount);
        }

        private void calculateTotal(List<ClaimListItem> _claimsList)
        {
            decimal _amount = 0;
            decimal _resposibility = 0;


            foreach (var item in _claimsList)
            {
                _amount += (decimal)item.AmountBilledSum;
                _resposibility += (decimal)item.PatientResponsibilitySum;
            }

            TotalAmountBilled = _amount;
            TotalYourResponsibility = _resposibility;
        }
    }
    }
