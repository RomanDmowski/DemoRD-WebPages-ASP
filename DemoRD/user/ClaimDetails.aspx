<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ClaimDetails.aspx.cs" Inherits="DemoRD.user.ClaimDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="col-sm-10 col-xs-12 col-sm-offset-1">

         <div class="row small" >
          <div class="col-sm-4 " >
              <p class="visible-print-block">
                  Health NY<br />
                  PO BOX 11111<br />
                  Buffalo NY 14201
              </p> 
          </div>
          <div class="col-sm-4"></div>
          <div class="col-sm-4">
              <p style="text-align: right"><%=DateTime.Now.ToLongDateString() %></p>
          </div>    
             
        </div>

        
        <br />


        <div class="row">
            <div class="col-xs-8 col-sm-9">
                
                
            </div>
            <div class="col-xs-4 col-sm-3 small" style="text-align: right">
                <h5>Claim Detail for <%= claim.PatientFirstName %> <%=claim.PatientLastName %>  </h5>
                <b>Claim Number:</b> <%=claim.ClaimNumber %> 
                <br /> <br />
                <b>Place:</b><br />
                <%=claim.FacilityName %>
              
            </div>
        </div>
     <br />
        <div>
            <asp:ListView runat="server" ID="claimDetailServicesList" ItemType="DemoRD.DTO.ServiceClaim" SelectMethod="GetServiceList">

                <LayoutTemplate>
                    <br />
                    
                  <table class="table"  id="servicesListTable" runat="server">
                    <tr>
                        <th>Service</th>
                        <th style="text-align : right">Amount Billed</th>
                        <th style="text-align : right">Plan Discounts</th>
                        <th style="text-align : right">Your Plan Paid</th>
                        <th style="text-align : right" >Your Responsibility</th>
                        
                    </tr>
                    <tr runat="server" id="itemPlaceholder" />
                      <tfoot>
                        <tr>
                          <td style="text-align : right"><b>Total</b></td>
                          <td style="text-align : right"><b><%=String.Format("{0:C}",claim.AmountBilledSum) %></b></td>
                          <td style="text-align : right"><b><%=String.Format("{0:C}",claim.PlanDiscountSum) %></b></td>
                          <td style="text-align : right"><b><%=String.Format("{0:C}",claim.PlanPaidSum) %></b></td>
                          <td style="text-align : right"><b><%=String.Format("{0:C}",claim.PatientResponsibilitySum) %><b></td>
                        </tr>
                    </tfoot>
                  </table>
                    
                  
                </LayoutTemplate>

                <ItemTemplate>
                  <tr>
                      <td>
                          <%# Item.DetailsText %><br />
                          <%# Item.DateVisited.ToShortDateString() %>
                      </td>
                      
                      <td style="text-align : right" ><%# String.Format("{0:C}", Item.AmountBilled) %></td>
                      <td style="text-align : right" ><%# String.Format("{0:C}", Item.PlanDiscount) %></td>
                      <td style="text-align : right" ><%# String.Format("{0:C}", Item.PlanPaid) %></td>
                      <td style="text-align : right" ><%# String.Format("{0:C}", Item.PatientResponsibility) %></td>
                  </tr>
                </ItemTemplate>

            </asp:ListView>


        </div>
    <br />
    <br />

        <div>
            

            <asp:ListView runat="server" ID="statusListView" ItemType="DemoRD.DTO.StatusClaim" SelectMethod="GetStatusList">

                <LayoutTemplate>
                    
                    <h6>Claim History:</h6>
                    <table>
                        <tr runat="server" id="itemPlaceholder" />
                    </table>



                </LayoutTemplate>
                <ItemTemplate>
                  <tr  class="small">
                      <td style="padding-right: 10px;">
                          <%# Item.DateStatus.ToShortDateString() %>
                      </td>
                      <td >
                              <%# Item.Status %>
                      </td>
                    </tr>
                </ItemTemplate>


            </asp:ListView>

        </div>

    <button id="printButton" type="button" class="btn btn-default pull-right hidden-print" onclick="javascript: window.print();">
      <span class="glyphicon glyphicon-print"></span> Print 
    </button>



</div>

</asp:Content>
