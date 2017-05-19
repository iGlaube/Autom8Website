using Microsoft.AspNet.Identity;
using SE_TeamZephyr.Helpers;
using SE_TeamZephyr.Models;
using SE_TeamZephyr.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SE_TeamZephyr.WebPages.Profile
{
    public partial class MyProfile_JourneyDetails : System.Web.UI.Page
    {

        private string departureLatitude;
        private string departureLongitude;
        private string destinationLatitude;
        private string destinationLongitude;
        private string waypointLatLongs;

        public string DepartureLatitude { get { return departureLatitude; } set { departureLatitude = value; } }
        public string DepartureLongitude { get { return departureLongitude; } set { departureLongitude = value; } }
        public string DestinationLatitude { get { return destinationLatitude; } set { destinationLatitude = value; } }
        public string DestinationLongitude { get { return destinationLongitude; } set { destinationLongitude = value; } }
        public string WaypointLatLongs { get { return waypointLatLongs; } set { waypointLatLongs = value; } }

        protected void Page_Load(object sender, EventArgs e)
        {
            int journeyId = Int32.Parse(Request.QueryString["journeyId"]);
            JourneyService js = new JourneyService();
            GoogleMaps maps = new GoogleMaps();
            var journey = js.retrieveJourney(journeyId);

            var departureLatLong = maps.latitudeLongitude(journey.OriginPostcode);
            var destinationLatLong = maps.latitudeLongitude(journey.DestinationPostcode);

            DepartureLatitude = departureLatLong[0];
            DepartureLongitude = departureLatLong[1];
            DestinationLatitude = destinationLatLong[0];
            DestinationLongitude = destinationLatLong[1];

            WaypointLatLongs = maps.getWaypoints(journey.OriginPostcode, journey.JourneyID);
        }

        public Journey GetJourney()
        {
            int journeyId = Int32.Parse(Request.QueryString["journeyId"]);
            JourneyService js = new JourneyService();
            return js.retrieveJourney(journeyId);
        }

        public string getJourneyPassengerName(string userId)
        {
            AspNetUserService us = new AspNetUserService();
            var user = us.retrieveUser(userId);
            return user.FirstName + " " + user.LastName;
        }

        public string getJourneyPassengerEmail(string userId)
        {
            AspNetUserService us = new AspNetUserService();
            var user = us.retrieveUser(userId);
            return user.UserName;
        }

        public List<JourneyPassenger> GetJourneyPassengers()
        {
            int journeyId = Int32.Parse(Request.QueryString["journeyId"]);
            var currentUser = Context.User.Identity.GetUserId();
            JourneyPassengerService jps = new JourneyPassengerService();
            PayPalOrderDetailsService os = new PayPalOrderDetailsService();
            AspNetUserService us = new AspNetUserService();
            var allOrderDetails = os.retrieveAllPayPalOrderDetailss();
            var otherJourneys = jps.retrieveAllJourneyPassengers().Where(jp => jp.JourneyID == journeyId && jp.pending == false && jp.accepted == true).ToList();
            List<JourneyPassenger> finalList = new List<JourneyPassenger>();
            for (int i = 0; i < otherJourneys.Count; i++)
            {
                if (allOrderDetails.Where(a => a.JourneyID == otherJourneys[i].JourneyID && a.Username == us.retrieveUser(otherJourneys[i].passengerID).UserName).ToList().Count > 0)
                {
                    finalList.Add(otherJourneys[i]);
                }
            }

            if (finalList.Count > 0)
            {
                return finalList;
            }
            else
            {
                return new List<JourneyPassenger>();
            }
        }
    }
}