<%@ Page Title="Profile - Verification" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MyProfile_Verification.aspx.cs" Inherits="SE_TeamZephyr.Profile.MyProfile_Verification" %>
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
                        <a class="profile-sub-item-link-selected">Verification</a>
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
                        <a href="MyProfile_ChangePassword" class="profile-sub-item-link">Change Password</a>
                    </li>

                    <li class="profile-sub-item">
                        <a href="MyProfile_CloseAccount" class="profile-sub-item-link">Close Account</a>
                    </li>

                </ul>

            </div>

            <%--Segment 2 will differ for each page, This will be --%>

            <div class="seg2">
                
                <h1 class="form-heading">Verification</h1>
                <p class ="paragraph">Verify your account details.</p>

                    <div class="section">

                        <div class="section-smaller">

                            <h2 class="smaller-heading">Email Address</h2>

                            <p id="p_email" runat="server" class="verify-paragraph">Your email address: </p>

                            <asp:Button ID="btn_email" runat="server" CssClass="verify-btn" Text="Verify"/>


                        </div>

                        <div class="section-smaller">

                            <h2 class="smaller-heading">Mobile Phone Number</h2>

                            <p id="p_number" runat="server" class="verify-paragraph">Your mobile number: </p>

                            <asp:Button ID="btn_number" runat="server" CssClass="verify-btn" Text="Verify"/>


                        </div>

                        <div class="section-smaller">

                            <h2 class="smaller-heading">Member's Agreement</h2>

                            <p class="verify-paragraph">Agree and become a trusted member.</p>

                            <a class="verify-btn" href="MyProfile_Verification_MemAgreement.aspx">Read and Agree</a>


                        </div>

                </div>

            </div>

        </div>

    </div>

</asp:Content>
