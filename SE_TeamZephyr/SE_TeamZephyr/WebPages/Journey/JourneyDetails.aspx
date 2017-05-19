<%@ Page Title="Journey Information" Language="C#" MasterPageFile="~/Site.Master"
    AutoEventWireup="true"
    CodeBehind="JourneyDetails.aspx.cs"
    Inherits="SE_TeamZephyr.JourneyDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="alignCenter">
        
        <asp:FormView ID="journeyDetail" runat="server"
            ItemType="SE_TeamZephyr.Models.Journey" SelectMethod="GetJourney"
            RenderOuterTable="false">
            <ItemTemplate>
                <div>
                    <h1><%#:Item.JourneyName %></h1>
                    <h4>Click below to find out more!</h4>
                </div>
                <br />
                <button id="Button1" runat="server" type="button" class="accordion btn btn-danger alignCenter" style="text-align: center" causesvalidation="false" autopostback="false">Journey Details</button>
        <div class="panel" style="width: 80%; margin-left: 10%; text-align: left">
                <br />
            <table onload="">
                    <tr>
                        <td>&nbsp;</td>
                        <td style="vertical-align: top; text-align: left;">
                            <span>
                                <b>Date of Journey:</b>
                                &nbsp;
                            <%#:Item.JourneyDate%>
                            </span>
                            <br />
                            <span>
                                <b>Duration of Journey:</b>
                                &nbsp;
                            <%#:Item.Duration%>
                            </span>
                            <br />
                            <span>
                                <b>Distance of Journey:</b>
                                &nbsp;
                            <%#:Item.DistanceOfJourney%>

                            </span>
                            <br />
                            <span>
                                <b>Description:</b>
                                &nbsp;
                            <%#:Item.Description %>
                                <br />
                            </span>
                            <br />
                            <span>
                                <b>Departure Time:</b>
                                &nbsp;
                            <%#:Item.TimeOfJourney%>

                            </span>
                            <br />
                            <br />
                            <span>
                                <b>Seats  Available in Car:</b>
                                &nbsp;
                            <%#:Item.SeatsAvailable%>

                            </span>

                            <span>
                                <b>Price:</b>
                                &nbsp;
                            <%#: String.Format("{0:c}", Item.JourneyPrice) %>
                            </span>
                            <br />
                            <br />
                            <br />
                            <span>
                                <h2><b>Drivers Preferences:</b></h2>
                                <br />
                                <h4><span><%#:Item.SmokingPreference%></span></h4>
                                <h4><span><%#:Item.MusicPreference  %></span></h4>
                                <h4><span><%#:Item.AnimalPreference%></span></h4>
                            </span>
                            <br />
                            <span>
                                <br />
                            </span>
                            <br />
                        </td>
                    </tr>
                </table>
                  </div>
    </div>

            </ItemTemplate>

        </asp:FormView>

                                <div id="map" class="center-block" style="max-width: 400px; height: 400px; background: yellow"></div>

    <br />
    <div class="alignCenter">
        <button id="Driver_Button" runat="server" type="button" class="accordion btn btn-danger alignCenter" style="text-align: center" causesvalidation="false" autopostback="false">About the Driver</button>
        <div class="panel" style="width: 80%; margin-left: 10%; text-align: left">
            <asp:FormView ID="journeyDetailsUser" runat="server"
                ItemType="SE_TeamZephyr.Models.ApplicationUser" SelectMethod="GetUser">

                <ItemTemplate>
                    <div>
                        <span>

                            <%--<h2><b>About the Driver:</b></h2>--%>

                            <br />
                            <span>&nbsp; <b>Driver Name :</b> <%#:Item.FirstName%> <%#:Item.LastName%> </span>
                            <br />
                            <span>&nbsp; <b>Driver Email/Username :</b> <%#:Item.UserName%></span>
                            <br />
                            <span>&nbsp; <b>About the Driver :</b> <%#:Item.Biography%></span>
                    </div>
                </ItemTemplate>
            </asp:FormView>
        </div>
    </div>
    <%-- END OF ACCORDION DIV --%>

    <div class="alignCenter">
        <button id="Drivers_Car" runat="server" type="button" class="accordion btn btn-danger alignCenter" style="text-align: center" causesvalidation="false" autopostback="false">Drivers Car</button>
        <div class="panel" style="width: 80%; margin-left: 10%; text-align: left">
                <br />
            <asp:FormView ID="FormView1" runat="server"
                ItemType="SE_TeamZephyr.Models.Vehicle" SelectMethod="GetVehicle">
                <ItemTemplate>
                    <div>
                        <h2><b>Drivers Car</b></h2>

                        <br />

                        <span><b></b>&nbsp; Make : <%#:Item.Make%></span>
                        <br />
                        <span><b></b>&nbsp; Colour : <%#:Item.Colour%></span>
                        <br />
                        <span><b></b>&nbsp; Model : <%#:Item.Model%></span>
                        <br />
                        <span><b></b>&nbsp; Fuel Type : <%#:Item.FuelType%></span>
                        <br />
                        <span><b></b>&nbsp; C02 emissions per gallon : <%#:Item.Co2EmissionsPerGallon%></span>
                        <br />
                        <span><b></b>&nbsp; Litres Per Kilometer : <%#:Item.LitresPerKilometer%></span>
                    </div>
                </ItemTemplate>
            </asp:FormView>
        </div>
    </div>
    <br />
        <center>
    <h2>Your Details:</h2> 
        </center>

        <center>
    <asp:Label ID="pickuppointlabel" runat="server" Text="Pickup Point:" />
    </center>
    <br />
        <center>
    <asp:TextBox ID="PickupPoint"  style = "color:black" runat="server" placeholder="Pickup Point"></asp:TextBox>
        </center>
    <asp:RequiredFieldValidator runat="server" ControlToValidate="PickupPoint"
        CssClass="text-danger" ErrorMessage="The pickup point field is required." />

    <br />

    <br />

        <center>
    <asp:Label ID="PickupPointPostcodeLabel" runat="server"  Text="Enter Postcode" />
     </center>
    <br />
        <center>
    <asp:TextBox ID="PickupPointPostcode" runat="server" Placeholder="eg. BT3 5JH" style = "color:black" ></asp:TextBox>
    </center><asp:RequiredFieldValidator runat="server" ControlToValidate="PickupPointPostcode"
        CssClass="text-danger" ErrorMessage="The pickup point postcode field is required." />
    <asp:RegularExpressionValidator ID="RegularExpressionValidator2"
        ControlToValidate="PickupPointPostcode"
        ValidationExpression="^([A-PR-UWYZ]([0-9]{1,2}|([A-HK-Y][0-9]|[A-HK-Y][0-9]([0-9]|[ABEHMNPRV-Y]))|[0-9][A-HJKS-UW])\ [0-9][ABD-HJLNP-UW-Z]{2}|(GIR\ 0AA)|(SAN\ TA1)|(BFPO\ (C\/O\ )?[0-9]{1,4})|((ASCN|BBND|[BFS]IQQ|PCRN|STHL|TDCU|TKCA)\ 1ZZ))$"
        ErrorMessage="Enter valid PostCode using Capitals"
        runat="server" />
        <br />
    <br />
        <center>
    <asp:Button class="btn-warning" ID="RequestRide" runat="server" Text="Request Ride" OnClick="RequestRide_Click" />
    </center>
        <br />
    <asp:Label ID="RequestRideError" runat="server" Text="" ForeColor="Red" Font-Size="Large" Font-Bold="True"></asp:Label>
    <asp:Label ID="RequestRideSuccess" runat="server" Text="" ForeColor="Green" Font-Size="Large" Font-Bold="True"></asp:Label>

    <%-- ------------------------------------------------------------------------------------------------------------------------------------------ --%>

    <%-- ------------------------------------------------------------------------------------------------------------------------------------------ --%>


    <script>
        window.onload = mapLocation();
        
        function mapLocation() {
            var directionsDisplay;
            var directionsService = new google.maps.DirectionsService();
            var map;

            function initialize() {
                directionsDisplay = new google.maps.DirectionsRenderer();
                var ni = new google.maps.LatLng(54.787715, -6.492315);
                var mapOptions = {
                    zoom: 7,
                    center: ni
                };
                map = new google.maps.Map(document.getElementById('map'), mapOptions);
                directionsDisplay.setMap(map);
                calcRoute();
            }

            function calcRoute() {
                var waypointarray = new Array(); 
                var waypoints = JSON.parse("<%= WaypointLatLongs%>");
                for(var i = 0; i< waypoints.length; i++){
                    waypointarray.push({location: new google.maps.LatLng(waypoints[i][0], waypoints[i][1]), stopover: false});    
                }
                var start = new google.maps.LatLng(<%= DepartureLatitude %>, <%= DepartureLongitude %>);
                var end = new google.maps.LatLng(<%= DestinationLatitude %>, <%= DestinationLongitude %>);
                var bounds = new google.maps.LatLngBounds();
                bounds.extend(start);
                bounds.extend(end);
                map.fitBounds(bounds);
                var request = {
                    origin: start,
                    destination: end,
                    waypoints: waypointarray,
                    optimizeWaypoints: true,
                    travelMode: google.maps.TravelMode.DRIVING
                };
                directionsService.route(request, function (response, status) {
                    if (status == google.maps.DirectionsStatus.OK) {
                        directionsDisplay.setDirections(response);
                        directionsDisplay.setMap(map);
                    } else {
                        alert("Directions Request from " + start.toUrlValue(6) + " to " + end.toUrlValue(6) + " failed: " + status);
                    }
                });
            }

            google.maps.event.addDomListener(window, 'load', initialize);
        }
    </script>
    <script src="https://maps.googleapis.com/maps/api/js?key=AIzaSyC1HpXgAeVvymdCzenGMpu1xTHIR5Wy94U&callback=mapLocation"></script>

    <%--            <%-- STYLE SHEETS AND JAVASCRIPT FOR DETAILS PAGE --%>
    <script src="../../scripts/accordionscript/accordionscript.js"></script>
    <link href="../../content/pagespecificstyles/accordionstyle.css" rel="stylesheet" />
</asp:Content>
