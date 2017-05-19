<%@ Page Title="Profile - Picture" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MyProfile_ProfilePicture.aspx.cs" Inherits="SE_TeamZephyr.Profile.MyProfile_ProfilePicture" %>
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
                        <a class="profile-sub-item-link-selected">Profile Photo</a>
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
                        <a href="MyProfile_ChangePassword" class="profile-sub-item-link">Change Password</a>
                    </li>

                    <li class="profile-sub-item">
                        <a href="MyProfile_CloseAccount" class="profile-sub-item-link">Close Account</a>
                    </li>

                </ul>

            </div>

            <%--Segment 2 will differ for each page, This will be --%>

            <div class="seg2">

                 <h1 class="form-heading">Profile Picture</h1>
                <p class="paragraph paragraph-space">It's a good idea to upload a picture of yourself so other members know who to look out for!</p>

                 <div id="maindivider" class="main-divider">

                     <div class="section">

                         <asp:Image id="ImageBox" runat="server" class="image-block" ImageUrl="http://www.freeiconspng.com/uploads/upload-icon-3.png"/>

                     </div>

                     <div class="section">

                         <div class="text-block"></div>

                     </div>

                     <div class="section">
                         
                         <asp:FileUpload id="FileUploadControl" runat="server" style="margin-left:200px;"/>

                         <asp:Button runat="server" id="Btn_ImageUpload" class="choose-file-button" Text="Upload" onClick="UploadImage"></asp:Button>
                          

                         

                     </div>

                    <div class="section">

                        <asp:Label runat="server" id="StatusLabel" text="Upload status: " />

                         <p class="paragraph paragraph-center">(Jpg Max. 3mb)</p>

                     </div>

                 </div>

            </div>

        </div>

    </div>

</asp:Content>
