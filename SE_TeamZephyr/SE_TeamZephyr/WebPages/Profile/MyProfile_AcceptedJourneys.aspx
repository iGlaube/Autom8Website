<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MyProfile_AcceptedJourneys.aspx.cs" Inherits="SE_TeamZephyr.WebPages.Profile.MyProfile_AcceptedJourneys" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link href="../../Content/PageSpecificStyles/AboutPageStyle.css" rel="stylesheet" />
    <h1 align="center" >View your Journeys</h1>
    <hr />
    <h2>
        <asp:Label ID="acceptedJourneysLabel" runat="server" Text="Payment Pending Journeys"></asp:Label></h2>
    <asp:ListView ID="acceptedJourneys" OnItemCommand="acceptedJourneys_ItemDataBound" runat="server" ItemType="SE_TeamZephyr.Models.JourneyPassenger" SelectMethod="PendingPayments">


        <EmptyDataTemplate>
            <table>
                <tr>
                    <td>You are not availing of any journeys</td>
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
                            <span>Journey Number: <%#:Item.JourneyID%>
                            </span>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <span>Journey Date:  <%#:GetJourneyDate(Item.JourneyID)%>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <span>PassengerID: <%#:Item.JourneyPassengerID%>
                            </span>
                        </td>
                    </tr>
                    <tr>
                        <td>

                             <span>Driver contact info : <%#:GetJourneyOwnerEmail(Item.JourneyID)%>
        </span>
                        </td>
                    </tr>
                            <tr>
                        <td>
                            <span>Drivers Name:  <%#:GetJourneyOwnerName(Item.JourneyID)%>
                            </span>
                            
                        </td>
                    </tr>



                    <tr>
                        <td>

                            <span>You are being picked up from:  <%#:Item.pickupPoint%>
                            </span>
                            <br />
                            <span>Your postcode is:  <%#:Item.pickupPointPostcode%>
                            </span>
                            <br />
                        </td>
                    </tr>
                    <tr>
                        <td>&nbsp;</td>
                    </tr>
                </table>
            </td>
            <a class="btn btn-default" href="../Basket/AddToBasket.aspx?journeyID=<%#:Item.JourneyID %>" role="button">Pay Now</a>
        </ItemTemplate>
    </asp:ListView>

    <hr />
    <h2>Upcoming Journeys</h2>
    <asp:ListView ID="JourneysPayed" runat="server" ItemType="SE_TeamZephyr.Models.JourneyPassenger" SelectMethod="PayedJourneys">
        <EmptyDataTemplate>
            <table>
                <tr>
                    <td>You have not payed for any journeys</td>
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
                            <span>Journey Date:  <%#GetJourneyDate(Item.JourneyID)%></span><br />
                            </span>
                        </td>
                    </tr>

                    
                      <tr>
                        <td>
                            <span>Time Of Journey:  <%#GetJourneyTime(Item.JourneyID)%></span><br />
                            </span>
                        </td>
                    </tr>
                    <tr>
                        <td>

                             <span>Journey Name : <%#:GetJourneyName(Item.JourneyID)%></span><br />
                            <span></td>
                        </tr>
                        <tr>
                            <td>

                          <span>Passenger Name  : <%#: GetPassengerName(Item.passengerID)%></span><br />
                                </tr>
                    </td>

                    <tr>
                        <td>
                    
                                <span>Passenger Email  : <%#: GetPassengerEmail(Item.passengerID)%>
                                </span>
                                
                        </tr>
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
            
        </ItemTemplate>
    </asp:ListView>

    <hr />
    <h2>Completed Journeys</h2>
    <asp:ListView ID="ListView1" runat="server" ItemType="SE_TeamZephyr.Models.Journey" SelectMethod="CompletedJourneys">
        <EmptyDataTemplate>
            <table>
                <tr>
                    <td>You have not completed any journeys yet</td>
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
                            <span>Journey Name: <%# Item.JourneyName%></span>
                            <br />
                            <br />
                            <span>Journey Date: <%# Item.JourneyDate%></span>
                            <br />
                            <span>Journey Time: <%# Item.TimeOfJourney%></span>
                            <br />
                            <span>Journey Description: <%# Item.Description%></span>
                            
                        </td>
                    </tr>
                </table>
            </td>
            
        </ItemTemplate>
    </asp:ListView>
</asp:Content>
