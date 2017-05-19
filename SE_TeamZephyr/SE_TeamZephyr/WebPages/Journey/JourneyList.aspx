<%@ Page Title="Find A Journey" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="JourneyList.aspx.cs"
    Inherits="SE_TeamZephyr.JourneyList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link href="../../Content/PageSpecificStyles/AboutPageStyle.css" rel="stylesheet" />
    <br />

         <hgroup>
        <h1 align="center" >Find a Journey</h1>
            </hgroup>

 <center><h5>Below is all our advertised journeys.</h5></center> 
    <center><h5>Click on a journey to find out more information.</h5></center> 
    <div id="searchBar">
        <div class="row">
            <div class="col-xs-8 col-xs-offset-2">
                <div class="input-group">
                    <div class="input-group-btn search-panel">
                        <button type="button" class="btn btn-default dropdown-toggle" data-toggle="dropdown">
                            <span id="search_concept">Filter By Location</span> <span class="caret"></span>
                        </button>
                        <%-- Drop down list with all available areas --%>
                        <ul class="dropdown-menu" role="menu">
                            <li><a href="/WebPages/Journey/JourneyList.aspx?id=1">Derry / Londonderry </a></li>
                            <li><a href="/WebPages/Journey/JourneyList.aspx?id=2">Antrim </a></li>
                            <li><a href="/WebPages/Journey/JourneyList.aspx?id=3">Armagh </a></li>
                            <li><a href="/WebPages/Journey/JourneyList.aspx?id=4">Down </a></li>
                            <li><a href="/WebPages/Journey/JourneyList.aspx?id=5">Fermanagh</a></li>
                            <li><a href="/WebPages/Journey/JourneyList.aspx?id=1">Tyrone </a></li>
                            <li role="separator" class="divider"></li>
                            <li><a href="/WebPages/Journey/JourneyList.aspx">Reset</a></li>
                        </ul>
                    </div>

                    <%-- Search text box linked to search button--%>
                    <%--<input type="search" class="form-control" name="x" placeholder="Enter search...">--%>
                    <asp:TextBox ID="TextBox1" CssClass="form-control" runat="server" Width="100%" placeholder="Search for a journey:"></asp:TextBox>
                    
                </div>
                <br />

                <div class="btn btn-primary glyphicon glyphicon-search">
                        <asp:Button ID="SearchButton" runat="server" Text="Search" BackColor="Transparent" BorderWidth="0" OnClick="SearchButton_Click" />
                    </div>
            </div>
        </div>
    </div>


    <br />
    <br />

    <section>
        <div>
       
            <br />
          
            <asp:ListView ID="journeyList" runat="server"
                DataKeyNames="JourneyID" GroupItemCount="2"
                ItemType="SE_TeamZephyr.Models.Journey" style="border-color:cyan; border-width: 100px; border-style:double; border-width:thick; border-radius: 8px; " SelectMethod="GetJourneys">
                <EmptyDataTemplate>
                    <table>
                        <tr>
                            <td>There are currently no journeys advertised.</td>
                        </tr>
                    </table>
                </EmptyDataTemplate>
                <EmptyItemTemplate>
                    <td />
                </EmptyItemTemplate>
                <GroupTemplate>
                    <tr id="itemPlaceholderContainer" runat="server">
                        <td id="itemPlaceholder" runat="server"></td>
                    </tr>
                </GroupTemplate>
                <ItemTemplate>
                    <td runat="server">

                        <div style="text-align:left;">
                <div style="width:50%; margin: 0 auto; text-align:left;">
   
                        <table>
                            <tr>
                                <td>
                                    <a
                                        href="JourneyDetails.aspx?journeyID=<%#:Item.JourneyID%>"></a>
                                </td>
                            </tr>
                            <br />
                                   <div style="text-align:right;">
                            <img src="../../Content/Images/AboutUs/car2.png" / height="90" width="90" ">
                           <br />
                            <tr>
                                <td>
                                    <br />
                                    <a
                                        href="JourneyDetails.aspx?journeyID=<%#:Item.JourneyID%>">
                                        <span>
                                            <font color="yellow"> <h4><%#:Item.JourneyName%></h4></font>
                                           
                                        </span>
                                    </a>
                                    <br />
                                    <span>
                                        <b>Date:</b> <%#:Item.JourneyDate%>
                                    </span>
                                    </a>
                                    <br />
                                    <span>
                                        <b>Departure Time: </b><%#:Item.TimeOfJourney%>
                                    </span>
                                    </a>
                                    <br />

                                    <span>
                                        <b>Price: </b><%#:String.Format("{0:c}", Item.JourneyPrice)%>
                                    </span>
                                    <br />
                                </td>
                            </tr>

                            <a
                                ju="../Basket/AddToBasket.aspx?journeyID=<%#:Item.JourneyID %>">
                                <span class="JourneyListItem">
                                    <%--          <b>Select This Journey<b>--%>
                            <tr>
                                <td>&nbsp;</td>
                            </tr>
                        </table>
                        </p>
                    </td>
                </ItemTemplate>
                <LayoutTemplate>
                    <table style="width: 100%;">
                        <tbody>
                            <tr>
                                <td>
                                     <div style="text-align:center;">
                <div style=" border-color:blue;">
                                    <table id="groupPlaceholderContainer"
                                        runat="server" style="width: 100%" border="1" padding="15px" border-width="10px">
                                        <tr id="groupPlaceholder"></tr>
                                     
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td></td>
                            </tr>
                            <tr></tr>
                        </tbody>
                    </table>
                </LayoutTemplate>
            </asp:ListView>
        </div>
    </section>
</asp:Content>
