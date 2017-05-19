<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="SE_TeamZephyr.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <link href="../../Content/PageSpecificStyles/GenericPageStyle.css" rel="stylesheet" />
    <link href="../../Content/PageSpecificStyles/AboutPageStyle.css" rel="stylesheet" />
    <div id="main">
        <h1 align="center">Contact Us</h1>
        <center> <h4>If you wish to contact us with any enquiries or queries, please complete the form below.</h4></center>

        <asp:Label ID="FormAdded" runat="server" Text="" ForeColor="Green" Font-Size="Large" Font-Bold="True"></asp:Label>
        <asp:Label ID="FormError" runat="server" Text="" ForeColor="Red" Font-Size="Large" Font-Bold="True"></asp:Label>
        <center><p>
            Name:
        </p>
        <center><p>
            <asp:TextBox ID="UserName" runat="server"  style = "color:black" Width="244px" placeholder="Username"></asp:TextBox></center>
               <center><asp:RequiredFieldValidator runat="server" ControlToValidate="Username"
                    CssClass="text-danger" ErrorMessage="Please add your name" /></center>
                    <asp:RegularExpressionValidator ID="regexUsername" runat="server" CssClass="text-danger" ErrorMessage="Please enter an alphabetic username that is less than 40 chars." ControlToValidate="Username" ValidationExpression="^[a-zA-Z'.\s]{1,40}$" />
        </p></center>
        <center> <p>
            Email Address:
        </p></center>
        <center><p>
            <asp:TextBox ID="UserEmail" runat="server" Width="245px" placeholder="Email"  style = "color:black"></asp:TextBox></center>
        <center> <asp:RequiredFieldValidator runat="server" ControlToValidate="UserEmail" 
                    CssClass="text-danger" ErrorMessage="Please enter your email address" /></center>
        <asp:RegularExpressionValidator ID="validateEmail" runat="server" CssClass="text-danger" ErrorMessage="Invalid email." ControlToValidate="UserEmail" ValidationExpression="^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$" />
        </p></center> 
         <center> <p>
            Subject of Enquiry
        </p></center>
        <center> <p>
            <asp:TextBox ID="UserSubject" runat="server"  style = "color:black"  Width="244px" placeholder="User Subject"></asp:TextBox></center>
        <center><asp:RequiredFieldValidator runat="server" ControlToValidate="UserSubject"
                    CssClass="text-danger" ErrorMessage="Please add a subject" /> </center>
        <asp:RegularExpressionValidator ID="regexUserSubject" runat="server" CssClass="text-danger" ErrorMessage="Please enter an alphanumeric subject that is less than 100 chars." ControlToValidate="UserSubject" ValidationExpression="^[0-9a-zA-Z'.\s]{1,100}$" />
        </p></center>
         <center> <p>
        <p>
            Your Enquiry
        </p></center>
        <center> <p>
            <asp:TextBox ID="UserComment"  style = "color:black"  Rows="10" Columns="10" wrap="true" TextMode="Multiline" runat="server" Width="244px" placeholder="Details of enquiry" Height="200px" OnKeyDown="checkTextAreaMaxLength(this,event,'1500');"/>
          </center>
        <center> <asp:RequiredFieldValidator runat="server" ControlToValidate="UserComment"
                    CssClass="text-danger" ErrorMessage="Please add an enquiry" /> </center>
        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" CssClass="text-danger" ErrorMessage="Please enter an alphanumeric message that is less than 1500 chars." ControlToValidate="UserSubject" ValidationExpression="^[0-9a-zA-Z'.\s]{1,1500}$" />
        </p>
        <p>
        </p>
        <p>
            <center><asp:Button ID="Button1" CssClass="btn btn-success" runat="server" OnClick="Button1_Click1" Text="Submit Message" ForeColor="White" /></center>

        </p>
        <p>&nbsp;</p>
        <p>&nbsp;</p>
        <p>&nbsp;</p>
    </div>
    <script>
        function checkTextAreaMaxLength(textBox, e, length) {

            var mLen = textBox["MaxLength"];
            if (null == mLen)
                mLen = length;

            var maxLength = parseInt(mLen);
            if (!checkSpecialKeys(e)) {
                if (textBox.value.length > maxLength - 1) {
                    if (window.event)//IE
                        e.returnValue = false;
                    else//Firefox
                        e.preventDefault();
                }
            }
        }
        function checkSpecialKeys(e) {
            if (e.keyCode != 8 && e.keyCode != 46 && e.keyCode != 37 && e.keyCode != 38 && e.keyCode != 39 && e.keyCode != 40)
                return false;
            else
                return true;
        }
    </script>
</asp:Content>
