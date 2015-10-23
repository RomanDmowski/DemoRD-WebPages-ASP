<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="DemoRD.Register" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <br />

    <div class="panel panel-default  col-xs-12 col-sm-6 col-md-4 col-xs-offset-0 col-sm-offset-3 col-md-offset-4">
        <br />
        <div class="panel-body">

            <asp:Literal ID="Literal1" runat="server" />
            
            <h4>Create your account</h4>
            <br />

            
            

            <label class="small">First Name</label>
            <asp:TextBox ID="firstNameTextBox" runat="server" CssClass="form-control"></asp:TextBox>

            <asp:RequiredFieldValidator ID="RequiredFieldValidatorFirstName" runat="server"
                ErrorMessage="First Name"
                ControlToValidate="firstNameTextBox" Display="None"
                EnableClientScript="False">
            </asp:RequiredFieldValidator>

        </div>

        <div class="panel-body">
            <label class="small">Last Name</label>
            <asp:TextBox ID="lastNameTextBox" runat="server" CssClass="form-control"></asp:TextBox>

            <asp:RequiredFieldValidator ID="RequiredFieldValidatorLastName" runat="server"
                ErrorMessage="Last Name"
                ControlToValidate="lastNameTextBox" Display="None"
                EnableClientScript="False">
            </asp:RequiredFieldValidator>

        </div>


        <div class="panel-body">
            <label class="small">Email - Login</label>
            <asp:TextBox ID="email2TextBox" runat="server" CssClass="form-control"></asp:TextBox>


            <asp:RequiredFieldValidator ID="RequiredFieldValidatorEmail" runat="server"
                ErrorMessage="Email"
                ControlToValidate="email2TextBox" Display="None"
                EnableClientScript="False">
            </asp:RequiredFieldValidator>

            <asp:RegularExpressionValidator ID="RegularExpressionValidatorEmail" runat="server"
                ErrorMessage="Please type valid address Email" 
                ControlToValidate="email2TextBox" Display="None" 
                ValidationExpression="^[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,}$"
                EnableClientScript="False" />

        </div>


        <div class="panel-body">
            <label class="small">Password</label>
            <asp:TextBox ID="password2TextBox" runat="server" CssClass="form-control" TextMode="Password"></asp:TextBox>
            <span class="help-block">Use at least: one upper case letter, one lower case letter, one numeral and eight characters.</span>


            <asp:RequiredFieldValidator ID="RequiredFieldValidatorPassword" runat="server"
                ErrorMessage="Password"
                ControlToValidate="password2TextBox" Display="None"
                EnableClientScript="False">
            </asp:RequiredFieldValidator>


            <asp:RegularExpressionValidator ID="RegularExpressionValidatorPassword" runat="server"
                ErrorMessage="Please enter Password in correct format" 
                ControlToValidate="password2TextBox" Display="None" 
                ValidationExpression="^(?=.*\d)(?=.*[a-z])(?=.*[A-Z]).{8,40}$"
                EnableClientScript="False" />

            <%-- Password matching expression. 
                Password must be at least 8 characters, no more than 40 characters, 
                and must include at least one upper case letter, one lower case letter, 
                and one numeric digit --%>

        </div>

        <div class="panel-body">
            <asp:Button runat="server" ID="registryButton" OnClick="registryButton_Click" CssClass="btn" Text="Registry" />
        </div>
    </div>



</asp:Content>
