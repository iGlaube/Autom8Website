<%@ Page Title="Profile - Vehicle" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MyProfile_Vehicle.aspx.cs" Inherits="SE_TeamZephyr.Profile.MyProfile_Vehicle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <link href="/Content/PageSpecificStyles/MyProfile.css" rel="stylesheet" />

    <div id="maincontent" class="container" role="main">

        <div class="main">

            <div class="seg1">

                <ul id="Profile" class="seg1list">

                    <li class="profile-header-menu">Profile</li>

                    <li class="profile-sub-item">
                        <a href="MyProfile_PersonalInfo" class="profile-sub-item-link">Personal Information</a>
                    </li>

                    <li class="profile-sub-item">
                        <a href="MyProfile_ProfilePicture" class="profile-sub-item-link">Profile Photo</a>
                    </li>

                    <li class="profile-sub-item">
                        <a href="MyProfile_Verification" class="profile-sub-item-link">Verification</a>
                    </li>

                    <li class="profile-sub-item">
                        <a class="profile-sub-item-link-selected">Vehicle</a>
                    </li>

                    <li class="profile-sub-item">
                        <a href="MyProfile_Preferences" class="profile-sub-item-link">Preferences</a>
                    </li>

                </ul>

                <ul id="Account" class="seg1list">

                    <li class="profile-header-menu">Account</li>

                    <li class="profile-sub-item">
                        <a href="MyProfile_PaymentInfo" class="profile-sub-item-link">Payment Information</a>
                    </li>

                    <li class="profile-sub-item">
                        <a href="MyProfile_ChangePassword" class="profile-sub-item-link">Change Password</a>
                    </li>

                    <li class="profile-sub-item">
                        <a href="MyProfile_CloseAccount" class="profile-sub-item-link">Close Account</a>
                    </li>

                </ul>

            </div>

            <%--Segment 2 will differ for each page, This will be --%>

            <div class="seg2">

                <h1 class="form-heading">Vehicle</h1>

                <p class="paragraph">Verify the details about your Vehicle.</p>

                <div class="section-c">

                    <div class="section-row">
                        <div class="section-row-label">Make: </div>
                        <asp:Label ID="Label_VehicleMake" runat="server"></asp:Label>
                    </div>

                    <br />

                    <div class="section-row">
                        <div class="section-row-label">Model: </div>
                        <asp:Label ID="Label_VehicleModel" CssClass="textbox" runat="server"></asp:Label>
                    </div>

                    <br />

                    <div class="section-row">
                        <div class="section-row-label">Number Plate: </div>
                        <asp:Label ID="Label_VehiclePlate" CssClass="textbox" runat="server"></asp:Label>
                    </div>

                    <br />

                    <div class="section-row">
                        <div class="section-row-label">Colour: </div>
                        <asp:Label ID="Label_VehicleColour" CssClass="textbox" runat="server"></asp:Label>
                    </div>

                    <br />

                    <div class="section-row">
                        <div class="section-row-label">Number Of Seats: </div>
                        <asp:Label ID="Label_VehicleSeats" CssClass="textbox" runat="server"></asp:Label>
                    </div>

                    <br />

                    <div class="section-row">
                        <div class="section-row-label">Fuel Type: </div>
                        <asp:Label ID="Label_VehicleFuelType" CssClass="textbox" runat="server"></asp:Label>
                    </div>

                    <br />

                    <div class="section-row">
                        <div class="section-row-label">CO2 Per Gallon: </div>
                        <asp:Label ID="Label_VehicleCO2Emissions" CssClass="textbox" runat="server"></asp:Label>
                    </div>

                    <br />

                    <div class="section-row">
                        <div class="section-row-label">Litres Per Kilometer: </div>
                        <asp:Label ID="Label_VehicleLitresPerKilometer" CssClass="textbox" runat="server"></asp:Label>
                    </div>

                    <br />

                    <div class="section">
                        <div class="section-row-label">Enter Plate Number:</div>
                        <asp:TextBox ID="TxtBox_PlateNumber" CssClass="textbox" runat="server" style = "color:black" ></asp:TextBox>
                        <asp:Button ID="SaveButton_Vehicle" CssClass="savebutton-wide savebutton-c" runat="server" Text="Update Vehicle" OnClick="Save_Button_Click"></asp:Button>
                    </div>

                    <asp:Label ID="VehicleError" runat="server" Text="" ForeColor="Red" Font-Size="Large" Font-Bold="True"></asp:Label>

                </div>

            </div>

        </div>

    </div>

</asp:Content>
