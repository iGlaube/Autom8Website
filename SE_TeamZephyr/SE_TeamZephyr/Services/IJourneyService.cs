using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using SE_TeamZephyr.Models;

namespace SE_TeamZephyr.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IJourney" in both code and config file together.
    [ServiceContract]
    public interface IJourneyService
    {
        [OperationContract]
        void createJourney(string UserID, int AreaID, string JourneyName, string JourneyDescription, double JourneyPrice, string Duration, string Distance, string JourneyDate, int SeatsAvailable, string TimeOfJourney, string Smoking, string Music, string Animal, string OriginPostcode, string DestinationPostcode);
        [OperationContract]
        Journey retrieveJourney(int journeyID);
        [OperationContract]
        List<Journey> retrieveAllJourneys();
        [OperationContract]
        void updateJourney(int JourneyID, string UserID, int AreaID, string JourneyName, string JourneyDescription, double JourneyPrice, string JourneyDate, int SeatsAvailable, string TimeOfJourney, string Smoking, string Music, string Animal);
        [OperationContract]
        void confirmJourney(int JourneyID);
        [OperationContract]
        void denyJourney(int JourneyID);
        [OperationContract]
        void deleteJourney(int journeyID);
        [OperationContract]
        List<Journey> searchJourneys(string search);
    }
}
