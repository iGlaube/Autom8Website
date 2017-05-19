<%@ Page Title="Advertise Journey" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddAJourney.aspx.cs" Inherits="SE_TeamZephyr.AddAJourney" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link href="../../Content/PageSpecificStyles/AccordionStyle.css" rel="stylesheet" />
    <div id="ShoppingCartTitle" runat="server" class="ContentHead">
      <i>  <h1 align="center" style="color:orangered"  >Advertise your Journey</h1></i>

    </div>

    <h4 style="color:greenyellow">Add information on the Journey. This will then be available for all users to see. </h4>
    <asp:Label ID="JourneyAdded" runat="server" Text="" ForeColor="Green" Font-Size="Large" Font-Bold="True"></asp:Label>
    <asp:Label ID="JourneyError" runat="server" Text="" ForeColor="Red" Font-Size="Large" Font-Bold="True"></asp:Label>
    <table>
        <tbody>
            <tr>
                <th>Departure Area</th>
                <td>
                    <div class="form-group">
                        <asp:DropDownList ID="AreaID" runat="server" CssClass="form-control" Width="250px">
                            <asp:ListItem Text="Co Derry/Londonderry" Value="1" runat="server"></asp:ListItem>
                            <asp:ListItem Text="Co.Antrim" Value="2" runat="server"></asp:ListItem>
                            <asp:ListItem Text="Co,Armagh" Value="3" runat="server"></asp:ListItem>
                            <asp:ListItem Text="Co.Down" Value="4" runat="server"></asp:ListItem>
                            <asp:ListItem Text="Co.Fermanagh" Value="5" runat="server"></asp:ListItem>
                            <asp:ListItem Text="Co.Tyrone" Value="6" runat="server"></asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </td>
            </tr>

            <tr>
                <th>Departure Postcode<br />
                </th>
                <td>
                    <asp:TextBox runat="server" ID="OriginPostcode" CssClass="form-control" Width="250px" placeholder="Origin Postcode" />
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="OriginPostcode"
                        CssClass="text-danger" ErrorMessage="The departure postcode field is required." />

                </td>
            </tr>

            <tr>
                <th>Destination Postcode<br />
                </th>
                <td>
                    <asp:TextBox ID="DestinationPostcode" runat="server" CssClass="form-control" Width="250px" placeholder="Destination Postcode"></asp:TextBox>
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="DestinationPostcode"
                        CssClass="text-danger" ErrorMessage="The destination postcode field is required." /><br />

                </td>
            </tr>
            <tr>
                <td>
                    <br />
                    <div class="form-group">
                        <asp:Button ID="Submit" runat="server" class="btn btn-primary" OnClick="submit_Click" Text="Calculate Duration and Distance" Width="250px" CausesValidation="false" />
                        <br />
                    </div>
                </td>
            </tr>
            <tr>
                <th>Estimated Duration of Journey</th>
                <td>
                    <div class="form-group">
                        <asp:TextBox ID="Duration" runat="server" CssClass="form-control" Width="250px" ReadOnly="true" placeholder="0"></asp:TextBox>
                    </div>

                </td>
            </tr>
            <tr>
                <th>Estimated Distance of Journey</th>
                <td>
                    <div class="form-group">
                        <asp:TextBox ID="Distance" runat="server" CssClass="form-control" Width="250px" ReadOnly="true" placeholder="0"></asp:TextBox>
                    </div>
                </td>
            </tr>
            <tr>
                <th>Price</th>
                <td>
                    <div class="form-group">
                        <asp:Label ID="JourneyPriceInput" runat="server" Text=""></asp:Label>
                    </div>
                </td>
            </tr>
            <tr>
                <th>Journey Name</th>
                <td>
                    <asp:TextBox ID="JourneyNametxt" runat="server" CssClass="form-control" Width="250px" placeholder="Journey Name"></asp:TextBox>
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="JourneyNametxt"
                        CssClass="text-danger" ErrorMessage="Please add a Journey Name" />
                    <asp:RegularExpressionValidator ID="regexJourneyName" runat="server" CssClass="text-danger" ErrorMessage="Please enter an alphabetic name that is less than 40 chars." ControlToValidate="JourneyNametxt" ValidationExpression="^[a-zA-Z'.\s]{1,40}$" />
                </td>
            </tr>
            <tr>
                <th>Journey Description</th>
                <td>
                    <div class="form-group">
                        <asp:TextBox ID="JourneyDescriptiontxt" runat="server" CssClass="form-control" Width="250px" placeholder="Journey Description"></asp:TextBox>
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="JourneyDescriptiontxt"
                            CssClass="text-danger" ErrorMessage="Please add a journey description." />
                        <asp:RegularExpressionValidator ID="regexJourneyDesc" runat="server" CssClass="text-danger" ErrorMessage="Please enter an alphanumeric description that is less than 100 chars." ControlToValidate="JourneyDescriptiontxt" ValidationExpression="^[0-9a-zA-Z'.\s]{1,100}$" />
                    </div>

                </td>
            </tr>

            <tr>
                <th>Set Available seats </th>
                <td>
                    <div class="form-group">
                        <input type="number" style = "color:black" id="NoOfSeats" runat="server" value="" placeholder="0"/>
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="NoOfSeats"
                            CssClass="text-danger" ErrorMessage="Number of seats is a required field." />
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" CssClass="text-danger" ErrorMessage="Please enter a number value." ControlToValidate="NoOfSeats" ValidationExpression="^\d+" />
                    </div>
                </td>
            </tr>

            <tr>
                <th>Enter Journey Start Time </th>
                <td>
                    <div>
                        Time: 
                        <asp:DropDownList ID="TimeSelected" style = "color:black"  runat="server" OnSelectedChanged="ddlTimeFrom_SelectedIndexChanged"></asp:DropDownList>
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="TimeSelected"
                            CssClass="text-danger" ErrorMessage="Please select your departure time" />
                    </div>
           <br />

                </td>
            </tr>

            <tr>
                <td>What is the date of your journey</td>
            </tr>
            <tr>
                <td>
                    <br />
                    <asp:Calendar ID="Calendar1" CssClass="center" runat="server" OnSelectionChanged="Calendar1_SelectionChanged"></asp:Calendar>
                </td>
            </tr>
            <tr>
                <td>
                    <br />
                    <asp:TextBox ID="JourneyDate" align="center" runat="server" style = "color:black" ReadOnly="true" placeholder="Select "></asp:TextBox>
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="JourneyDate"
                        CssClass="text-danger" ErrorMessage="Please select the departure date" />
                    <br />
                </td>
            </tr>
            <tr>
                <th>Opinions on smoking</th>
                <td>
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="SmokingPreference"
                        CssClass="text-danger" ErrorMessage="Please select preference" />
                    <div class="form-group">
                        <asp:DropDownList ID="SmokingPreference" runat="server" CssClass="form-control" Width="250px">
                            <asp:ListItem Text="" Value="" runat="server"></asp:ListItem>
                            <asp:ListItem Text="" Value="" runat="server"></asp:ListItem>
                            <asp:ListItem Text="" Value="" runat="server"></asp:ListItem>
                            <asp:ListItem Text="" Value="" runat="server"></asp:ListItem>
                        </asp:DropDownList>

                    </div>
                </td>
            </tr>
            <tr>
                <th>Opinions on Music</th>
                <td>
                    <div class="form-group">
                        <asp:DropDownList ID="MusicPreference" runat="server" CssClass="form-control" Width="250px">

                            <asp:ListItem Text="" Value="" runat="server"></asp:ListItem>
                            <asp:ListItem Text="" Value="" runat="server"></asp:ListItem>
                            <asp:ListItem Text="" Value="" runat="server"></asp:ListItem>
                            <asp:ListItem Text="" Value="" runat="server"></asp:ListItem>

                        </asp:DropDownList>
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="MusicPreference"
                            CssClass="text-danger" ErrorMessage="Please select preference" />
                    </div>
                </td>
            </tr>
            <tr>
                <th>Opinions on animals</th>
                <td>
                    <div class="form-group">
                        <asp:DropDownList ID="AnimalPreference" runat="server" CssClass="form-control" Width="250px">

                            <asp:ListItem Text="" Value="" runat="server"></asp:ListItem>
                            <asp:ListItem Text="" Value="" runat="server"></asp:ListItem>
                            <asp:ListItem Text="" Value="" runat="server"></asp:ListItem>
                            <asp:ListItem Text="" Value="" runat="server"></asp:ListItem>

                        </asp:DropDownList>
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="AnimalPreference"
                            CssClass="text-danger" ErrorMessage="Please select preference" />
                    </div>
                </td>
            </tr>
        </tbody>
    </table>
    <asp:Button ID="submitnewjourney" class="btn btn-primary" runat="server" Text="Save" OnClick="submitnewjourney_Click" />

</asp:Content>
