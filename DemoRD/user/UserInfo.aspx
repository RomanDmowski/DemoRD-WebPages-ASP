<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="UserInfo.aspx.cs" Inherits="DemoRD.user.UserInfo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

        <div class="panel panel-default  col-xs-12 col-sm-6 col-md-4 col-xs-offset-0 col-sm-offset-3 col-md-offset-4">
        <br />
        <div class="panel-body">
            <h2>User data</h2>
        </div>
        <div class="panel-body">
            <p>This is the place to show user data</p>
        </div>
        
        <div class="panel-body">
            <asp:Button runat="server" ID="userDataButton"  CssClass="btn" Text="OK" PostBackUrl="~/Default.aspx" />

            <asp:Button runat="server" ID="testButton"  CssClass="btn" Text="Test" OnClick="testButton_Click" />
        </div>
    </div>

</asp:Content>
