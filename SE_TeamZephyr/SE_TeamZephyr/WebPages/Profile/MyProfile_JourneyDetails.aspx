<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MyProfile_JourneyDetails.aspx.cs" Inherits="SE_TeamZephyr.WebPages.Profile.MyProfile_JourneyDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">


    <asp:FormView ID="journeyDetail" runat="server"
        ItemType="SE_TeamZephyr.Models.Journey" SelectMethod="GetJourney"
        RenderOuterTable="false">
        <ItemTemplate>
            <div>
                <h1><%#:Item.JourneyName %></h1>
                    <h4>Click below to find out more!</h4>
            </div>
            <br />
                <div class="alignCenter">
        <button id="JourneyDetails" runat="server" type="button" class="accordion btn btn-danger alignCenter" style="text-align: center" causesvalidation="false" autopostback="false">Journey Details</button>
        <div class="panel" style="width: 80%; margin-left: 10%; text-align: left">
                <br />
            <table onload="">
                <tr>
                    <td>&nbsp;</td>
                    <td style="vertical-align: top; text-align: left;">
                        <b>Description:</b>
                        <br />
                        <%#:Item.Description %>
                        <br />
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
                        <br />
                        <span>
                            <b>Date of Journey:</b>
                            &nbsp;
                            <%#:Item.JourneyDate%>

                        </span>
                        <br />
                        <br />
                        <span>
                            <b>Departure Time:</b>
                            &nbsp;
                            <%#:Item.TimeOfJourney%>

                        </span>
                        <br />

                        <span>
                            <b>Price:</b>
                            &nbsp;
                            <%#: String.Format("{0:c}", Item.JourneyPrice) %>
                        </span>
                        <br />
                        <span>
                            <b>Seats  Available in Car:</b>
                            &nbsp;
                            <%#:Item.SeatsAvailable%>

                        </span>
                        <br />
                        <br />
                        <span>
                            <h2><b>Drivers Preferences:</b></h2>
                            <br />
                            <h4><span><%#:Item.SmokingPreference%></span></h4>
                            <h4><span><%#:Item.MusicPreference  %></span></h4>
                            <h4><span><%#:Item.AnimalPreference%></span></h4>
                            <br /></td>
                </tr>
            </table>
                    </div>
    </div>
        </ItemTemplate>

    </asp:FormView>
    <center>
                                <div id="map" style="width: 400px; height: 400px; background: yellow"></div>
        </center>
    <div class="alignCenter">
        <button id="Passengers" runat="server" type="button" class="accordion btn btn-danger alignCenter" style="text-align: center" causesvalidation="false" autopostback="false">Passengers</button>
        <div class="panel" style="width: 80%; margin-left: 10%; text-align: left"> 
                <br />
            <asp:ListView ID="journeyPassengerDetail" runat="server"
        ItemType="SE_TeamZephyr.Models.JourneyPassenger" SelectMethod="GetJourneyPassengers"
        RenderOuterTable="false">
        <ItemTemplate>
            <div><b>PassengerID:</b><%# Item.passengerID %></div>
            <br />
            <div><b>pickupPoint:</b><%# Item.pickupPoint %></div>
            <br />
            <div><b>pickupPointPostcode:</b><%# Item.pickupPointPostcode %></div>
            <br />
            <div><b>passengername:</b><%# getJourneyPassengerName(Item.passengerID) %></div>
            <br />
            <div><b>passengeremail:</b><%# getJourneyPassengerEmail(Item.passengerID) %></div>
            <br />
            <br />
        </ItemTemplate>
    </asp:ListView>
        </div>
    </div>

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
                var waypoints = JSON.parse("<%=WaypointLatLongs%>");
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
