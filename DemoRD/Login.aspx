<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="DemoRD.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>







<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <br />

    <div class="panel panel-default col-xs-12 col-sm-6 col-md-4 col-xs-offset-0 col-sm-offset-3 col-md-offset-4">

        <br />

        <div class="panel-body">
            <h4>Login to your account</h4>
            <br />
            <label class="small">Email:</label>
            <asp:TextBox ID="UserEmail" runat="server" TextMode="Email" CssClass="form-control" ToolTip="Enter email" />
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1"
                ControlToValidate="UserEmail"
                Display="None"
                ErrorMessage="Cannot be empty."
                runat="server" />
        </div>

        <div class="panel-body">
            <label class="small">Password:</label>
            <asp:TextBox ID="UserPass" TextMode="Password" CssClass="form-control" runat="server" />
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2"
                ControlToValidate="UserPass"
                ErrorMessage="Field 'Password' cannot be empty."
                runat="server" Display="None" />
        </div>



        <div class="panel-body">
            <p>
                <asp:CheckBox ID="Persist" runat="server" CssClass="checkbox-inline small" Text=" Remember me" />

            </p>
            <asp:Button ID="Submit1" OnClick="Logon_Click" Text="Log On" runat="server" CssClass="btn" />
        </div>
        <div class="panel-body">
            <asp:Label ID="Msg" ForeColor="red" runat="server" />
        </div>
    </div>




</asp:Content>
