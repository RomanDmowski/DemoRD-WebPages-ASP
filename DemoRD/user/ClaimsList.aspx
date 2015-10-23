<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ClaimsList.aspx.cs" Inherits="DemoRD.user.ClaimsList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>




<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <div class="col-md-10 col-md-offset-1">

        <h3>List of claims<span style="position: absolute; right: 0px;">

            <asp:DataPager ID="DataPager1" runat="server" PageSize="10" OnPreRender="DataPager1_PreRender" class="btn" PagedControlID="ListView1">
                <Fields>
                    <asp:NextPreviousPagerField ShowLastPageButton="False" ShowNextPageButton="False" ButtonType="Button" ButtonCssClass="btn btn-xs btn-default" RenderNonBreakingSpacesBetweenControls="false" />
                    <asp:NumericPagerField ButtonType="Button" RenderNonBreakingSpacesBetweenControls="false" NumericButtonCssClass="btn btn-xs btn-default" CurrentPageLabelCssClass="btn disabled" NextPreviousButtonCssClass="btn" />
                    <asp:NextPreviousPagerField ShowFirstPageButton="False" ShowPreviousPageButton="False" ButtonType="Button" ButtonCssClass="btn btn-xs btn-default" RenderNonBreakingSpacesBetweenControls="false" />
                </Fields>
            </asp:DataPager>
        </span></h3>
        <br />



        <asp:ListView ID="ListView1" runat="server" ItemType="DemoRD.DTO.ClaimListItem" DataKeyNames="ClaimNumber" OnDataBound="ListView1_DataBound">



            <LayoutTemplate>
                <br />

                <table class="table" id="tbl1" runat="server">
                    <tr>
                        <th>Date</th>
                        <th>Place</th>
                        <th>Patient</th>
                        <th style="text-align: right">Amount Billed</th>
                        <th style="text-align: right">Your Responsibility</th>
                        <th style="text-align: right">Info</th>
                    </tr>
                    <tr runat="server" id="itemPlaceholder" />
                    <tfoot>
                        <tr>
                            <td></td>
                            <td></td>
                            <td style="text-align: right"><b>Total</b></td>
                            <td style="text-align: right"><b><%=String.Format("{0:C}", TotalAmountBilled) %></b></td>
                            <td style="text-align: right"><b><%=String.Format("{0:C}", TotalYourResponsibility) %><b></td>
                           
                        </tr>
                    </tfoot>
                </table>


            </LayoutTemplate>

            <ItemTemplate>
                <tr>
                    <td><%# Item.DateClaim.ToShortDateString() %></td>
                    <td><%# Item.FacilityName %></td>
                    <td><%# Item.PatientFirstName %> <%# Item.PatientLastName %></td>
                    <td style="text-align: right"><%# String.Format("{0:C}", Item.AmountBilledSum) %></td>
                    <td style="text-align: right"><%# String.Format("{0:C}", Item.PatientResponsibilitySum) %></td>
                    <td style="text-align: right"><a href="ClaimDetails.aspx?c=<%# Item.EncryptedClaimNumber %>">More detail</a>
                    </td>
                </tr>
            </ItemTemplate>
        </asp:ListView>

    </div>



</asp:Content>
