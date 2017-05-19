<%@ Page Title="Your Selected Journeys" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="JourneyBasket.aspx.cs" Inherits="SE_TeamZephyr.JourneyBasket" %>

<asp:Content ID="JourneyBasketContent" ContentPlaceHolderID="MainContent" runat="server">
    <div id="ShoppingCartTitle" runat="server" class="ContentHead">
        <h1>Your Added Journeys</h1>
    </div>
    <asp:GridView ID="BasketList" runat="server" AutoGenerateColumns="False" ShowFooter="True" GridLines="Vertical" CellPadding="4" ItemType="SE_TeamZephyr.Models.BasketItem"
        SelectMethod="GetJourneyBasketItems" CssClass="table table-bordered">
        <Columns>
            <asp:BoundField DataField="JourneyID" HeaderText="Journey Number"
                SortExpression="JourneyID" />

            <asp:BoundField DataField="Journey.JourneyName" HeaderText="Your Selected Journey" SortExpression="JourneyName" />

    
           
               
            
           
             

            <asp:BoundField DataField="Journey.JourneyPrice" HeaderText="Price" DataFormatString="{0:c}" />

        </Columns>
    </asp:GridView>
    <div>
        <p></p>
        <strong>
            <asp:Label ID="LabelTotalText" runat="server" Text="Journey Total:"></asp:Label>
            <asp:Label ID="lblTotal" runat="server"
                EnableViewState="false"></asp:Label>
        </strong>
    </div>
    <br />
    <asp:Label ID="JourneyBasketError" runat="server" Text="" ForeColor="Red" Font-Size="Large" Font-Bold="True"></asp:Label>
    <asp:Label ID="JourneyBasketRequest" runat="server" Text="" ForeColor="Green" Font-Size="Large" Font-Bold="True"></asp:Label>
    <table>
        <tr>
            <!--Checkout Placeholder -->

            <asp:ImageButton ID="CheckoutImageBtn" runat="server"
                ImageUrl="https://www.paypal.com/en_US/i/btn/btn_xpressCheckout.gif"
                Width="145" AlternateText="Check out with PayPal"
                OnClick="CheckoutBtn_Click"
                BackColor="Transparent" BorderWidth="0" />
        </tr>
    </table>





</asp:Content>
