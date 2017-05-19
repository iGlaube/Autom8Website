using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using SE_TeamZephyr.Models;

namespace SE_TeamZephyr.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IAreaService" in both code and config file together.
    [ServiceContract]
    public interface IAreaService
    {
        [OperationContract]
        void createArea(string areaName, string description);
        [OperationContract]
        Area retrieveArea(int areaID);
        [OperationContract]
        List<Area> retrieveAllAreas();
        [OperationContract]
        void updateArea(int areaID, string areaName, string description);
        [OperationContract]
        void deleteArea(int areaID);
    }
}
