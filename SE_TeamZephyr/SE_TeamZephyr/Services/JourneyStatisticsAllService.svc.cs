using SE_TeamZephyr.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SE_TeamZephyr.Services
{
    public class JourneyStatisticsAllService : IJourneyStatisticsAllService
    {
        public void createJourneyStatisticsAll(string name, double totalDistance)
        {
            using (Autom8DBAppContext11 DBContext = new Autom8DBAppContext11())
            {
                JourneyStatisticsAll jdsa = new JourneyStatisticsAll()
                {
                    Name = name,
                    TotalJourneys = 1,
                    TotalDistance = totalDistance

                };
                DBContext.JourneyStatisticsAll.Add(jdsa);
                DBContext.SaveChanges();
            }
        }

        public void deleteJourneyStatisticsAll(int journeyStatisticsID)
        {
            using (Autom8DBAppContext11 DBContext = new Autom8DBAppContext11())
            {
                DBContext.JourneyStatisticsAll.Remove(DBContext.JourneyStatisticsAll.Where(a => a.JourneyStatisticsID == journeyStatisticsID).First());
                DBContext.SaveChanges();
            }
        }


        public List<JourneyStatisticsAll> retrieveAllJourneyStatisticsAll()
        {
            using (Autom8DBAppContext11 DBContext = new Autom8DBAppContext11())
            {
                var journeyDetails = DBContext.JourneyStatisticsAll.ToList();
                if (journeyDetails.Count > 0)
                {
                    return journeyDetails;
                }
                return new List<JourneyStatisticsAll>();
            }
        }
        public void updateJourneyStatisticsAll(int journeyStatisticsID, double totalDistance)
        {
            using (Autom8DBAppContext11 DBContext = new Autom8DBAppContext11())
            {
                var existingStatistics = DBContext.JourneyStatisticsAll.Single(a => a.JourneyStatisticsID == journeyStatisticsID);
                existingStatistics.TotalJourneys += 1;
                existingStatistics.TotalDistance = totalDistance; 
                DBContext.SaveChanges();
            }
        }

    }
}
