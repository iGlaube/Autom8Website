using SE_TeamZephyr.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SE_TeamZephyr.Services
{
    [ServiceContract]
    public interface IJourneyStatisticsAllService
    {
        [OperationContract]
        void createJourneyStatisticsAll(string name, double totalDistance);
        [OperationContract]
        void updateJourneyStatisticsAll(int journeyStatisticsID, double totalDistance);
        [OperationContract]
        void deleteJourneyStatisticsAll(int journeyStatisticsID);
        [OperationContract]
        List<JourneyStatisticsAll> retrieveAllJourneyStatisticsAll();
    }
}

