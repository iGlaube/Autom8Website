using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SE_TeamZephyr.Helpers.VehicleJson
{
    //http://json2csharp.com/ used to generate this class from json object

    public class VehicleJson
    {
        public Request Request { get; set; }
        public Response Response { get; set; }
    }

    public class DataKeys
    {
        public string Vrm { get; set; }
    }

    public class Request
    {
        public string RequestGuid { get; set; }
        public string PackageId { get; set; }
        public int PackageVersion { get; set; }
        public int ResponseVersion { get; set; }
        public DataKeys DataKeys { get; set; }
    }

    public class Lookup
    {
        public string StatusCode { get; set; }
        public string StatusMessage { get; set; }
        public List<object> AdviceTextList { get; set; }
    }

    public class StatusInformation
    {
        public Lookup Lookup { get; set; }
    }

    public class Dimensions
    {
        public object UnladenWeight { get; set; }
        public string RigidArtic { get; set; }
        public string BodyShape { get; set; }
        public object PayloadVolume { get; set; }
        public object PayloadWeight { get; set; }
        public double Height { get; set; }
        public int NumberOfSeats { get; set; }
        public double KerbWeight { get; set; }
        public object GrossTrainWeight { get; set; }
        public object LoadLength { get; set; }
        public object DataVersionNumber { get; set; }
        public object WheelBase { get; set; }
        public double CarLength { get; set; }
        public double Width { get; set; }
        public int NumberOfAxles { get; set; }
        public object GrossVehicleWeight { get; set; }
        public object GrossCombinedWeight { get; set; }
    }

    public class Engine
    {
        public double Stroke { get; set; }
        public string PrimaryFuelFlag { get; set; }
        public int ValvesPerCylinder { get; set; }
        public string Aspiration { get; set; }
        public int NumberOfCylinders { get; set; }
        public string CylinderArrangement { get; set; }
        public string ValveGear { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }
        public double Bore { get; set; }
        public string Make { get; set; }
    }

    public class General
    {
        public Engine Engine { get; set; }
        public string PowerDelivery { get; set; }
        public string TypeApprovalCategory { get; set; }
        public string DrivingAxle { get; set; }
        public object DataVersionNumber { get; set; }
        public string EuroStatus { get; set; }
    }

    public class Torque
    {
        public double FtLb { get; set; }
        public double Nm { get; set; }
        public double Rpm { get; set; }
    }

    public class Power
    {
        public double Bhp { get; set; }
        public double Rpm { get; set; }
        public double Kw { get; set; }
    }

    public class MaxSpeed
    {
        public double Kph { get; set; }
        public double Mph { get; set; }
    }

    public class Acceleration
    {
        public double Mph { get; set; }
        public double Kph { get; set; }
    }

    public class Performance
    {
        public Torque Torque { get; set; }
        public object DataVersionNumber { get; set; }
        public Power Power { get; set; }
        public MaxSpeed MaxSpeed { get; set; }
        public double Co2 { get; set; }
        public Acceleration Acceleration { get; set; }
    }

    public class ExtraUrban
    {
        public double Lkm { get; set; }
        public double Mpg { get; set; }
    }

    public class UrbanCold
    {
        public double Lkm { get; set; }
        public double Mpg { get; set; }
    }

    public class Combined
    {
        public double Lkm { get; set; }
        public double Mpg { get; set; }
    }

    public class Consumption
    {
        public ExtraUrban ExtraUrban { get; set; }
        public UrbanCold UrbanCold { get; set; }
        public Combined Combined { get; set; }
    }

    public class TechnicalDetails
    {
        public Dimensions Dimensions { get; set; }
        public General General { get; set; }
        public Performance Performance { get; set; }
        public Consumption Consumption { get; set; }
    }

    public class Mvris
    {
        public string ModelCode { get; set; }
        public string MakeCode { get; set; }
    }

    public class Smmt
    {
        public string Make { get; set; }
        public Mvris Mvris { get; set; }
        public string Trim { get; set; }
        public string Range { get; set; }
    }

    public class Dvla
    {
        public string ModelCode { get; set; }
        public object Model { get; set; }
        public string MakeCode { get; set; }
        public object Make { get; set; }
    }

    public class ClassificationDetails
    {
        public Smmt Smmt { get; set; }
        public Dvla Dvla { get; set; }
    }

    public class FirstYear
    {
        public object SixMonth { get; set; }
        public object TwelveMonth { get; set; }
    }

    public class YearTwoToSix
    {
        public object TwelveMonth { get; set; }
        public object SixMonth { get; set; }
    }

    public class PremiumVehicle
    {
        public YearTwoToSix YearTwoToSix { get; set; }
    }

    public class Standard
    {
        public object SixMonth { get; set; }
        public object TwelveMonth { get; set; }
    }

    public class VedRate
    {
        public FirstYear FirstYear { get; set; }
        public PremiumVehicle PremiumVehicle { get; set; }
        public Standard Standard { get; set; }
    }

    public class MotVed
    {
        public VedRate VedRate { get; set; }
        public object VedCo2Emissions { get; set; }
        public object MotDue { get; set; }
        public object VedBand { get; set; }
        public object VedCo2Band { get; set; }
        public object TaxDue { get; set; }
        public object Message { get; set; }
        public object VehicleStatus { get; set; }
    }

    public class VehicleStatus
    {
        public MotVed MotVed { get; set; }
    }

    public class KeeperChangesList
    {
        public string DateOfTransaction { get; set; }
        public int NumberOfPreviousKeepers { get; set; }
        public string DateOfLastKeeperChange { get; set; }
    }

    public class VehicleHistory
    {
        public int V5CCertificateCount { get; set; }
        public int PlateChangeCount { get; set; }
        public int NumberOfPreviousKeepers { get; set; }
        public object V5CCertificateList { get; set; }
        public int KeeperChangesCount { get; set; }
        public int VicCount { get; set; }
        public int ColourChangeCount { get; set; }
        public object ColourChangeList { get; set; }
        public List<KeeperChangesList> KeeperChangesList { get; set; }
        public object PlateChangeList { get; set; }
        public object VicList { get; set; }
    }

    public class VehicleRegistration
    {
        public string DateOfLastUpdate { get; set; }
        public string Colour { get; set; }
        public object AbiBrokerNetCode { get; set; }
        public string EngineNumber { get; set; }
        public string EngineCapacity { get; set; }
        public string TransmissionCode { get; set; }
        public string DtpMakeCode { get; set; }
        public bool Exported { get; set; }
        public string YearOfManufacture { get; set; }
        public object WheelPlan { get; set; }
        public object DateExported { get; set; }
        public bool Scrapped { get; set; }
        public string Transmission { get; set; }
        public string DateFirstRegisteredUk { get; set; }
        public string Model { get; set; }
        public int GearCount { get; set; }
        public bool ImportNonEu { get; set; }
        public string DtpModelCode { get; set; }
        public object PreviousVrmGb { get; set; }
        public double GrossWeight { get; set; }
        public string DoorPlanLiteral { get; set; }
        public string MvrisModelCode { get; set; }
        public string Vin { get; set; }
        public string Vrm { get; set; }
        public string DateFirstRegistered { get; set; }
        public object DateScrapped { get; set; }
        public string DoorPlan { get; set; }
        public string VinLast5 { get; set; }
        public bool VehicleUsedBeforeFirstRegistration { get; set; }
        public double MaxPermissibleMass { get; set; }
        public string Make { get; set; }
        public string MakeModel { get; set; }
        public string TransmissionType { get; set; }
        public object SeatingCapacity { get; set; }
        public string FuelType { get; set; }
        public object Co2Emissions { get; set; }
        public bool Imported { get; set; }
        public string MvrisMakeCode { get; set; }
        public object PreviousVrmNi { get; set; }
        public object VinConfirmationFlag { get; set; }
    }

    public class SmmtDetails
    {
        public string Range { get; set; }
        public string FuelType { get; set; }
        public string EngineCapacity { get; set; }
        public string MarketSectorCode { get; set; }
        public string CountryOfOrigin { get; set; }
        public string ModelCode { get; set; }
        public string ModelVariant { get; set; }
        public object DataVersionNumber { get; set; }
        public int NumberOfGears { get; set; }
        public double NominalEngineCapacity { get; set; }
        public string MarqueCode { get; set; }
        public string Transmission { get; set; }
        public string BodyStyle { get; set; }
        public string VisibilityDate { get; set; }
        public string SysSetupDate { get; set; }
        public string Marque { get; set; }
        public string CabType { get; set; }
        public object TerminateDate { get; set; }
        public string Series { get; set; }
        public int NumberOfDoors { get; set; }
        public string DriveType { get; set; }
    }

    public class DataItems
    {
        public TechnicalDetails TechnicalDetails { get; set; }
        public ClassificationDetails ClassificationDetails { get; set; }
        public VehicleStatus VehicleStatus { get; set; }
        public VehicleHistory VehicleHistory { get; set; }
        public VehicleRegistration VehicleRegistration { get; set; }
        public SmmtDetails SmmtDetails { get; set; }
    }

    public class Response
    {
        public string StatusCode { get; set; }
        public string StatusMessage { get; set; }
        public StatusInformation StatusInformation { get; set; }
        public DataItems DataItems { get; set; }
    }
}