<%@ Page Title="Profile - Preferences" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MyProfile_Preferences.aspx.cs" Inherits="SE_TeamZephyr.Profile.MyProfile_Preferences" %>
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
                        <a class="profile-sub-item-link-selected">Preferences</a>
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

           <script type="text/javascript">

           function NoSmokingClick() {



           }

           $('#Smoking_No').click(function () {
               $('#Smoking_No').css({
                   'border': 'solid 1px cornflowerblue'
               });
           });

        </script>

            <%--Segment 2 will differ for each page, This will be --%>

            <div class="seg2">

                 <h1 class="form-heading">Preferences</h1>
                <p class="paragraph paragraph-space">Select which preferences you'd rather have when car sharing!</p>

                 <div id="maindivider" class="main-divider">

                     <div class="section">

                         <div class="section-row-label margin">Smoking:</div>

                         <div id="Smoking_No" class="option-icon option-icon-smoking1" onclick="NoSmokingClick()">

                             <span class="tooltiptext">I don't like smoking.</span>

                         </div>

                         <div id="Smoking_Maybe" class="option-icon option-icon-smoking2">

                             <span class="tooltiptext">I don't mind smoking.</span>

                         </div>

                         <div id="Smoking_Yes"class="option-icon option-icon-smoking3">

                             <span class="tooltiptext">I like smoking.</span>

                         </div>

                     </div>

                     <div class="section">

                         <div class="section-row-label margin">Music:</div>

                         <div id="Music_No" class="option-icon option-icon-music1">

                             <span class="tooltiptext">I don't like music on the drive.</span>

                         </div>

                         <div id="Music_Maybe" class="option-icon option-icon-music2">

                             <span class="tooltiptext">I don't mind having music on.</span>

                         </div>

                         <div id="Music_Yes" class="option-icon option-icon-music3">

                             <span class="tooltiptext">I love to listen to music on the drive.</span>

                         </div>

                     </div>

                     <div class="section">

                         <div class="section-row-label margin">Pets:</div>

                         <div id="Pets_No" class="option-icon option-icon-pets1">

                             <span class="tooltiptext">I hate animals.</span>

                         </div>

                         <div id="Pets_Maybe" class="option-icon option-icon-pets2">

                             <span class="tooltiptext">I don't mind animals.</span>

                         </div>

                         <div id="Pets_Yes" class="option-icon option-icon-pets3">

                             <span class="tooltiptext">I love animals.</span>

                         </div>

                     </div>

                     <div id="fourthsection" class="section">

                        <asp:Button id="SaveButton_Preferences" CssClass="savebutton" runat="server" Text="Save" OnClick="Save_Button_Click"></asp:Button>

                    </div>

                 </div>

            </div>

        </div>

    </div>

</asp:Content>
