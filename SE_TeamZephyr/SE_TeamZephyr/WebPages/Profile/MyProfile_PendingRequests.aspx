<%@ Page Title="Manage Journeys" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MyProfile_PendingRequests.aspx.cs" Inherits="SE_TeamZephyr.WebPages.Profile.MyProfile_PendingRequests" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link href="../../Content/PageSpecificStyles/AboutPageStyle.css" rel="stylesheet" />
   <h1 align="center" >Your Pending Journeys</h1>
    <h2>
        <asp:Label ID="myJourneysLabel" runat="server" Text="Pending Passenger Requests For Your Journeys"></asp:Label></h2>
    <h4>Please accept or reject the following requests. </h4>

    <asp:Label ID="PassengerAccepted" runat="server" Text="" ForeColor="Yellow" Font-Size="Large" Font-Bold="True"></asp:Label>
    <br />
    <asp:Label ID="PassengerRejected" runat="server" Text="" ForeColor="Orange" Font-Size="Large" Font-Bold="True"></asp:Label>

    <asp:ListView ID="myJourneys" OnItemCommand="myJourneys_ItemDataBound" runat="server" ItemType="SE_TeamZephyr.Models.JourneyPassenger" SelectMethod="MyJourneys">
        <EmptyDataTemplate>
            <table>
                <tr>
                    <td>You have no pending passenger requests</td>
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
                            <span>Journey Number:  <%#:Item.JourneyID%>
                            </span>
                        </td>
                    </tr>
                    <tr>
                        <td>

                            <span>journey Name : <%#:GetJourneyName(Item.JourneyID)%></span><br />
                            <span></td>
                        <tr>
                            <td>

                                <span>Passenger Name  : <%#: GetPassengerName(Item.passengerID)%></span><br />
                                <span>Passenger Email  : <%#: GetPassengerEmail(Item.passengerID)%>
                                </span>
                                <br />
                            </td>
                            <tr>
                                <td>

                                    <span>Passenger wants picked up from:  <%#:Item.pickupPoint%>
                                    </span>
                                    <br />
                                    <span>Their Postcode is:   <%#:Item.pickupPointPostcode%>
                                    </span>
                                    <br />
                                </td>

                            </tr>
                    <tr>
                        

                        <td>&nbsp;</td>
                       
                    </tr>
                </table>
            </td>
            <asp:Button ID="AcceptPassenger" style = "color:black" runat="server" Text="Accept Passenger" CommandArgument="<%#:Item.JourneyPassengerID%>" CommandName="Accept" />
            <asp:Button ID="RejectPassenger" style = "color:black" runat="server" Text="Reject Passenger" CommandArgument="<%#:Item.JourneyPassengerID%>" CommandName="Reject" />

            <br></br>
            <br></br>
        </ItemTemplate>

    </asp:ListView>



    <hr />
    <br />

    <h2>
        <asp:Label ID="otherJourneysLabel" runat="server" Text="Your Pending Requests For Other Journeys"></asp:Label></h2>
    <asp:ListView ID="otherJourneys" runat="server" ItemType="SE_TeamZephyr.Models.JourneyPassenger" SelectMethod="OtherJourneys">
        <EmptyDataTemplate>
            <table>
                <tr>
                    <td>You have no requests to be a passenger.</td>
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
                            <span>Your requested journey number:   <%#:Item.JourneyID%>
                            </span>
                        </td>
                    </tr>
                    <tr>
                        <td>
                           <span>journey Name : <%#:GetJourneyName(Item.JourneyID)%></span><br />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <span>Driver contact info :<%#:GetJourneyOwnerEmail(Item.JourneyID)%></span></td>
                    </tr>
                    <tr>
                        <td>
                            <span>Journey Date:  <%#:GetJourneyDate(Item.JourneyID)%>
                            </span>
                        </td>
                    </tr>
                    <tr>
                        <td>

                            <span>You want picked up from:    <%#:Item.pickupPoint%>
                            </span>
                            <br />
                            <span>This is your pickup postcode:   <%#:Item.pickupPointPostcode%>
                            </span>
                            <br />
                        </td>
                    </tr>
                    <tr>
                        <td>&nbsp;</td>
                    </tr>
                </table>
            </td>
        </ItemTemplate>
    </asp:ListView>
</asp:Content>
