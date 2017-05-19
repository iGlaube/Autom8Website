<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Leaderboard_County.aspx.cs" Inherits="SE_TeamZephyr.WebPages.LeaderBoards.Leaderboard_County" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <!--Page Specific CSS-->
    <link href="../../Content/PageSpecificStyles/GenericPageStyle.css" rel="stylesheet" />

    <h2>Top Autom8 Counties</h2>
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
                    <asp:LinkButton ID="Name" runat="server" CommandName="sortAsc" OnClick="sortByName">County</asp:LinkButton></th>
                <th>
                    <asp:LinkButton ID="Total_Button" runat="server" CommandName="sortAsc" OnClick="sortByTotal">Total Journeys</asp:LinkButton></th>
                <th>
                    <asp:LinkButton ID="Driver_Button" runat="server" CommandName="sortAsc" OnClick="sortByDistance">Total Distance</asp:LinkButton></th>
            </tr>
        </thead>

        <asp:ListView ID="leaderboardListCounty" runat="server"
            ItemType="SE_TeamZephyr.Models.JourneyStatisticsGlobal" SelectMethod="GetJourneyStatistics">
            <ItemTemplate>
                <tr runat="server">
                    <%-- Currently adds in a line under rank number --%>
                    <td><%#:Container.DataItemIndex + 1%></td>
                    <td><%#getAreaName(Item.AreaID)%></td>
                    <td><%#:Item.TotalJourneys%></td>
                    <td><%#:Item.TotalDistance%> km</td>
                </tr>
            </ItemTemplate>
        </asp:ListView>

    </table>

</asp:Content>

