<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="DemoRD.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <style>
        h1, h2 {
            color: white;
        }

        h1 {
            font-size: 3.5em;
        }

        body {
            /* Location of the image */
            background-image: url(images/family3.jpg);
            /* Background image is centered vertically and horizontally at all times */
            background-position: center center;
            /* Background image doesn't tile */
            background-repeat: no-repeat;
            /* Background image is fixed in the viewport so that it doesn't move when 
     the content's height is greater than the image's height */
            background-attachment: fixed;
            /* This is what makes the background image rescale based
     on the container's size */
            background-size: cover;
            /* Set a background color that will be displayed
     while the background image is loading */
            background-color: #464646;
        }

        ul.b {
            list-style-type: square;
            color: white;
        }

        .panel {
            background-color: rgba(12, 57, 120, 0.10);
            padding: 25px;
        }
    </style>


</asp:Content>



<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

       <br />
    <br />
    <div class="col-sm-5 col-sm-offset-1 panel panel-default">



        <h1>Why choose us ?</h1>
        <h2>The benefits of NY Health.</h2>

        <div>
            <ul class="b">
                <li>Talk to a nurse - 24/7</li>
                <li>Your health plan in your hand</li>
                <li>Store and manage your records digitally</li>
            </ul>
        </div>

        <p>...</p>
        <p><a class="btn btn-primary" href="Info_01.aspx" role="button">Learn more</a></p>
    </div>

</asp:Content>
