using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using SE_TeamZephyr.Models;

namespace SE_TeamZephyr.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Journey" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Journey.svc or Journey.svc.cs at the Solution Explorer and start debugging.
    public class JourneyService : IJourneyService
    {
        public void createJourney(string UserID, int AreaID, string JourneyName, string JourneyDescription, double JourneyPrice, string Duration, string Distance, string JourneyDate, int SeatsAvailable, string TimeOfJourney, string Smoking, string Music, string Animal, string originPostcode, string destinationPostcode)
        {
            using (Autom8DBAppContext11 DBContext = new Autom8DBAppContext11())
            {
                Journey journey = new Journey()
                {
                    UserID = UserID,
                    AreaID = AreaID,
                    JourneyName = JourneyName,
                    Description = JourneyDescription,
                    JourneyDate = JourneyDate,
                    JourneyPrice = JourneyPrice,
                    Duration = Duration,
                    DistanceOfJourney = Distance,
                    SeatsAvailable = SeatsAvailable,
                    TimeOfJourney = TimeOfJourney,
                    SmokingPreference = Smoking,
                    MusicPreference = Music,
                    AnimalPreference = Animal,
                    OriginPostcode = originPostcode,
                    DestinationPostcode = destinationPostcode,
                    Completed = false
                };
                DBContext.Journeys.Add(journey);
                DBContext.SaveChanges();
            }
        }

        public Journey retrieveJourney(int journeyID)
        {
            using (Autom8DBAppContext11 DBContext = new Autom8DBAppContext11())
            {
                var journey = DBContext.Journeys.Where(j => j.JourneyID == journeyID).FirstOrDefault();
                if (journey == new Journey())
                {
                    throw new Exception();
                }
                return journey;
            }
        }

        public List<Journey> retrieveAllJourneys()
        {
            using (Autom8DBAppContext11 DBContext = new Autom8DBAppContext11())
            {
                var journeys = DBContext.Journeys.ToList();
                if (journeys.Count > 0)
                {
                    return journeys;
                }
                return new List<Journey>();
            }
        }

        public void updateJourney(int JourneyID, string UserID, int AreaID, string JourneyName, string JourneyDescription, double JourneyPrice, string JourneyDate, int SeatsAvailable, string TimeOfJourney, string Smoking, string Music, string Animal)
        {
            using (Autom8DBAppContext11 DBContext = new Autom8DBAppContext11())
            {
                var existingJourney = DBContext.Journeys.Single(j => j.JourneyID == JourneyID);
                existingJourney.UserID = UserID;
                existingJourney.AreaID = AreaID;
                existingJourney.JourneyName = JourneyName;
                existingJourney.Description = JourneyDescription;
                existingJourney.JourneyPrice = JourneyPrice;
                existingJourney.JourneyDate = JourneyDate;
                existingJourney.SeatsAvailable = SeatsAvailable;
                existingJourney.TimeOfJourney = TimeOfJourney;
                existingJourney.SmokingPreference = Smoking;
                existingJourney.MusicPreference = Music;
                existingJourney.AnimalPreference = Animal;
                DBContext.SaveChanges();
            }
        }

        public void confirmJourney(int JourneyID)
        {
            using (Autom8DBAppContext11 DBContext = new Autom8DBAppContext11())
            {
                var existingJourney = DBContext.Journeys.Single(j => j.JourneyID == JourneyID);
                existingJourney.Completed = true;
                DBContext.SaveChanges();
            }
        }

        public void denyJourney(int JourneyID)
        {
            using (Autom8DBAppContext11 DBContext = new Autom8DBAppContext11())
            {
                var existingJourney = DBContext.Journeys.Single(j => j.JourneyID == JourneyID);
                existingJourney.Completed = false;
                DBContext.SaveChanges();
            }
        }

        public void deleteJourney(int journeyID)
        {
            using (Autom8DBAppContext11 DBContext = new Autom8DBAppContext11())
            {
                DBContext.Journeys.Remove(DBContext.Journeys.Where(j => j.JourneyID == journeyID).First());
                DBContext.SaveChanges();
            }
        }

        public List<Journey> searchJourneys(string search)
        {
            using (Autom8DBAppContext11 DBContext = new Autom8DBAppContext11())
            {
                var journeys = DBContext.Journeys.Where(j =>
                    j.AnimalPreference.Contains(search) ||
                    j.Area.AreaName.Contains(search) ||
                    j.Description.Contains(search) ||
                    j.DistanceOfJourney.Contains(search) ||
                    j.JourneyDate.Contains(search) ||
                    j.JourneyName.Contains(search) ||
                    j.TimeOfJourney.Contains(search) ||
                    j.MusicPreference.Contains(search) ||
                    j.SmokingPreference.Contains(search) ||
                    j.Duration.Contains(search) ||
                    j.TimeOfJourney.Contains(search) ||
                    j.OriginPostcode.Contains(search) ||
                    j.DestinationPostcode.Contains(search)
                ).ToList();



                if (journeys.Count > 0)
                {
                    return journeys;
                }
                return new List<Journey>();
            }
        }
    }
}
