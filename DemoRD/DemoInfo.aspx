<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="DemoInfo.aspx.cs" Inherits="DemoRD.DemoInfo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <br />
    <div class=" col-sm-6 col-md-5  col-sm-offset-2 ">
        <h1>Welcome</h1>

        <p>Please review a sample of my programming skills, which I prepared to assist with your assessment of my skills.</p>
        <p>The sample program addresses the following technical concepts:</p>
        <ul>
            <li>responsive, mobile-friendly web site
            </li>
            <li>C# / ASP.Net Web Forms, Bootstrap framework, CSS, HTML, JavaScript, JQuery
            </li>
            <li>data tier - MS SQL, SQL Stored Procedures, ADO</li>
            <li>Web-Services – WCF (Windows Communication Foundation)</li>
            <li>system components hosted in cloud - MS Azure</li>
            <li>multi-tiered software design approach</li>
            <li>web classic model - Master Page, forms-based authentication, user input validation, paging, printing documents, global exception handling, secure access to database, password hashing, encrypt sections of configuration file, custom login approach to authenticate users without using Membership framework</li>
            <li>version control system - Git</li>     
        </ul>
        
        <p>Additionally, there is a Web-Service demo page <a href="http://demord.azurewebsites.net/DemoWSClient.html" target="_blank">http://demord.azurewebsites.net/DemoWSClient.html</a> prepared to show data exchange between server and client</p>

        
        
        <p>Please sign up and log in to see all features</p>

        <p></p>
        <p><a class="btn btn-success" href="user/ClaimsList.aspx" role="button">OK</a></p>

    </div>
</asp:Content>
