<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MyProfile_Verification_MemAgreement.aspx.cs" Inherits="SE_TeamZephyr.Profile.MyProfile_Verification_MemAgreement" %>
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
                        <a href="MyProfile_Verification" class="profile-sub-item-link-selected">Verification</a>
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

                <h1 class="form-heading">Member's Agreement</h1>
                <p class ="paragraph">Agree to all of our terms to become a trusted member.</p>

                    <div class="section">

                        <div class="section-smaller-v">

                            <h2 class="smaller-heading-v">Genuine Information</h2>

                            <p class="verify-paragraph">You agree that all of the information you provide us with is up to date, legitimate and true.</p>

                            <asp:CheckBox runat="server" ID="CheckBox1" CssClass="checkbox-v"/>


                        </div>

                        <div class="section">

                        <div class="section-smaller-v">

                            <h2 class="smaller-heading-v">Reliability</h2>

                            <p class="verify-paragraph">You agree to be on time when carsharing.</p>

                            <asp:CheckBox runat="server" ID="CheckBox2" CssClass="checkbox-v"/>


                        </div>

                       <div class="section">

                        <div class="section-smaller-v">

                            <h2 class="smaller-heading-v">Road Safety</h2>

                            <p class="verify-paragraph">You agree to abide by the laws of the road and take care of your passengers.</p>

                            <asp:CheckBox runat="server" ID="CheckBox3" CssClass="checkbox-v"/>


                        </div>

                           </div>


                       <div class="section">

                        <div class="section-smaller-v">

                            <h2 class="smaller-heading-v">Fair Ratings</h2>

                            <p class="verify-paragraph">You agree to rate other users fairly on journeys.</p>

                            <asp:CheckBox runat="server" ID="CheckBox4" CssClass="checkbox-v"/>


                        </div>


                      <div class="section">

                        <div class="section-smaller-v">

                            <h2 class="smaller-heading-v">Enjoy</h2>

                            <p class="verify-paragraph">Most importantly you agree to enjoy the experience our application offers!</p>

                            <asp:CheckBox runat="server" ID="CheckBox5" CssClass="checkbox-v"/>


                        </div>


                    </div>

                    <div class="section">

                        <div class="section-smaller-v-b">



                            <p class="verify-paragraph-v">By clicking you agree to our terms.</p>

                            <a class="verify-btn-v" href="MyProfile_Verification_MemAgreement.aspx">I Agree</a>



                       </div>

            </div>

        </div>

    </div>

                        </div>
                </div>
            </div>
        </div>


</asp:Content>
