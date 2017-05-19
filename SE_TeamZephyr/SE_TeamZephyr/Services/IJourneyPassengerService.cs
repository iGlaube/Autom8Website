using SE_TeamZephyr.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SE_TeamZephyr.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IJourneyPassengerService" in both code and config file together.
    [ServiceContract]
    public interface IJourneyPassengerService
    {
        [OperationContract]
        void createJourneyPassenger(int journeyID, string passengerID, string pickupPoint, string pickupPointPostcode, Journey journey);
        [OperationContract]
        JourneyPassenger retrieveJourneyPassenger(int JourneyPassengerID);
        [OperationContract]
        List<JourneyPassenger> retrieveAllJourneyPassengers();
        [OperationContract]
        void updateJourneyPassenger(int journeyPassengerID, bool pending, bool accepted);
        [OperationContract]
        void deleteJourneyPassenger(int journeyPassengerID);
    }
}
