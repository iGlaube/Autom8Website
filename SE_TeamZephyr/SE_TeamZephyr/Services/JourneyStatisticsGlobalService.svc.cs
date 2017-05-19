using SE_TeamZephyr.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SE_TeamZephyr.Services
{
    public class JourneyStatisticsGlobalService : IJourneyStatisticsGlobalService
    {
        //
        //CRUD OPERATIONS
        //
        public void createJourneyStatisticsGlobal(int area, double totalDistance)
        {
            using (Autom8DBAppContext11 DBContext = new Autom8DBAppContext11())
            {
                JourneyStatisticsGlobal jdsa = new JourneyStatisticsGlobal()
                {
                    AreaID = area,
                    TotalJourneys = 1,
                    TotalDistance = totalDistance

                };
                DBContext.JourneyStatisticsGlobal.Add(jdsa);
                DBContext.SaveChanges();
            }
        }

        public void deleteJourneyStatisticsGlobal(int journeyStatisticsID)
        {
            using (Autom8DBAppContext11 DBContext = new Autom8DBAppContext11())
            {
                DBContext.JourneyStatisticsGlobal.Remove(DBContext.JourneyStatisticsGlobal.Where(a => a.JourneyStatisticsID == journeyStatisticsID).First());
                DBContext.SaveChanges();
            }
        }


        public List<JourneyStatisticsGlobal> retrieveAllJourneyStatisticsGlobal()
        {
            using (Autom8DBAppContext11 DBContext = new Autom8DBAppContext11())
            {
                var journeyDetails = DBContext.JourneyStatisticsGlobal.ToList();
                if (journeyDetails.Count > 0)
                {
                    return journeyDetails;
                }
                return new List<JourneyStatisticsGlobal>();
            }
        }
        public void updateJourneyStatisticsGlobal(int journeyStatisticsID, double totalDistance)
        {
            using (Autom8DBAppContext11 DBContext = new Autom8DBAppContext11())
            {
                var existingStatistics = DBContext.JourneyStatisticsGlobal.Single(a => a.JourneyStatisticsID == journeyStatisticsID);
                existingStatistics.TotalJourneys += 1;
                existingStatistics.TotalDistance = totalDistance;
                DBContext.SaveChanges();
            }
        }
    }
}

