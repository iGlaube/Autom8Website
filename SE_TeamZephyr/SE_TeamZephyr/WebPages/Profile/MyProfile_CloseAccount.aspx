<%@ Page Title="Close Your  Account" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MyProfile_CloseAccount.aspx.cs" Inherits="SE_TeamZephyr.Profile.MyProfile_CloseAccount" %>
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
                        <a href="MyProfile_ChangePassword" class="profile-sub-item-link">Change Password</a>
                    </li>

                    <li class="profile-sub-item">
                        <a class="profile-sub-item-link-selected">Close Account</a>
                    </li>

                </ul>

            </div>

            <%--Segment 2 will differ for each page, This will be --%>

            <div class="seg2">

              <h1 class="form-heading">Close Account</h1>

                <p class ="paragraph">If you'd like to close your account because you weren't able to solve a problem, please take a look at our tips first:</p>

                <ul class="help-delete-account-list" style="list-style-type:circle">

                    <li>To edit your email or phone number, you can <a class="a-link" href="MyProfile_PersonalInfo.aspx">edit your profile</a>.</li>

                    <li>To resolve a technical issue you may be having, you can <a  class="a-link" href="mailto:qubse@gmail.com">contact us</a>.</li>
                    <li>If you feel as though you recieved an unjust rating, you can <a class="a-link" href="mailto:qubse@gmail.com">contact us</a>.</li>
                </ul>

                    <div class="section">

                         <p class ="paragraph">If you still want to close your account, please give us some more information to help us imporive.</p>

                        <div class="section-row-c">
                            <div class="section-row-label-c">Reason: </div>
                            <asp:DropDownList id="Dropdown_Reason" CssClass="dropdownlist" runat="server"></asp:DropDownList>
                        </div>

                        
                       <div class="section-row-c">
                            <div class="section-row-label-c">Would you recommend AutoM8?</div>
                            <asp:DropDownList id="Dropdown_Recommend" CssClass="dropdownlist" runat="server"></asp:DropDownList>
                        </div>

                        <div class="section-row-c">
                            <div class="section-row-label-c">What could we improve?</div>
                            <textarea name="ImproveMessage" id="ImproveMessage" runat="server" onkeyup="textCounter(this,'counter',400);" class="bio" placeholder="Give us some feedback on your experience." maxlength="400"></textarea>
                       </div>
                    </div>

                <div class="section">

                </div>

                    <div class="section">

                       
                        <asp:Button id="CloseButton_CloseAccount" CssClass="savebutton savebutton-red" runat="server" Text="Close Account" OnClick="Close_Button_Click"></asp:Button>

                    </div>

            </div>

        </div>

    </div>

</asp:Content>
