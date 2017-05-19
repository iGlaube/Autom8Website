<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="LeaderboardPage_All.aspx.cs" Inherits="SE_TeamZephyr.WebPages.LeaderBoards.LeaderboardPage_All" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <!--Page Specific CSS-->
    <link href="../../Content/PageSpecificStyles/GenericPageStyle.css" rel="stylesheet" />
    <h2>All Autom8 Statistics</h2>
    <br/>
        <div class="alignRight">
            <h6>Other Leadboard tables</h6>
            <a href="LeaderboardPage_All.aspx" class="btn btn-danger">All</a>
            <a href="Leaderboard_County.aspx" class="btn btn-warning">County</a>
            <a href="Leaderboard_Users.aspx"class="btn btn-info">Individuals</a>
        </div>

    <h4>Click Column Name to Order: </h4>

    <table class="table table-hover" style="overflow-x: auto">
        <thead>
            <tr>
                <th>
                    <asp:LinkButton ID="Id_Button" runat="server" CommandName="sortAsc" OnClick="sortByRank">Rank</asp:LinkButton></th>
                <th>
                    <asp:LinkButton ID="Name" runat="server" CommandName="sortAsc" OnClick="sortByName">Name</asp:LinkButton></th>
                <th>
                    <asp:LinkButton ID="TotalJourney_Button" runat="server" CommandName="sortAsc" OnClick="sortByTotalJourney">Total Journeys</asp:LinkButton></th>
                <th>
                    <asp:LinkButton ID="Driver_Button" runat="server" CommandName="sortAsc" OnClick="sortByDistance">Total Distance</asp:LinkButton></th>

            </tr>
        </thead>

        <asp:ListView ID="leaderboardListAll" runat="server"
            ItemType="SE_TeamZephyr.Models.JourneyStatisticsAll" SelectMethod="GetJourneyStatistics">
            <ItemTemplate>
                <tr runat="server">
                    <%-- Currently adds in a line under rank number --%>
                    <td><%#:Container.DataItemIndex + 1%></td>
                    <td><%#Item.Name%></td>
                    <td><%#:Item.TotalJourneys%></td>
                    <td><%#:Item.TotalDistance%> km</td>
                </tr>
            </ItemTemplate>
        </asp:ListView>

    </table>

</asp:Content>
