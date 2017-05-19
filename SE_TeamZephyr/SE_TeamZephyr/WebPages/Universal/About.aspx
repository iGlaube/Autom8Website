<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="SE_TeamZephyr.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <%-- Load CSS Styles after Javascript --%>
    <link href="../../Content/PageSpecificStyles/GenericPageStyle.css" rel="stylesheet" />
    <link href="../../Content/PageSpecificStyles/AboutPageStyle.css" rel="stylesheet" />

    <div class="container">

      <%--<center> <img src="../../Content/Images/AboutUs/whoarewe.png" /> </center>--%>
        <h1 align="center" >Who Are We?</h1>
        <p>
            Autom8 is an innovative carpooling application that developed by QUB prodigies that make up Team Zephyr.
            Our website is aimed toward those who seek alternative travel to the standard, with carpooling.
            <br />
           
            <br />
            Autom8 helps businesses and individuals find carpooling partners travelling common routes.
            The more people that get involved, the more we can enjoy an alternative to traffic
             congestion and expensive public transport, while promoting sustainability in your area.
        <br />

        </p>

        <h3 align="center">Select a package to suit your needs: </h3>
        <p>*Stay tuned for the release of our <i>Business Suite</i></p>

        <!--Individual Package-->
        <div class="col-sm-9 col-md-6 col-lg-4">
            <div class="card1">
                <canvas class="header1-bg" width="250" height="70"></canvas>
                <div class="avatar1">
                    <img src="../../Content/Images/AboutUs/basic.png" />
                </div>
                <div class="content">
                    <h5>Our standard Autom8 package comes with everything you'll need to start carpooling with your friends and colleagues. 
                        <br />
                        <br />
                        Here you can host a lift or simply join another Autom8 in theirs.
                        <br>
                    </h5>
                    <br />
                    <br />
                </div>

            </div>
        </div>



        <!--Individual Package-->
        <div class="col-sm-9 col-md-6 col-lg-4">
            <div class="card2">
                <canvas class="header1-bg" width="250" height="70"></canvas>
                <div class="avatar1">
                    <img src="../../Content/Images/AboutUs/premium1.png" />
                </div>
                <div class="content">
                    <h5>Love stats? <br />With our premium version you will be able to track your mileage<br /><br /> carboon footprint and compare
                    yourself against other Autom8 riders.<br />
                        <br />
                    </h5>
                    <h5></h5>
                </div>

            </div>
        </div>


        <%--<div class="row">--%>
        <!--Individual Package-->
        <div class="col-sm-5 col-md-6 col-lg-4">
            <div class="card3">
                <canvas class="header1-bg" width="250" height="70"></canvas>
                <div class="avatar1">
                    <img src="../../Content/Images/AboutUs/business1.png" />
                </div>
                <div class="content">
                    <h5>With our business suite, your employees can sync up with one another and avail of many of our
                    company only features like: 
                    <br />
                    <br />
                    A private business portal, Active Directory integration, on call technical support from our experts and company wide
                    statistical feedback on employee usage.<br>
                    </h5>
                    <h5></h5>
                </div>
            </div>
        </div>
    </div>
    <hr />
    <h2 align="center">Meet The Team</h2>


    <!--Individual Contact Cards-->
    <div class="col-sm-3 col-md-6 col-lg-3">
        <div class="card">
            <div class="avatar">
                <img src="../../Content/Images/AboutUs/brendan.jpg" />
            </div>
            <div class="content">
                <h4><strong><u>Brendan Campbell</u></strong><br>
                </h4>
                <h5>Business Analyst & Developer</h5>
                <p><strong>Email | </strong>bcampbell23@qub.ac.uk</p>
                <p><a class="btn btn-warning" href="mailto:bcampbell23@qub.ac.uk" role="button">Contact</a></p>
            </div>
        </div>
    </div>

    <div class="col-sm-3 col-md-6 col-lg-3">
        <div class="card">
            <div class="avatar">
                <img src="../../Content/Images/AboutUs/Fla.jpg" alt="" />
            </div>
            <div class="content">
                <h4><strong><u>Rory O'Flaherty</u></strong><br>
                </h4>
                <h5>Q.A Engineer & Developer </h5>
                <p><strong>Email | </strong>roflaherty04@qub.ac.uk</p>
                <p><a class="btn btn-warning" href="mailto:roflaherty04@qub.ac.uk" role="button">Contact</a></p>
            </div>
        </div>
    </div>

    <div class="col-sm-3 col-md-6 col-lg-3">
        <div class="card">
            <div class="avatar">
                <img src="../../Content/Images/AboutUs/ash.jpg" alt="" />
            </div>
            <div class="content">
                <h4><strong><u>Ashlene Curran</u></strong><br>
                </h4>
                <h5>Developer</h5>
                <p><strong>Email | </strong>acurran20@qub.ac.uk</p>

                <p><a class="btn btn-warning" href="mailto:acurran20@qub.ac.uk" role="button">Contact</a></p>
            </div>
        </div>
    </div>

    <div class="col-sm-3 col-md-6 col-lg-3">
        <div class="card">
            <div class="avatar">
                <img src="../../Content/Images/AboutUs/nathan.jpg" alt="" />
            </div>

            <h4><strong><u>Nathan Smith</u></strong><br>
            </h4>
            <h5>Developer</h5>
            <p><strong>Email | </strong>nsmith12@qub.ac.uk</p>
            <p><a class="btn btn-warning" href="mailto:nsmith12@qub.ac.uk" role="button">Contact</a></p>
        </div>
    </div>
    <hr />

    <br />
    <div style="text-align: center;">
        <div class="center" style="display: inline-block; text-align: left">
            <h4><strong><u>Contact our Team</u></strong></h4>
            <address>
                Queen's University Belfast<br />
                University Road,<br />
                Belfast,<br />
                BT7 1NN<br />
                <br />
                <abbr title="Email Address">E |</abbr>
                qubse@gmail.com
            </address>
            <p><a class="btn btn-info" href="mailto:qubse@gmail.com" role="button">Contact</a></p>
        </div>
    </div>
</asp:Content>
