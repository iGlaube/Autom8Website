<%@ Page Title="Profile - About" Language="C#" MasterPageFile="~/Site.Master"
     AutoEventWireup="true" CodeBehind="MyProfile_PersonalInfo.aspx.cs" 
    Inherits="SE_TeamZephyr.MyProfile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link href="/Content/PageSpecificStyles/MyProfile.css" rel="stylesheet" />

    <script>
        function textCounter(field,field2,maxlimit)
            {
                 var countfield = document.getElementById(field2);
                     if ( field.value.length > maxlimit ) {
                          field.value = field.value.substring( 0, maxlimit );
                          return false;
                     } else {
                  countfield.value = maxlimit - field.value.length;
             }
        }
    </script>

    <div id="maincontent" class="container" role="main">

        <div class="main">

            <div class="seg1">

                <ul id="Profile" class="seg1list">
                    
                    <li class="profile-header-menu">Profile</li>

                    <li class="profile-sub-item">
                        <a class="profile-sub-item-link-selected">Personal Information</a>
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
                        <a href="MyProfile_CloseAccount" class="profile-sub-item-link">Close Account</a>
                    </li>

                </ul>

            </div>

            <%--Segment 2 will differ for each page, This will be --%>

            <div class="seg2">

                <h1 class="form-heading">Personal Information</h1>

                <div id="maindivider" class="main-divider">

                    <div id="firstsection" class="section">

                        <div class="section-row">
                            <div class="section-row-label">Title</div>
                            <asp:TextBox id="TxtBox_Title" CssClass="textbox"  style = "color:black" runat="server"></asp:TextBox>
                        </div>

                        <div class="section-row">
                            <div class="section-row-label">First name</div>
                            <asp:TextBox id="TxtBox_FirstName" CssClass="textbox"  style = "color:black" runat="server"></asp:TextBox>
                        </div>

                        <div class="section-row">
                            <div class="section-row-label">Surname</div>
                            <asp:TextBox id="TxtBox_Surname" CssClass="textbox"   style = "color:black" runat="server"></asp:TextBox>
                        </div>

                       <div class="section-row">
                            <div class="section-row-label">Year of birth</div>
                            <asp:DropDownList id="AgeList" CssClass="dropdownlist"  style = "color:black" runat="server"></asp:DropDownList>
                        </div>

                    </div>

                    <div id="secondsection" class="section">

                        <div class="section-row">
                            <div class="section-row-label">Email</div>
                            <asp:TextBox id="TxtBox_Email" CssClass="textbox email"  style = "color:black" runat="server" ToolTip="e.g: 'email@email.com'"></asp:TextBox>
                        </div>

                        <div class="section-row">
                            <div class="section-row-label">Home number</div>
                            <asp:TextBox id="TxtBox_HomePhone" CssClass="textbox"  style = "color:black" runat="server"></asp:TextBox>
                        </div>

                        <div class="section-row">
                            <div class="section-row-label">Mobile number</div>
                            <asp:TextBox id="TxtBox_MobilePhone" CssClass="textbox"  style = "color:black" runat="server"></asp:TextBox>
                        </div>

                    </div>

                    <div id="contactsection" class="section">

                        <div class="section-row">
                            <div class="section-row-label">Address line 1</div>
                            <asp:TextBox id="TxtBox_Add1" CssClass="textbox email"  style = "color:black" runat="server"></asp:TextBox>
                        </div>

                        <div class="section-row">
                            <div class="section-row-label">Address line 2</div>
                            <asp:TextBox id="TxtBox_Add2" CssClass="textbox email"   style = "color:black" runat="server"></asp:TextBox>
                        </div>

                        <div class="section-row">
                            <div class="section-row-label">City/Town</div>
                            <asp:TextBox id="TxtBox_Citown" CssClass="textbox"  style = "color:black" runat="server"></asp:TextBox>
                        </div>

                       <div class="section-row">
                            <div class="section-row-label">Postcode</div>
                            <asp:TextBox id="TxtBox_Postcode" CssClass="textbox"  style = "color:black" runat="server"></asp:TextBox>
                        </div>

                    </div>

                    <div id="thirdsection" class="section">

                        <div class="section-row-label">Bio</div>
                        <textarea name="BioMessage" id="BioMessage"  style = "color:black" runat="server" onkeyup="textCounter(this,'counter',400);" class="bio" placeholder="Enter a bit about yourself." maxlength="400"></textarea>

                        <div class="bio-info-area">Share some information about yourself with other members (Max. 400 characters).</div>

                    </div>

                    <div id="fourthsection" class="section">

                        <asp:Button id="SaveButton_PersonalInfo" CssClass="savebutton"  style = "color:black" runat="server" Text="Save" OnClick="Save_Button_Click"></asp:Button>

                    </div>

                </div>


            </div>

        </div>

    </div>

</asp:Content>

