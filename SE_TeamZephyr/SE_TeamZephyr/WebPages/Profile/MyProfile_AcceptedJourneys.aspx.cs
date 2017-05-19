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
    public partial class MyProfile_AcceptedJourneys : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        //Need to add checks for time after changing journey to take datetime

        public List<JourneyPassenger> PayedJourneys()
        {
            var currentUser = Context.User.Identity.GetUserId();
            JourneyPassengerService jps = new JourneyPassengerService();
            PayPalOrderDetailsService os = new PayPalOrderDetailsService();
            JourneyService js = new JourneyService();
            AspNetUserService us = new AspNetUserService();
            var allOrderDetails = os.retrieveAllPayPalOrderDetailss();
            var otherJourneys = jps.retrieveAllJourneyPassengers().Where(jp => jp.passengerID == currentUser && jp.pending == false && jp.accepted == true).ToList();
            List<JourneyPassenger> finalList = new List<JourneyPassenger>();
            for (int i = 0; i < otherJourneys.Count; i++)
            {
                if (allOrderDetails.Where(a => a.JourneyID == otherJourneys[i].JourneyID && a.Username == us.retrieveUser(otherJourneys[i].passengerID).UserName && DateTime.Parse(js.retrieveJourney(a.JourneyID).JourneyDate) > DateTime.Now).ToList().Count > 0)
                {
                    finalList.Add(otherJourneys[i]);
                }
            }

            if (finalList.Count > 0)
            {
                return finalList;
            }
            return new List<JourneyPassenger>();
        }

        public List<JourneyPassenger> PendingPayments()
        {
            var currentUser = Context.User.Identity.GetUserId();
            JourneyPassengerService jps = new JourneyPassengerService();
            PayPalOrderDetailsService os = new PayPalOrderDetailsService();
            AspNetUserService us = new AspNetUserService();
            var allOrderDetails = os.retrieveAllPayPalOrderDetailss();
            var otherJourneys = jps.retrieveAllJourneyPassengers().Where(jp => jp.passengerID == currentUser && jp.pending == false && jp.accepted == true).ToList();
            List<JourneyPassenger> finalList = new List<JourneyPassenger>();
            for (int i = 0; i < otherJourneys.Count; i++)
            {
                if (allOrderDetails.Where(a => a.JourneyID == otherJourneys[i].JourneyID && a.Username == us.retrieveUser(otherJourneys[i].passengerID).UserName).ToList().Count == 0)
                {
                    finalList.Add(otherJourneys[i]);
                }
            }
            if (finalList.Count > 0)
            {
                return finalList;
            }
            return new List<JourneyPassenger>();
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


        protected string GetJourneyDate(int journeyID)
        {
            JourneyService js = new JourneyService();


            var journey = js.retrieveJourney(journeyID);

            return journey.JourneyDate;

        }

        protected string GetJourneyTime(int journeyID)
        {
            JourneyService js = new JourneyService();


            var journey = js.retrieveJourney(journeyID);

            return journey.TimeOfJourney;

        }

        protected string GetJourneyOwnerEmail(int journeyID)
        {
            AspNetUserService us = new AspNetUserService();
            JourneyService js = new JourneyService();
            var ownerName = us.retrieveUser(js.retrieveJourney(journeyID).UserID).UserName;

            return ownerName;
            //return ownerName.FirstName + " " + ownerName.LastName;



        }


        protected string GetJourneyOwnerName(int journeyID)
        {
            AspNetUserService us = new AspNetUserService();
            JourneyService js = new JourneyService();
            var ownerName = us.retrieveUser(js.retrieveJourney(journeyID).UserID).FirstName;
            var ownerName2 = us.retrieveUser(js.retrieveJourney(journeyID).UserID).LastName;

            return ownerName + " " + ownerName2;
            //return ownerName.FirstName + " " + ownerName.LastName;



        }



        protected string GetJourneyName(int journeyID)
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

        protected void acceptedJourneys_ItemDataBound(object sender, ListViewCommandEventArgs e)
        {
            JourneyPassengerService jps = new JourneyPassengerService();
            JourneyService js = new JourneyService();


            if (e.CommandName == "Paypal")
            {
                var journeyPassenger = jps.retrieveJourneyPassenger(Int32.Parse(e.CommandArgument.ToString()));
                var journey = js.retrieveJourney(journeyPassenger.JourneyID);

                Response.Redirect("../Basket/AddToBasket.aspx?journeyID=<%#:Item.JourneyID %>");
            }
        }

        public List<Journey> CompletedJourneys()
        {
            var currentUser = Context.User.Identity.GetUserId();
            JourneyService js = new JourneyService();
            JourneyPassengerService jps = new JourneyPassengerService();
            var journeyPassengerEntries = jps.retrieveAllJourneyPassengers().Where(jp => jp.passengerID == currentUser).ToList();
            List<Journey> completedJourneys = new List<Journey>();

            for(int i = 0; i < journeyPassengerEntries.Count; i++)
            {
                var currentJourney = js.retrieveJourney(journeyPassengerEntries[i].JourneyID);
                if (currentJourney.Completed)
                {
                    completedJourneys.Add(currentJourney);
                }
            }

            if (completedJourneys.Count > 0)
            {
                return completedJourneys;
            }
            return new List<Journey>();
        }
    }
}