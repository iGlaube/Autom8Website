using System.Collections.Generic;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace SE_TeamZephyr.Models
{

    public class Autom8DBAppContext11 : DbContext
    {
        //Enables connection to EEECS
        //public Autom8DBAppContext11() : base("Autom8DB")
        //{
        //}

        public DbSet<Area> Areas { get; set; }
        public DbSet<BasketItem> BasketItems { get; set; }
        public DbSet<Journey> Journeys { get; set; }
        public DbSet<ContactForm> ContactForms { get; set; }
        public DbSet<UserFeedback> UserFeedback { get; set; }
        public DbSet<PayPalOrder> Orders { get; set; }
        public DbSet<PayPalOrderDetails> OrderDetails { get; set; }
        public DbSet<JourneyPassenger> JourneyPassengers { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<JourneyStatistics> JourneyStatistics { get; set; }
        public DbSet<JourneyStatisticsGlobal> JourneyStatisticsGlobal { get; set; }
        public DbSet<JourneyStatisticsAll> JourneyStatisticsAll { get; set; }
    }

    public class Area
    {
        [ScaffoldColumn(false)]
        public int AreaID { get; set; }
        [Required, StringLength(100), Display(Name = "Area Name")]
        public string AreaName { get; set; }
        [Display(Name = "Journey Description")]
        public string Description { get; set; }
        public virtual ICollection<Journey> Journeys { get; set; }
    }

    public class BasketItem
    {
        [Key]
        public string ItemId { get; set; }
        public string BasketId { get; set; }
        public int Seats { get; set; }
        public System.DateTime DateCreated { get; set; }
        public int JourneyId { get; set; }
        public virtual Journey Journey { get; set; }
    }

    public class ContactForm
    {
        [Key]
        public int ContactFormID { get; set; }
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        public string ContactSubject { get; set; }
        public string ContactComments { get; set; }
        public string ContactStatus { get; set; }
    }

    public class Journey
    {
        [ScaffoldColumn(false)]
        [Key]
        public int JourneyID { get; set; }
        [Required, StringLength(100), Display(Name = "Journey Owner")]
        public string UserID { get; set; }
        public int? AreaID { get; set; }
        [Display(Name = "Journey Name")]
        public string JourneyName { get; set; }
        [Required, StringLength(10000), Display(Name = "Journey Description"), DataType(DataType.MultilineText)]
        public string Description { get; set; }
        public string Duration { get; set; }
        [Display(Name = "Journey Price")]
        public double? JourneyPrice { get; set; }
        public string JourneyDate { get; set; }
        public string TimeOfJourney { get; set; }
        public string DistanceOfJourney { get; set; }
        public int SeatsAvailable { get; set; }
        public string SmokingPreference { get; set; }
        public string AnimalPreference { get; set; }
        public string MusicPreference { get; set; }
        public string OriginPostcode { get; set; }
        public string DestinationPostcode { get; set; }
        public bool Completed { get; set; }

        public virtual Area Area { get; set; }
        public virtual ICollection<JourneyPassenger> JourneyPassengers { get; set; }
    }

    public class PayPalOrder
    {
        [Key]
        public int OrderId { get; set; }
        public System.DateTime OrderDate { get; set; }
        public string Username { get; set; }
        [Required(ErrorMessage = "First Name is required")]
        [DisplayName("First Name")]
        [StringLength(160)]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Last Name is required")]
        [DisplayName("Last Name")]
        [StringLength(160)]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Address is required")]
        [StringLength(70)]
        public string Address { get; set; }
        [Required(ErrorMessage = "City is required")]
        [StringLength(40)]
        public string City { get; set; }
        [Required(ErrorMessage = "County is required")]
        [StringLength(40)]
        public string County { get; set; }
        [Required(ErrorMessage = "Post Code is required")]
        [DisplayName("Postal Code")]
        [StringLength(10)]
        public string PostalCode { get; set; }
        [Required(ErrorMessage = "Country is required")]
        [StringLength(40)]
        public string Country { get; set; }
        [StringLength(24)]
        public string Mobile { get; set; }
        [Required(ErrorMessage = "Email Address is required")]
        [DisplayName("Email Address")]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "Email is is not valid.")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [ScaffoldColumn(false)]
        public decimal Total { get; set; }
        [ScaffoldColumn(false)]
        public string PaymentTransactionId { get; set; }
        [ScaffoldColumn(false)]
        public bool HasBeenShipped { get; set; }
        public List<PayPalOrderDetails> OrderDetails { get; set; }
    }

    public class PayPalOrderDetails
    {
        [Key]
        public int OrderDetailId { get; set; }
        public int OrderId { get; set; }
        public string Username { get; set; }
        public int JourneyID { get; set; }
        public int NoOfSeats { get; set; }
        public double? UnitPrice { get; set; }
    }

    public class UserFeedback
    {
        [Key]
        public int UserFeedBackID { get; set; }
        public string UserID { get; set; }
        public string FeedbackReason { get; set; }
        public string FeedbackRecommend { get; set; }
        public string FeedbackImprovements { get; set; }
    }

    public class JourneyPassenger
    {
        [Key]
        public int JourneyPassengerID { get; set; }
        [ForeignKey("Journey")]
        public int JourneyID { get; set; }
        public string passengerID { get; set; }
        public string pickupPoint { get; set; }
        public string pickupPointPostcode { get; set; }
        public bool pending { get; set; }
        public bool accepted { get; set; }
        public virtual Journey Journey { get; set; }
    }

    public class JourneyStatistics
    {
        [Key]
        public int JourneyStatisticsID { get; set; }
        public string UserID { get; set; }
        public double TotalDistanceTravelled { get; set; }
        public double DistanceAsDriver { get; set; }
        public double DistanceAsPassenger { get; set; }
        public double FuelCost { get; set; }
        public int TotalJourneys { get; set; }
    }
    public class JourneyStatisticsGlobal
    {
        [Key]
        public int JourneyStatisticsID { get; set; }
        public int AreaID { get; set; }
        public int TotalJourneys { get; set; }
        public double TotalDistance { get; set; }
    }
    public class JourneyStatisticsAll
    {
        [Key]
        public int JourneyStatisticsID { get; set; }
        public string Name { get; set; }
        public int TotalJourneys { get; set; }
        public double TotalDistance { get; set; }
    }

    public class Vehicle
    {
        [Key]
        public int VehicleID { get; set; }
        public string UserID { get; set; }
        public string Colour { get; set; }
        public string Model { get; set; }
        public string Make { get; set; }
        public string Vrm { get; set; }
        public string FuelType { get; set; }
        public double Co2EmissionsPerGallon { get; set; }
        public double LitresPerKilometer { get; set; }
        public int NumberOfSeats { get; set; }
    }
}
