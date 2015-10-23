<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Error.aspx.cs" Inherits="DemoRD.Error" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <br />
    <br />
    <div class="panel panel-danger col-xs-10 col-xs-offset-1">
        <div class="panel-body">

            <h3>There was an application problem</h3>
            <br />
            <div>
                <asp:Label runat="server" ID="errorLabel"></asp:Label>
            </div>

            <br />
            <br />

        </div>
        <div class="panel-body">
            <a href="Default.aspx" runat="server" class="btn btn-primary" role="button">OK</a>
            <br />
            <br />
        </div>

    </div>
    <br />
    <br />

    <div>
    </div>

</asp:Content>
