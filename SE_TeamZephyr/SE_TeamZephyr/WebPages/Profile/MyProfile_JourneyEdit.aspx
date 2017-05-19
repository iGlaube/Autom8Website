<%@ Page Title="Journey Information" Language="C#" MasterPageFile="~/Site.Master"
    AutoEventWireup="true"
    CodeBehind="MyProfile_JourneyEdit.aspx.cs" Inherits="SE_TeamZephyr.Profile.MyProfile_JourneyEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

   <center><img src="../../Content/Images/AboutUs/editjoureny.png" /></center> 
    </br>
    <div class="section-row">
        <div class="section-row-label">Journey Name</div>
        <asp:TextBox ID="TxtBox_JourneyName" CssClass="textbox" runat="server"></asp:TextBox>
    </div>
    <br />

    <div class="section-row">
        <div class="section-row-label">Journey Description</div>
        <asp:TextBox ID="TxtBox_JourneyDescription" CssClass="textbox" runat="server"></asp:TextBox>
    </div>
    <br />

    <div class="section-row">
        <div class="section-row-label">Date Of Journey</div>
        <asp:TextBox ID="TxtBox_JourneyDateSelect" CssClass="textbox" runat="server" ReadOnly="true"></asp:TextBox>
    </div>
    <br />
    <asp:Calendar ID="Calendar1" runat="server" OnSelectionChanged="Calendar1_SelectionChanged"></asp:Calendar>
    <br />

    <div class="section-row">
        <div class="section-row-label">
            Time of Journey<br />
            <asp:DropDownList ID="TxtBox_TimeSelected" runat="server" OnSelectedChanged="ddlTimeFrom_SelectedIndexChanged"></asp:DropDownList><br />
            <br />
        </div>
    </div>

    <div class="section-row">
        <div class="section-row-label">
            Number of Seats in Car Available
        </div>
        <asp:TextBox ID="TxtBox_SeatsAvailable" CssClass="textbox" runat="server"></asp:TextBox>
    </div>
    <br />

    <h2><b>Drivers Preferences:</b></h2>
    <br />
    <div class="section-row">
        <div class="section-row-label">Smoking Preference</div>
        <asp:DropDownList ID="SmokingPreference" runat="server" CssClass="form-control" Width="250px">
            <asp:ListItem Text="" Value="" runat="server"></asp:ListItem>
            <asp:ListItem Text="" Value="" runat="server"></asp:ListItem>
            <asp:ListItem Text="" Value="" runat="server"></asp:ListItem>
            <asp:ListItem Text="" Value="" runat="server"></asp:ListItem>
        </asp:DropDownList>
    </div>
    <br />

    <div class="section-row">
        <div class="section-row-label">Music Preference</div>
        <asp:DropDownList ID="MusicPreference" runat="server" CssClass="form-control" Width="250px">
            <asp:ListItem Text="" Value="" runat="server"></asp:ListItem>
            <asp:ListItem Text="" Value="" runat="server"></asp:ListItem>
            <asp:ListItem Text="" Value="" runat="server"></asp:ListItem>
            <asp:ListItem Text="" Value="" runat="server"></asp:ListItem>
        </asp:DropDownList>
    </div>
    <br />
    <div class="section-row">
        <div class="section-row-label">Animal Preference</div>
        <asp:DropDownList ID="AnimalPreference" runat="server" CssClass="form-control" Width="250px">
            <asp:ListItem Text="" Value="" runat="server"></asp:ListItem>
            <asp:ListItem Text="" Value="" runat="server"></asp:ListItem>
            <asp:ListItem Text="" Value="" runat="server"></asp:ListItem>
            <asp:ListItem Text="" Value="" runat="server"></asp:ListItem>
        </asp:DropDownList>
    </div>
    <br />

    <br />
    <br />
    <asp:Label ID="EditError" runat="server" Text="" ForeColor="Red" Font-Size="Large" Font-Bold="True"></asp:Label>
    <br />
    <asp:Button ID="Button4" runat="server" onclick="updateJourney_Click" Text="Update" />
    <br />
    <asp:Button ID="Button1" runat="server" OnClick="deleteJourney_Click" Text="Delete" />

</asp:Content>
