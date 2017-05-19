<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Leaderboard_Users.aspx.cs" Inherits="SE_TeamZephyr.WebPages.LeaderBoards.Leaderboard_Users" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <!--Page Specific CSS-->
    <link href="../../Content/PageSpecificStyles/GenericPageStyle.css" rel="stylesheet" />

    <h2>All Autom8 Riders</h2>
    <br/>
        <div class="alignRight">
            <h6>Other Leadboard tables</h6>
            <a href="LeaderboardPage_All.aspx" class="btn btn-danger">All</a>
            <a href="Leaderboard_County.aspx" class="btn btn-warning">County</a>
            <a href="Leaderboard_Users.aspx"class="btn btn-info">Individuals</a>
        </div>

    <h4>Click Column Name to Order: </h4>

    <table class="table table-hover">
        <thead>
            <tr>
                <th>
                    <asp:LinkButton ID="Id_Button" runat="server" CommandName="sortAsc" OnClick="sortByRank">Rank</asp:LinkButton></th>
                <th>
                    <asp:LinkButton ID="Name" runat="server" CommandName="sortAsc" OnClick="sortByName">Username</asp:LinkButton></th>
                <th>
                    <asp:LinkButton ID="TotalJourney_Button" runat="server" CommandName="sortAsc" OnClick="sortByTotalJourney">Total Journeys</asp:LinkButton></th>
                <th>
                    <asp:LinkButton ID="Driver_Button" runat="server" CommandName="sortAsc" OnClick="sortByDriver">As Driver</asp:LinkButton></th>
                <th>
                    <asp:LinkButton ID="Passenger_Button" runat="server" CommandName="sortAsc" OnClick="sortByPassenger">As Passenger</asp:LinkButton></th>
                <th>
                    <asp:LinkButton ID="Total_Button" runat="server" CommandName="sortAsc" OnClick="sortByTotal">Total Distance</asp:LinkButton></th>
                <th>
                    <asp:LinkButton ID="SavingsButton" runat="server" CommandName="sortAsc" OnClick="sortBySavings">Total Savings</asp:LinkButton></th>
            </tr>
        </thead>
        <asp:ListView ID="leaderboardList" runat="server"
            ItemType="SE_TeamZephyr.Models.JourneyStatistics" SelectMethod="GetJourneyStatistics">
            <ItemTemplate>
                <tr runat="server">
                    <%-- Currently adds in a line under rank number --%>
                    <td><%#:Container.DataItemIndex + 1%></td>
                    <td><%#:getUsernameByID(Item.UserID)%></td>
                    <td><%#:Item.TotalJourneys%></td>
                    <td><%#:Item.DistanceAsDriver%> km</td>
                    <td><%#:Item.DistanceAsPassenger%> km</td>
                    <td><%#:Item.TotalDistanceTravelled%> km</td>
                    <td><%#:String.Format("{0:c}", Item.FuelCost)%></td>
                </tr>
            </ItemTemplate>
        </asp:ListView>

    </table>

</asp:Content>

