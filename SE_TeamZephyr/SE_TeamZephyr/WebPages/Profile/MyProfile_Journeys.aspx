<%@ Page Title="Your Advertised Journeys" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="MyProfile_Journeys.aspx.cs" Inherits="SE_TeamZephyr.Profile.MyProfile_Journeys" %>

<asp:Content ID="Main" ContentPlaceHolderID="MainContent" runat="server">
    <link href="../../Content/PageSpecificStyles/AccordionStyle.css" rel="stylesheet" />
               <link href="../../Content/PageSpecificStyles/AboutPageStyle.css" rel="stylesheet" />

    <section>
        <div>
                <h1 align="center" >Advertised Journeys</h1>

            <hr />
            <h2>
                <asp:Label ID="myJourneysLabel" runat="server" Text="Journeys Pending Completion"></asp:Label></h2>
            <h4>Please confirm or deny the following Journeys. </h4>

            <asp:ListView ID="myJourneys" OnItemCommand="myJourneys_ItemDataBound" runat="server" ItemType="SE_TeamZephyr.Models.Journey" SelectMethod="PendingCompletion">
                <EmptyDataTemplate>
                    <table>
                        <tr>
                            <td>You have no journeys pending completion</td>
                        </tr>
                    </table>
                </EmptyDataTemplate>
                <GroupTemplate>
                    <tr id="itemPlaceholderContainer" runat="server">
                        <td id="itemPlaceholder" runat="server"></td>
                    </tr>
                </GroupTemplate>
                <ItemTemplate>
                    <td runat="server">
                        <table>
                            <tr>
                                <td>

                                    <span>Journey Name: <%# Item.JourneyName%></span><br />
                                </td>
                                <td>

                                    <span>Journey Date: <%# Item.JourneyDate%></span><br />
                                    <span>Journey Time: <%# Item.TimeOfJourney%></span>
                                    <span>Journey Description: <%# Item.Description%></span>

                                    <br />
                                </td>
                            </tr>
                        </table>
                    </td>
                    <asp:Button ID="ConfirmJourney" runat="server" Text="Journey Completed" CommandArgument="<%#:Item.JourneyID%>" CommandName="Confirm" />
                    <asp:Button ID="DenyJourney" runat="server" Text="Journey Not Completed" CommandArgument="<%#:Item.JourneyID%>" CommandName="Deny" />

                    <br></br>
                    <br></br>
                </ItemTemplate>
            </asp:ListView>

            <hr />
            <h2>
                <asp:Label ID="Label1" runat="server" Text="Upcoming Journeys - Driving"></asp:Label></h2>
            <asp:ListView ID="myJourneyList" runat="server"
                DataKeyNames="JourneyID" GroupItemCount="3"
                ItemType="SE_TeamZephyr.Models.Journey" SelectMethod="GetMyJourneys">

                <EmptyDataTemplate>
                    <table>
                        <tr>
                            <td>You currently have no journeys advertised.</td>
                        </tr>
                        <tr>
                            <td><a href="../Journey/AddAJourney.aspx"><b>Click here to advertise your journey</b></a></td>
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
                        <img src="../../Content/Images/AboutUs/passenger.png" / height="120" width="150">
                        <table>
                              <div style="text-align:left;">
                            <tr>
                                <td>
                                    
                            <div style="width:100%; margin: 0 auto; text-align:;">
                         
                                    <font color="yellow"> <h4><%#:Item.JourneyName%></h4></font>
                                    <a href="MyProfile_JourneyDetails.aspx?journeyID=<%#:Item.JourneyID %>">
                                        <font color="aqua"> <b>(View)<b></font>
                                    </a>
                                    
                                    <a href="MyProfile_JourneyEdit.aspx?journeyID=<%#:Item.JourneyID %>">
                                       <font color="aqua"> <b>(Edit)<b></font>
                                    </a>
                                    <br />
                                    <b>Price: £</b><%#:String.Format("{0:N}", Item.JourneyPrice)%>
                                    <br />
                                    <b>Date: </b><%#:Item.JourneyDate %>
                                    <br />
                                    <b>Time: </b><%#:Item.TimeOfJourney %>
                                    <br />
                                   <b>Journey Description : </br>

                                            </b><%#:Item.Description %>         

                                </td>
                            </tr>
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
                                    <table id="groupPlaceholderContainer" border="1"
                                        runat="server" style="width: 100%">
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
