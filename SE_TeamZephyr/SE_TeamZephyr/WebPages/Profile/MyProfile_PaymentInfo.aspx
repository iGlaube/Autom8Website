<%@ Page Title="Profile - Payment Info" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MyProfile_PaymentInfo.aspx.cs" Inherits="SE_TeamZephyr.Profile.MyProfile_PaymentInfo" %>
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
                        <a class="profile-sub-item-link-selected">Payment Information</a>
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

                <h1 class="form-heading">Payment Information</h1>

                <p class ="paragraph">Save your banking and PayPal information here for later use.</p>

                  <div id="maindivider" class="main-divider">

                    <div id="firstsection" class="section">

                        <h1 class="form-heading">Banking</h1>

                        <p class ="paragraph">Store your banking information.</p>

                        <div class="section-row">
                            <div class="section-row-label">Country</div>
                            <asp:TextBox id="TxtBox_BankCountry" CssClass="textbox" runat="server" placeholder="Country of your bank"></asp:TextBox>
                        </div>

                        <div class="section-row">
                            <div class="section-row-label">Account holder</div>
                            <asp:TextBox id="TxtBox_BankAccountHolder" CssClass="textbox email" runat="server" placeholder="Name on card"></asp:TextBox>
                        </div>

                        <div class="section-row">
                            <div class="section-row-label">Bank name</div>
                            <asp:TextBox id="TxtBox_BankName" CssClass="textbox" runat="server" placeholder="e.g: 'Santander'"></asp:TextBox>
                        </div>

                        <div class="section-row">
                            <div class="section-row-label">Sort Code</div>
                            <asp:TextBox id="TxtBox_BankSortCode" CssClass="textbox" runat="server" placeholder="e.g: '12-34-56'"></asp:TextBox>
                        </div>

                        <div class="section-row">
                            <div class="section-row-label">Account Number</div>
                            <asp:TextBox id="TxtBox_BankAccountNumber" CssClass="textbox" runat="server" placeholder="e.g: '12345678'"></asp:TextBox>
                        </div>

                    </div>

                    <div id="secondsection" class="section">

                        <h1 class="form-heading">PayPal</h1>

                        <p class ="paragraph">Store your paypal information.</p>

                        <div class="section-row">
                            <div class="section-row-label">PayPal Email</div>
                            <asp:TextBox id="TxtBox_PaypalEmail" CssClass="textbox email" runat="server" ToolTip="e.g: 'email@email.com'" placeholder="e.g: 'email@email.com'"></asp:TextBox>
                        </div>

                    </div>

                      
                    <div id="fourthsection" class="section">

                        <asp:Button id="SaveButton_PaymentInfo" CssClass="savebutton" runat="server" Text="Save" OnClick="Save_Button_Click"></asp:Button>

                    </div>

            </div>

        </div>

    </div>

</asp:Content>
