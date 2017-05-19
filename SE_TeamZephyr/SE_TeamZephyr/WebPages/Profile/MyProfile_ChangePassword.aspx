<%@ Page Title="Profile - Change Password" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MyProfile_ChangePassword.aspx.cs" Inherits="SE_TeamZephyr.Profile.MyProfile_ChangePassword" %>
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
                        <a href="MyProfile_Vehicle" class="profile-sub-item-link">Vehicle</a>
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
                        <a class="profile-sub-item-link-selected">Change Password</a>
                    </li>

                    <li class="profile-sub-item">
                        <a href="MyProfile_CloseAccount" class="profile-sub-item-link">Close Account</a>
                    </li>

                </ul>

            </div>

            <%--Segment 2 will differ for each page, This will be --%>

            <div class="seg2">

               <h1 class="form-heading">Change Password</h1>

                <p class ="paragraph">You can change your password here.</p>

                    <div class="section">

                        <div class="section-row">
                            <div class="section-row-label">Old Password</div>
                            <asp:TextBox id="TxtBox_OldPass" TextMode="Password" CssClass="textbox" runat="server"></asp:TextBox>
                        </div>

                        <div class="section-row">
                            <div class="section-row-label">New Password</div>
                            <asp:TextBox id="TxtBox_NewPass" TextMode="Password" CssClass="textbox"  runat="server"></asp:TextBox>
                        </div>

                        
                        <div class="section-row">
                            <div class="section-row-label">Confirm New Password</div>
                            <asp:TextBox id="TxtBox_ConfirmNewPass" TextMode="Password" CssClass="textbox" runat="server"></asp:TextBox>
                        </div>

                    </div>

                <div class="section">

                     <asp:label ID="verification_label" runat="server" Text="" CssClass="verification-label" Visible="false"></asp:label>

                </div>

                    <div class="section">

                       
                        <asp:Button id="SaveButton_ChangePassword" CssClass="savebutton" runat="server" Text="Save" OnClick="Save_Button_Click"></asp:Button>

                    </div>

            </div>

        </div>

    </div>

</asp:Content>
