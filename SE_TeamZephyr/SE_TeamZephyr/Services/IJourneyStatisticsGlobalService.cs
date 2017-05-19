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
    public interface IJourneyStatisticsGlobalService
    {
        [OperationContract]
        void createJourneyStatisticsGlobal(int areaID, double totalDistance);
        [OperationContract]
        void updateJourneyStatisticsGlobal(int journeyStatisticsID, double totalDistance);
        [OperationContract]
        void deleteJourneyStatisticsGlobal(int journeyStatisticsID);
        [OperationContract]
        List<JourneyStatisticsGlobal> retrieveAllJourneyStatisticsGlobal();

    }
}
