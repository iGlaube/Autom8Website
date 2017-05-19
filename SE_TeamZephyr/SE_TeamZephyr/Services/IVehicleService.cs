using SE_TeamZephyr.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SE_TeamZephyr.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IVehicleService" in both code and config file together.
    [ServiceContract]
    public interface IVehicleService
    {
        [OperationContract]
        void createVehicle(string UserID, string Colour, string Model, string Make, string Vrm, string FuelType, double Co2EmissionsPerGallon, double LitresPerKilometer, int NumberOfSeats);

        [OperationContract]
        Vehicle retrieveVehicle(int VehicleID);

        [OperationContract]
        Vehicle retrieveVehicleForUser(string UserID);

        [OperationContract]
        List<Vehicle> retrieveAllVehicles();

        [OperationContract]
        void updateVehicle(int VehicleID, string UserID, string Colour, string Model, string Make, string Vrm, string FuelType, double Co2EmissionsPerGallon, double LitresPerKilometer, int NumberOfSeats);

        [OperationContract]
        void deleteVehicle(int VehicleID);
    }
}
