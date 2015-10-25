<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="DemoInfo.aspx.cs" Inherits="DemoRD.DemoInfo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <br />
    <div class=" col-sm-6 col-md-5  col-sm-offset-2 ">
        <h1>Welcome</h1>

        <p>Please check out a sample of my programming skills, which I prepared  to assist your assessment if my skills meet your needs. </p>
        <p>The sample programm addresses the following  technical requirements:</p>
        <ul>
            <li>responsive, mobile-friendly web site
            </li>
            <li>system components hosted in cloud - MS Azure
            </li>
            <li>multi-tiered software design approach</li>
            <li>secure access to database, password hashing, encrypt sections of configuration file, custom login approach to authenticate users without using Membership framework</li>
            <li>ASP.Net Web Forms classic model - Master Page, forms-based authentication, user input validation, paging, printing documents, global exception handling</li>
            <li>data tier - MS SQL</li>
            <li>version control system - Git</li>     
        </ul>

        <p>You should sign up and log in to see all features</p>
        <p><a class="btn btn-primary" href="Default.aspx" role="button">OK</a></p>

    </div>
</asp:Content>
