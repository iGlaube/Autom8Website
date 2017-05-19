using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SE_TeamZephyr.Models;
using System.Web.ModelBinding;
using SE_TeamZephyr.Services;
using System.Net;
using System.Xml.Linq;
using System.Web.Script.Serialization;
using System.IO;
using System.Xml;
using SE_TeamZephyr.Helpers;
using Microsoft.AspNet.Identity;

namespace SE_TeamZephyr
{
    public partial class JourneyDetails : System.Web.UI.Page
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
            Driver_Button.Attributes.Add("onclick", "return false;");
            JourneyService js = new JourneyService();
            GoogleMaps maps = new GoogleMaps();

            var journeyId = Int32.Parse(Request.QueryString["journeyId"]);
            var journey = js.retrieveJourney(journeyId);

            var departureLatLong = maps.latitudeLongitude(journey.OriginPostcode);
            var destinationLatLong = maps.latitudeLongitude(journey.DestinationPostcode);

            DepartureLatitude = departureLatLong[0];
            DepartureLongitude = departureLatLong[1];
            DestinationLatitude = destinationLatLong[0];
            DestinationLongitude = destinationLatLong[1];

            WaypointLatLongs = maps.getWaypoints(journey.OriginPostcode, journey.JourneyID);
        }

        public IQueryable<Journey> GetJourney([QueryString("journeyID")] int? journeyId)
        {
            var _db = new SE_TeamZephyr.Models.Autom8DBAppContext11();
            IQueryable<Journey> query = _db.Journeys;
            if (journeyId.HasValue && journeyId > 0)
            {
                query = query.Where(p => p.JourneyID == journeyId);
            }
            else
            {
                query = null;
            }
            return query;
        }

        public ApplicationUser GetUser([QueryString("journeyID")] int? journeyId)
        {
            AspNetUserService us = new AspNetUserService();
            JourneyService js = new JourneyService();
            var journey = js.retrieveJourney(journeyId.Value);
            var user = us.retrieveUser(journey.UserID);
            return user;
        }

        public Vehicle GetVehicle([QueryString("journeyID")] int? journeyId)
        {
            JourneyService js = new JourneyService();
            VehicleService vs = new VehicleService();

            var journey = js.retrieveJourney(journeyId.Value);
            var vehicle = vs.retrieveAllVehicles().Where(v => v.UserID == journey.UserID).First();
            return vehicle;
        }



        protected void RequestRide_Click(object sender, EventArgs e)
        {

            if (PickupPoint.Text == "" || PickupPointPostcode.Text == "")
            {
                RequestRideError.Text = "Please fill out all the required fields!";
                RequestRideSuccess.Text = "";
            }
            else if (Context.User.Identity.GetUserId() == null)
            {
                RequestRideError.Text = "You must be logged in to request a seat on a journey!";
                        RequestRideSuccess.Text = "";
            }
            else
            {
                JourneyService js = new JourneyService();
                AspNetUserService us = new AspNetUserService();
                JourneyPassengerService jps = new JourneyPassengerService();
                var journey = js.retrieveJourney(Int32.Parse(Request.QueryString["journeyId"]));
                var journeyOwner = us.retrieveUser(journey.UserID);
                var currentUserID = Context.User.Identity.GetUserId();
                var currentUser = us.retrieveUser(currentUserID);

                if (jps.retrieveAllJourneyPassengers().Where(jp => jp.JourneyID == journey.JourneyID && jp.accepted == true).ToList().Count == journey.SeatsAvailable)
                {
                    RequestRideError.Text = "This journey is currently full!";
                        RequestRideSuccess.Text = "";
                }
                else
                {
                    if (jps.retrieveAllJourneyPassengers().Where(jp => jp.JourneyID == journey.JourneyID && jp.passengerID == currentUserID && jp.pending == true).Count() > 0)
                    {
                        RequestRideError.Text = "You already have a request pending for this Journey!";
                        RequestRideSuccess.Text = "";
                    }
                    else if (jps.retrieveAllJourneyPassengers().Where(jp => jp.JourneyID == journey.JourneyID && jp.passengerID == currentUserID && jp.accepted == true).Count() > 0)
                    {
                        RequestRideError.Text = "You have already been accepted for this Journey!";
                        RequestRideSuccess.Text = "";
                    }
                    else
                    {
                        jps.createJourneyPassenger(journey.JourneyID, currentUserID, PickupPoint.Text, PickupPointPostcode.Text, journey);
                        RequestRideSuccess.Text = "Your request has been sent to the owner of this Journey!";
                        RequestRideError.Text = "";
                    }
                    SendMail(journeyOwner, currentUser);
                }
            }
        }

        protected void SendMail(ApplicationUser journeyOwner, ApplicationUser currentUser)
        {
            // Gmail Address from where you send the mail
            var fromAddress = "qubse16@gmail.com";
            //Password of your gmail address
            const string fromPassword = "TeamZephyr1";
            // Passing the values and make a email formate to display
            string subject = "Passenger Request - Autom8";
            string text1 = "You have a new passenger request" + "\n";
            string text2 = "Hello, you have received a request on your account. " + "\n";
            string text3 = "Please log in to accept or reject your passenger - The Autom8 Team " + "\n" + "\n";
            string text4 = "Your request is shown below: " + "\n" + "\n";
            string body = text1 + text2 + text3 + text4;
            string content = "";
            body += "Passenger Request from: " + currentUser.UserName + "\n" + "This passenger would like picked up from" + "\n" + PickupPoint.Text + ", " + PickupPointPostcode.Text + "\n";

            // smtp settings
            var smtp = new System.Net.Mail.SmtpClient();
            {
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.EnableSsl = true;
                smtp.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
                smtp.Credentials = new NetworkCredential(fromAddress, fromPassword);
                smtp.Timeout = 20000;
            }
            // Passing values to smtp object
            smtp.Send(fromAddress, journeyOwner.Email, subject, body);
        }

        public void test(string url)
        {
            var bla = url;
        }

        //public string GetImage(byte[] image)
        //{
        //    string convertedString = Convert.ToBase64String(image, 0, image.Length);
        //    return "data:image/jpg;base64," + convertedString;
        //}
        protected void journeyDetailsUser_PageIndexChanging(object sender, FormViewPageEventArgs e)
        {

        }
    }
}