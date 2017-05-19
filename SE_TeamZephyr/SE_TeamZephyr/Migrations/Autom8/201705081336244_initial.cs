namespace SE_TeamZephyr.Migrations.Autom8
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Areas",
                c => new
                    {
                        AreaID = c.Int(nullable: false, identity: true),
                        AreaName = c.String(nullable: false, maxLength: 100),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.AreaID);
            
            CreateTable(
                "dbo.Journeys",
                c => new
                    {
                        JourneyID = c.Int(nullable: false, identity: true),
                        UserID = c.String(nullable: false, maxLength: 100),
                        AreaID = c.Int(),
                        JourneyName = c.String(),
                        Description = c.String(nullable: false),
                        Duration = c.String(),
                        JourneyPrice = c.Double(),
                        JourneyDate = c.String(),
                        TimeOfJourney = c.String(),
                        DistanceOfJourney = c.String(),
                        SeatsAvailable = c.Int(nullable: false),
                        SmokingPreference = c.String(),
                        AnimalPreference = c.String(),
                        MusicPreference = c.String(),
                        OriginPostcode = c.String(),
                        DestinationPostcode = c.String(),
                        Completed = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.JourneyID)
                .ForeignKey("dbo.Areas", t => t.AreaID)
                .Index(t => t.AreaID);
            
            CreateTable(
                "dbo.JourneyPassengers",
                c => new
                    {
                        JourneyPassengerID = c.Int(nullable: false, identity: true),
                        JourneyID = c.Int(nullable: false),
                        passengerID = c.String(),
                        pickupPoint = c.String(),
                        pickupPointPostcode = c.String(),
                        pending = c.Boolean(nullable: false),
                        accepted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.JourneyPassengerID)
                .ForeignKey("dbo.Journeys", t => t.JourneyID, cascadeDelete: true)
                .Index(t => t.JourneyID);
            
            CreateTable(
                "dbo.BasketItems",
                c => new
                    {
                        ItemId = c.String(nullable: false, maxLength: 128),
                        BasketId = c.String(),
                        Seats = c.Int(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                        JourneyId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ItemId)
                .ForeignKey("dbo.Journeys", t => t.JourneyId, cascadeDelete: true)
                .Index(t => t.JourneyId);
            
            CreateTable(
                "dbo.ContactForms",
                c => new
                    {
                        ContactFormID = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        UserEmail = c.String(),
                        ContactSubject = c.String(),
                        ContactComments = c.String(),
                        ContactStatus = c.String(),
                    })
                .PrimaryKey(t => t.ContactFormID);
            
            CreateTable(
                "dbo.JourneyStatistics",
                c => new
                    {
                        JourneyStatisticsID = c.Int(nullable: false, identity: true),
                        UserID = c.String(),
                        TotalDistanceTravelled = c.Double(nullable: false),
                        DistanceAsDriver = c.Double(nullable: false),
                        DistanceAsPassenger = c.Double(nullable: false),
                        FuelCost = c.Double(nullable: false),
                        TotalJourneys = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.JourneyStatisticsID);
            
            CreateTable(
                "dbo.JourneyStatisticsAlls",
                c => new
                    {
                        JourneyStatisticsID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        TotalJourneys = c.Int(nullable: false),
                        TotalDistance = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.JourneyStatisticsID);
            
            CreateTable(
                "dbo.JourneyStatisticsGlobals",
                c => new
                    {
                        JourneyStatisticsID = c.Int(nullable: false, identity: true),
                        AreaID = c.Int(nullable: false),
                        TotalJourneys = c.Int(nullable: false),
                        TotalDistance = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.JourneyStatisticsID);
            
            CreateTable(
                "dbo.PayPalOrderDetails",
                c => new
                    {
                        OrderDetailId = c.Int(nullable: false, identity: true),
                        OrderId = c.Int(nullable: false),
                        Username = c.String(),
                        JourneyID = c.Int(nullable: false),
                        NoOfSeats = c.Int(nullable: false),
                        UnitPrice = c.Double(),
                    })
                .PrimaryKey(t => t.OrderDetailId)
                .ForeignKey("dbo.PayPalOrders", t => t.OrderId, cascadeDelete: true)
                .Index(t => t.OrderId);
            
            CreateTable(
                "dbo.PayPalOrders",
                c => new
                    {
                        OrderId = c.Int(nullable: false, identity: true),
                        OrderDate = c.DateTime(nullable: false),
                        Username = c.String(),
                        FirstName = c.String(nullable: false, maxLength: 160),
                        LastName = c.String(nullable: false, maxLength: 160),
                        Address = c.String(nullable: false, maxLength: 70),
                        City = c.String(nullable: false, maxLength: 40),
                        County = c.String(nullable: false, maxLength: 40),
                        PostalCode = c.String(nullable: false, maxLength: 10),
                        Country = c.String(nullable: false, maxLength: 40),
                        Mobile = c.String(maxLength: 24),
                        Email = c.String(nullable: false),
                        Total = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PaymentTransactionId = c.String(),
                        HasBeenShipped = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.OrderId);
            
            CreateTable(
                "dbo.UserFeedbacks",
                c => new
                    {
                        UserFeedBackID = c.Int(nullable: false, identity: true),
                        UserID = c.String(),
                        FeedbackReason = c.String(),
                        FeedbackRecommend = c.String(),
                        FeedbackImprovements = c.String(),
                    })
                .PrimaryKey(t => t.UserFeedBackID);
            
            CreateTable(
                "dbo.Vehicles",
                c => new
                    {
                        VehicleID = c.Int(nullable: false, identity: true),
                        UserID = c.String(),
                        Colour = c.String(),
                        Model = c.String(),
                        Make = c.String(),
                        Vrm = c.String(),
                        FuelType = c.String(),
                        Co2EmissionsPerGallon = c.Double(nullable: false),
                        LitresPerKilometer = c.Double(nullable: false),
                        NumberOfSeats = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.VehicleID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PayPalOrderDetails", "OrderId", "dbo.PayPalOrders");
            DropForeignKey("dbo.BasketItems", "JourneyId", "dbo.Journeys");
            DropForeignKey("dbo.JourneyPassengers", "JourneyID", "dbo.Journeys");
            DropForeignKey("dbo.Journeys", "AreaID", "dbo.Areas");
            DropIndex("dbo.PayPalOrderDetails", new[] { "OrderId" });
            DropIndex("dbo.BasketItems", new[] { "JourneyId" });
            DropIndex("dbo.JourneyPassengers", new[] { "JourneyID" });
            DropIndex("dbo.Journeys", new[] { "AreaID" });
            DropTable("dbo.Vehicles");
            DropTable("dbo.UserFeedbacks");
            DropTable("dbo.PayPalOrders");
            DropTable("dbo.PayPalOrderDetails");
            DropTable("dbo.JourneyStatisticsGlobals");
            DropTable("dbo.JourneyStatisticsAlls");
            DropTable("dbo.JourneyStatistics");
            DropTable("dbo.ContactForms");
            DropTable("dbo.BasketItems");
            DropTable("dbo.JourneyPassengers");
            DropTable("dbo.Journeys");
            DropTable("dbo.Areas");
        }
    }
}
