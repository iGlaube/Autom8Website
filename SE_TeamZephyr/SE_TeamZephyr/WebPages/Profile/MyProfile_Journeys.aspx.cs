using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SE_TeamZephyr.Models;
using System.Web.ModelBinding;
using Microsoft.AspNet.Identity;
using Microsoft.Ajax.Utilities;
using SE_TeamZephyr.Services;
using System.Net;

namespace SE_TeamZephyr.Profile
{
    public partial class MyProfile_Journeys : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        //this will display all the journeys owned by the current logged in user. 
        public List<Journey> GetMyJourneys()
        {
            JourneyService js = new JourneyService();
            var journeys = js.retrieveAllJourneys();
            string userId = Context.User.Identity.GetUserId();
            if (userId != null)
            {
                journeys = journeys.Where(q => q.UserID == userId).ToList();
            }

            journeys = journeys.Where(j => DateTime.Parse(j.JourneyDate) > DateTime.Now).ToList();
            return journeys;
        }

        public List<Journey> PendingCompletion()
        {
            var currentUser = Context.User.Identity.GetUserId();
            JourneyService js = new JourneyService();
            var journeys = js.retrieveAllJourneys().Where(j => j.UserID == currentUser && j.Completed == false && DateTime.Parse(j.JourneyDate) < DateTime.Now).ToList();
            if (journeys.Count > 0)
            {
                return journeys;
            }
            return new List<Journey>();
        }

        protected void myJourneys_ItemDataBound(object sender, ListViewCommandEventArgs e)
        {
            JourneyService js = new JourneyService();
            PayPalOrderDetailsService os = new PayPalOrderDetailsService();
            JourneyPassengerService jps = new JourneyPassengerService();
            JourneyStatisticsService jss = new JourneyStatisticsService();
            JourneyStatisticsAllService jsas = new JourneyStatisticsAllService();
            JourneyStatisticsGlobalService jsgs = new JourneyStatisticsGlobalService();
            AspNetUserService us = new AspNetUserService();
            VehicleService vs = new VehicleService();
            AreaService areaservice = new AreaService();
            var currentUser = Context.User.Identity.GetUserId();
            var currentVehicle = vs.retrieveAllVehicles().Where(v => v.UserID == currentUser).First();
            var allOrderDetails = os.retrieveAllPayPalOrderDetailss();
            var journey = js.retrieveJourney(Int32.Parse(e.CommandArgument.ToString()));
            var initialJPList = jps.retrieveAllJourneyPassengers().Where(jp => jp.JourneyID == journey.JourneyID && jp.accepted == true).ToList();
            List<JourneyPassenger> journeyPassengers = new List<JourneyPassenger>();
            for (int i = 0; i < initialJPList.Count; i++)
            {
                if (allOrderDetails.Where(a => a.Username == us.retrieveUser(initialJPList[i].passengerID).UserName).ToList().Count > 0)
                {
                    journeyPassengers.Add(initialJPList[i]);
                }
            }
            if (e.CommandName == "Confirm")
            {
                js.confirmJourney(journey.JourneyID);

                if (journeyPassengers.Count > 0)
                {
                    var distance = double.Parse(journey.DistanceOfJourney.Replace(" km", string.Empty));
                    var fuelCostSavings = Helpers.Globals.FUEL_COST * distance * currentVehicle.LitresPerKilometer * journeyPassengers.Count;
                    var currentJourneyStatisticForDriver = jss.retrieveAllJourneyDetails().Where(jos => jos.UserID == journey.UserID).FirstOrDefault();
                    var currentJourneyStatisticForArea = jsgs.retrieveAllJourneyStatisticsGlobal().Where(jos => jos.AreaID == journey.AreaID).FirstOrDefault();
                    var currentJourneyStatisticForDriverInAll = jsas.retrieveAllJourneyStatisticsAll().Where(jos => jos.Name == us.retrieveUser(journey.UserID).FirstName + " " + us.retrieveUser(journey.UserID).LastName).FirstOrDefault();
                    var currentJourneyStatisticForAreaInAll = jsas.retrieveAllJourneyStatisticsAll().Where(jos => jos.Name == journey.UserID).FirstOrDefault();
                    if (currentJourneyStatisticForArea != null)
                    {
                        jsgs.updateJourneyStatisticsGlobal(currentJourneyStatisticForArea.JourneyStatisticsID, distance);
                        jsas.updateJourneyStatisticsAll(currentJourneyStatisticForAreaInAll.JourneyStatisticsID, distance);
                    }
                    else
                    {
                        jsgs.createJourneyStatisticsGlobal(journey.AreaID.Value, distance);
                        jsas.createJourneyStatisticsAll(areaservice.retrieveArea(journey.AreaID.Value).AreaName, distance);
                    }
                    if (currentJourneyStatisticForDriver != null)
                    {
                        jss.updateJourneyStatistics(currentJourneyStatisticForDriver.JourneyStatisticsID, distance, distance, 0, fuelCostSavings);
                        jsas.updateJourneyStatisticsAll(currentJourneyStatisticForDriverInAll.JourneyStatisticsID, distance);
                    }
                    else
                    {
                        jss.createJourneyStatistics(journey.UserID, distance, distance, 0, fuelCostSavings);
                        jsas.createJourneyStatisticsAll(us.retrieveUser(journey.UserID).FirstName + " " + us.retrieveUser(journey.UserID).LastName, distance);
                    }
                    for (int i = 0; i < journeyPassengers.Count; i++)
                    {
                        var currentJourneyStatisticForPassenger = jss.retrieveAllJourneyDetails().Where(jos => jos.UserID == journeyPassengers[i].passengerID).FirstOrDefault();
                        if (currentJourneyStatisticForPassenger != null)
                        {
                            jss.updateJourneyStatistics(currentJourneyStatisticForPassenger.JourneyStatisticsID, distance, 0, distance, fuelCostSavings);
                            jsas.updateJourneyStatisticsAll(currentJourneyStatisticForPassenger.JourneyStatisticsID, distance);
                        }
                        else
                        {
                            jss.createJourneyStatistics(journeyPassengers[i].passengerID, distance, 0, distance, fuelCostSavings);
                            jsas.createJourneyStatisticsAll(journeyPassengers[i].passengerID, distance);
                        }
                    }
                }
            }
            else
            {
                js.denyJourney(journey.JourneyID);
            }
        }
    }
}
