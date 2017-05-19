using SE_TeamZephyr.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SE_TeamZephyr.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "JourneyPassengerService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select JourneyPassengerService.svc or JourneyPassengerService.svc.cs at the Solution Explorer and start debugging.
    public class JourneyStatisticsService : IJourneyStatisticsService

    { 
        //
        //CRUD OPERATIONS
        //

        public void createJourneyStatistics(string userID, double totalDistanceTraveled, double distanceAsDriver, double distanceAsPassenger, double fuelCost)
        {
            using (Autom8DBAppContext11 DBContext = new Autom8DBAppContext11())
            {
                JourneyStatistics jds = new JourneyStatistics()
                {
                    UserID = userID,
                    TotalDistanceTravelled = totalDistanceTraveled,
                    DistanceAsDriver = distanceAsDriver,
                    DistanceAsPassenger = distanceAsPassenger,
                    FuelCost = fuelCost,
                    TotalJourneys = 1
                };
                DBContext.JourneyStatistics.Add(jds);
                DBContext.SaveChanges();
            }
        }

        public JourneyStatistics retrieveJourneyDetails(int journeyStatisticsID)
        {
            using (Autom8DBAppContext11 DBContext = new Autom8DBAppContext11())
            {
                var journeyStatistics = DBContext.JourneyStatistics.Where(j => j.JourneyStatisticsID == journeyStatisticsID).FirstOrDefault();
                if (journeyStatistics == new JourneyStatistics())
                {
                    throw new Exception();
                }
                return journeyStatistics;
            }
        }

        public List<JourneyStatistics> retrieveAllJourneyDetails()
        {
            using (Autom8DBAppContext11 DBContext = new Autom8DBAppContext11())
            {
                var journeyDetails = DBContext.JourneyStatistics.ToList();
                if (journeyDetails.Count > 0)
                {
                    return journeyDetails;
                }
                return new List<JourneyStatistics>();
            }
        }

        public void updateJourneyStatistics(int journeyStatisticsID, double totalDistanceTraveled, double distanceAsDriver, double distanceAsPassenger, double fuelCost)
        {
            using (Autom8DBAppContext11 DBContext = new Autom8DBAppContext11())
            {
                var existingStatistics = DBContext.JourneyStatistics.Single(a => a.JourneyStatisticsID == journeyStatisticsID);
                existingStatistics.TotalDistanceTravelled += totalDistanceTraveled;
                existingStatistics.DistanceAsDriver += distanceAsDriver;
                existingStatistics.DistanceAsPassenger += distanceAsPassenger;
                existingStatistics.FuelCost += fuelCost;
                existingStatistics.TotalJourneys += 1;
                DBContext.SaveChanges();
            }
        }

        public void deleteJourneyStatistics(int journeyStatisticsID)
        {
            using (Autom8DBAppContext11 DBContext = new Autom8DBAppContext11())
            {
                DBContext.JourneyStatistics.Remove(DBContext.JourneyStatistics.Where(a => a.JourneyStatisticsID == journeyStatisticsID).First());
                DBContext.SaveChanges();
            }
        }

        //
        //GET STATS FOR INDIVIDUAL FIELD FOR SINGLE USER
        //
        public double retrieveTotalDistanceTravelled(string userID)
        {
            using (Autom8DBAppContext11 DBContext = new Autom8DBAppContext11())
            {
                var distance = DBContext.JourneyStatistics.Where(a => a.UserID == userID).FirstOrDefault();
                if (distance == new JourneyStatistics())
                {
                    throw new Exception();
                }
                return distance.TotalDistanceTravelled;
            }
        }

        public double retrieveDistanceAsDriver(string userID)
        {
            using (Autom8DBAppContext11 DBContext = new Autom8DBAppContext11())
            {
                var distance = DBContext.JourneyStatistics.Where(a => a.UserID == userID).FirstOrDefault();
                if (distance == new JourneyStatistics())
                {
                    throw new Exception();
                }
                return distance.DistanceAsDriver;
            }

        }

        public double retrieveDistanceAsPassenger(string userID)
        {
            using (Autom8DBAppContext11 DBContext = new Autom8DBAppContext11())
            {
                var distance = DBContext.JourneyStatistics.Where(a => a.UserID == userID).FirstOrDefault();
                if (distance == new JourneyStatistics())
                {
                    throw new Exception();
                }
                return distance.DistanceAsPassenger;
            }
        }

        public double retrieveFuelCost(string userID)
        {
            using (Autom8DBAppContext11 DBContext = new Autom8DBAppContext11())
            {
                var cost = DBContext.JourneyStatistics.Where(a => a.UserID == userID).FirstOrDefault();
                if (cost == new JourneyStatistics())
                {
                    throw new Exception();
                }
                return cost.FuelCost;
            }
        }

        public int retrieveTotalJourneys(string userID)
        {
            using (Autom8DBAppContext11 DBContext = new Autom8DBAppContext11())
            {
                var journeys = DBContext.JourneyStatistics.Where(a => a.UserID == userID).FirstOrDefault();
                if (journeys == new JourneyStatistics())
                {
                    throw new Exception();
                }
                return journeys.TotalJourneys;
            }

        }
   }
}


