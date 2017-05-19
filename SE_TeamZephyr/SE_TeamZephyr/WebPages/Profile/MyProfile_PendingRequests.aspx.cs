using Microsoft.AspNet.Identity;
using SE_TeamZephyr.Logic;
using SE_TeamZephyr.Models;
using SE_TeamZephyr.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SE_TeamZephyr.WebPages.Profile
{
    public partial class MyProfile_PendingRequests : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        public List<JourneyPassenger> MyJourneys()
        {
            var currentUser = Context.User.Identity.GetUserId();
            JourneyPassengerService jps = new JourneyPassengerService();
            JourneyService js = new JourneyService();
            var otherJourneys = jps.retrieveAllJourneyPassengers().Where(jp => js.retrieveJourney(jp.JourneyID).UserID == currentUser && jp.pending == true && jp.accepted == false).ToList();
            if (otherJourneys.Count > 0)
            {
                return otherJourneys;
            }
            return new List<JourneyPassenger>();
        }


        protected  string GetJourneyName(int journeyID)
        {
            JourneyService js = new JourneyService();
          
       
            var journey = js.retrieveJourney(journeyID);
        
           return journey.JourneyName;

    }

        protected string GetPassengerEmail(string passengerID)

    {
        AspNetUserService us = new AspNetUserService();
        var passengerName = us.retrieveUser(passengerID.ToString());

        return passengerName.Email;


       
    }

        protected string GetPassengerName(string passengerID)
        {
            AspNetUserService us = new AspNetUserService();
            var passengerName = us.retrieveUser(passengerID.ToString());

            return passengerName.FirstName + "" + passengerName.LastName;



        }


        protected string GetJourneyOwnerEmail(int journeyID)
        {
            AspNetUserService us = new AspNetUserService();
            JourneyService js = new JourneyService();
            var ownerName = us.retrieveUser(js.retrieveJourney(journeyID).UserID).UserName;

            return ownerName;
            //return ownerName.FirstName + " " + ownerName.LastName;



        }
            


        protected string GetJourneyDate(int journeyID)
        {
            JourneyService js = new JourneyService();


            var journey = js.retrieveJourney(journeyID);

            return journey.JourneyDate;

        }
        
    
        public List<JourneyPassenger> OtherJourneys()
        {
            var currentUser = Context.User.Identity.GetUserId();
            JourneyPassengerService jps = new JourneyPassengerService();
            var otherJourneys = jps.retrieveAllJourneyPassengers().Where(jp => jp.passengerID == currentUser && jp.pending == true && jp.accepted == false).ToList();
            if (otherJourneys.Count > 0)
            {
                return otherJourneys;
            }
            return new List<JourneyPassenger>();
        }


        protected void myJourneys_ItemDataBound(object sender, ListViewCommandEventArgs e)
        {
            JourneyPassengerService jps = new JourneyPassengerService();
            JourneyService js = new JourneyService();
            AspNetUserService us = new AspNetUserService();

            var currentJourney = js.retrieveJourney(jps.retrieveJourneyPassenger(Int32.Parse(e.CommandArgument.ToString())).JourneyID);

            if (e.CommandName == "Accept")
            {
                if (jps.retrieveAllJourneyPassengers().Where(jp => jp.JourneyID == currentJourney.JourneyID && jp.accepted == true).ToList().Count == currentJourney.SeatsAvailable)
                {
                    //PassengerRejected.Text = "All spaces for this Journey have been allocated";


                }
                else
                {
                    jps.updateJourneyPassenger(Int32.Parse(e.CommandArgument.ToString()), false, true);
                    var currentPassenger = jps.retrieveJourneyPassenger(Int32.Parse(e.CommandArgument.ToString())).passengerID;
                    //Pick up current passenger to send email to them

                    //PassengerAccepted.Text = "Passenger has been accepted";
                    SendMailAccept(us.retrieveUser(currentPassenger));
                    Response.Redirect("../Profile/MyProfile_PendingRequests.aspx");
                }
            }
            else
            {
                jps.updateJourneyPassenger(Int32.Parse(e.CommandArgument.ToString()), false, false);
                var currentPassenger = jps.retrieveJourneyPassenger(Int32.Parse(e.CommandArgument.ToString())).passengerID;
                //Pick up current passenger to send email to them

                //PassengerRejected.Text = "Passenger has been rejected";
                SendMailReject(us.retrieveUser(currentPassenger));
            }
        }

        protected void SendMailAccept(ApplicationUser user)
        {
            // Gmail Address from where you send the mail
            var fromAddress = "qubse16@gmail.com";
            //Password of your gmail address
            const string fromPassword = "TeamZephyr1";
            // Passing the values and make a email formate to display
            string subject = "Passenger Request Acceptance - Autom8";
            string text1 = "You have been accepted as a passenger" + "\n";

            string text2 = "Please log in to make payment to your driver. - The Autom8 Team " + "\n" + "\n";

            string body = text1 + text2;
            string content = body;

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
            smtp.Send(fromAddress, user.UserName, subject, body);
        }


        protected void SendMailReject(ApplicationUser user)
        {
            // Gmail Address from where you send the mail
            var fromAddress = "qubse16@gmail.com";
            //Password of your gmail address
            const string fromPassword = "TeamZephyr1";
            // Passing the values and make a email formate to display
            string subject = "Passenger Request Rejection - Autom8";
            string text1 = "Sorry, unfortunately the driver has rejected your passenger request" + "\n";

            string text2 = "Please log in to choose another journey - The Autom8 Team " + "\n" + "\n";

            string body = text1 + text2;
            string content = body;

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
            smtp.Send(fromAddress, user.UserName, subject, body);
        }
    }
}