<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CheckoutReview.aspx.cs" Inherits="SE_TeamZephyr.Checkout.CheckoutReview" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Journey Review&nbsp;</h1>
    <p></p>
    <h4>Your Journey:</h4>
    <asp:GridView ID="OrderItemList" runat="server" AutoGenerateColumns="False" Width="500" GridLines="None">              
        <Columns>
            <asp:BoundField DataField="Journey.JourneyName" HeaderText=" Journey Name" />        
            <asp:BoundField DataField="Journey.JourneyPrice" HeaderText="Price" DataFormatString="{0:c}"/>     
               
        </Columns>    
    </asp:GridView>
    <br /><br />
    <asp:DetailsView ID="ShipInfo" runat="server" AutoGenerateRows="false" GridLines="None">
        <Fields>
        <asp:TemplateField>
            <ItemTemplate>
                <h4>Payment Billing Address</h4>
                <br />
                <asp:Label ID="FirstName" runat="server" Text='<%#: Eval("FirstName") %>'></asp:Label>  
                <asp:Label ID="LastName" runat="server" Text='<%#: Eval("LastName") %>'></asp:Label>
                <br />
                <asp:Label ID="Address" runat="server" Text='<%#: Eval("Address") %>'></asp:Label>
                <br />
                <asp:Label ID="City" runat="server" Text='<%#: Eval("City") %>'></asp:Label>
                <asp:Label ID="County" runat="server" Text='<%#: Eval("County") %>'></asp:Label>
                <asp:Label ID="PostalCode" runat="server" Text='<%#: Eval("PostalCode") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
          </Fields>
    </asp:DetailsView>
    <p></p>
    <hr />
    <asp:Button ID="CheckoutConfirm" style = "color:black" runat="server" Text="Complete Payment" OnClick="CheckoutConfirm_Click" />
</asp:Content>
