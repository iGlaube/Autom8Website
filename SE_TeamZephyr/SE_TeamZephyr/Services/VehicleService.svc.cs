using SE_TeamZephyr.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SE_TeamZephyr.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "VehicleService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select VehicleService.svc or VehicleService.svc.cs at the Solution Explorer and start debugging.
    public class VehicleService : IVehicleService
    {
        public void createVehicle(string UserID, string Colour, string Model, string Make, string Vrm, string FuelType, double Co2EmissionsPerGallon, double LitresPerKilometer, int NumberOfSeats)
        {
            using (Autom8DBAppContext11 DBContext = new Autom8DBAppContext11())
            {
                Vehicle Vehicle = new Vehicle()
                {
                    UserID = UserID,
                    Colour = Colour,
                    Model = Model,
                    Make = Make,
                    Vrm = Vrm,
                    FuelType = FuelType,
                    Co2EmissionsPerGallon = Co2EmissionsPerGallon,
                    LitresPerKilometer = LitresPerKilometer,
                    NumberOfSeats = NumberOfSeats
                };
                DBContext.Vehicles.Add(Vehicle);
                DBContext.SaveChanges();
            }
        }

        public Vehicle retrieveVehicle(int VehicleID)
        {
            using (Autom8DBAppContext11 DBContext = new Autom8DBAppContext11())
            {
                var Vehicle = DBContext.Vehicles.Where(a => a.VehicleID == VehicleID).FirstOrDefault();
                return Vehicle;
            }
        }

        public Vehicle retrieveVehicleForUser(string UserID)
        {
            using (Autom8DBAppContext11 DBContext = new Autom8DBAppContext11())
            {
                var Vehicle = DBContext.Vehicles.Where(a => a.UserID == UserID).FirstOrDefault();
                return Vehicle;
            }
        }

        public List<Vehicle> retrieveAllVehicles()
        {
            using (Autom8DBAppContext11 DBContext = new Autom8DBAppContext11())
            {
                var Vehicles = DBContext.Vehicles.ToList();
                if (Vehicles.Count > 0)
                {
                    return Vehicles;
                }
                return new List<Vehicle>();
            }
        }

        public void updateVehicle(int VehicleID, string UserID, string Colour, string Model, string Make, string Vrm, string FuelType, double Co2EmissionsPerGallon, double LitresPerKilometer, int NumberOfSeats)
        {
            using (Autom8DBAppContext11 DBContext = new Autom8DBAppContext11())
            {
                var existingVehicle = DBContext.Vehicles.Single(a => a.VehicleID == VehicleID);
                existingVehicle.UserID = UserID;
                existingVehicle.Colour = Colour;
                existingVehicle.Model = Model;
                existingVehicle.Make = Make;
                existingVehicle.Vrm = Vrm;
                existingVehicle.FuelType = FuelType;
                existingVehicle.Co2EmissionsPerGallon = Co2EmissionsPerGallon;
                existingVehicle.LitresPerKilometer = LitresPerKilometer;
                existingVehicle.NumberOfSeats = NumberOfSeats;
                DBContext.SaveChanges();
            }
        }

        public void deleteVehicle(int VehicleID)
        {
            using (Autom8DBAppContext11 DBContext = new Autom8DBAppContext11())
            {
                DBContext.Vehicles.Remove(DBContext.Vehicles.Where(a => a.VehicleID == VehicleID).First());
                DBContext.SaveChanges();
            }
        }
    }
}
