using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using SE_TeamZephyr.Models;

namespace SE_TeamZephyr.Services
{
    [ServiceContract]
    interface IJourneyStatisticsService
    {
        [OperationContract]
        void createJourneyStatistics(string userID, double totalDistanceTraveled, double distanceAsDriver, double distanceAsPassenger, double fuelCost);
        [OperationContract]
        void updateJourneyStatistics(int journeyStatisticsID, double totalDistanceTraveled, double distanceAsDriver, double distanceAsPassenger, double fuelCost);
        [OperationContract]
        void deleteJourneyStatistics(int journeyStatisticsID);
        [OperationContract]
        double retrieveTotalDistanceTravelled(string userID);
        [OperationContract]
        double retrieveDistanceAsDriver(string userID);
        [OperationContract]
        double retrieveDistanceAsPassenger(string userID);
        [OperationContract]
        double retrieveFuelCost(string userID);
        [OperationContract]
        int retrieveTotalJourneys(string userID);
        [OperationContract]
        List<JourneyStatistics> retrieveAllJourneyDetails();
    }
}
