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
    public class JourneyPassengerService : IJourneyPassengerService
    {
        public void createJourneyPassenger(int journeyID, string passengerID, string pickupPoint, string pickupPointPostcode, Journey journey)
        {
            using (Autom8DBAppContext11 DBContext = new Autom8DBAppContext11())
            {
                JourneyPassenger journeyPassenger = new JourneyPassenger()
                {
                    JourneyPassengerID = 1,
                    JourneyID = journeyID,
                    passengerID = passengerID,
                    pickupPoint = pickupPoint,
                    pickupPointPostcode = pickupPointPostcode,
                    pending = true,
                    accepted = false
                };
                DBContext.JourneyPassengers.Add(journeyPassenger);
                DBContext.SaveChanges();
            }
        }

        public JourneyPassenger retrieveJourneyPassenger(int JourneyPassengerID)
        {
            using (Autom8DBAppContext11 DBContext = new Autom8DBAppContext11())
            {
                var journeyPassenger = DBContext.JourneyPassengers.Where(a => a.JourneyPassengerID == JourneyPassengerID).FirstOrDefault();
                if (journeyPassenger == new JourneyPassenger())
                {
                    throw new Exception();
                }
                return journeyPassenger;
            }
        }

        public List<JourneyPassenger> retrieveAllJourneyPassengers()
        {
            using (Autom8DBAppContext11 DBContext = new Autom8DBAppContext11())
            {
                var journeyPassengers = DBContext.JourneyPassengers.ToList();
                if (journeyPassengers.Count > 0)
                {
                    return journeyPassengers;
                }
                return new List<JourneyPassenger>();
            }
        }

        public void updateJourneyPassenger(int journeyPassengerID, bool pending, bool accepted)
        {
            using (Autom8DBAppContext11 DBContext = new Autom8DBAppContext11())
            {
                var existingJourneyPassenger = DBContext.JourneyPassengers.Single(a => a.JourneyPassengerID == journeyPassengerID);
                existingJourneyPassenger.pending = pending;
                existingJourneyPassenger.accepted = accepted;
                DBContext.SaveChanges();
            }
        }

        public void deleteJourneyPassenger(int journeyPassengerID)
        {
            using (Autom8DBAppContext11 DBContext = new Autom8DBAppContext11())
            {
                DBContext.JourneyPassengers.Remove(DBContext.JourneyPassengers.Where(a => a.JourneyPassengerID == journeyPassengerID).First());
                DBContext.SaveChanges();
            }
        }
    }
}
