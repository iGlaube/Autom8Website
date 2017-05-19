namespace SE_TeamZephyr.Migrations.Autom8
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using SE_TeamZephyr.Models;
    using SE_TeamZephyr.Helpers;

    internal sealed class Autom8Conf : DbMigrationsConfiguration<Autom8DBAppContext11>
    {
        public Autom8Conf()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"Migrations\Autom8";
        }
        protected override void Seed(Autom8DBAppContext11 context)

        {

            //////////////////////////// ---- Seeding Areas Information ---- ////////////////////////////
            context.Areas.AddOrUpdate(
                new Area
                {
                    AreaID = 1,
                    AreaName = "Co.Derry/Londonderry"
                },
                new Area
                {
                    AreaID = 2,
                    AreaName = "Co.Antrim"
                },
                new Area
                {
                    AreaID = 3,
                    AreaName = "Co.Armagh"
                },
                new Area
                {
                    AreaID = 4,
                    AreaName = "Co.Down"
                },
                new Area
                {
                    AreaID = 5,
                    AreaName = "Co.Fermanagh"
                },
                new Area
                {
                    AreaID = 6,
                    AreaName = "Co.Tyrone"
                }
            );
            context.SaveChanges();

            //////////////////////////// ---- Seeding Journey Information ---- ////////////////////////////

            context.Journeys.AddOrUpdate(
                new Journey
                {
                    JourneyID = 16,
                    UserID = "0ac86f0b-e12e-4b61-9eec-ce3f3074c65f",
                    JourneyName = "Derry to Belfast",
                    Description = "Pickup Derry dropoff Belfast 6am Mon-Friday",
                    JourneyPrice = 3.50,
                    AreaID = 1,
                    SeatsAvailable = 3,
                    JourneyDate = "19 May 2017",
                    TimeOfJourney = "12:00",
                    OriginPostcode = "BT48 8AY",
                    DestinationPostcode = "BT7 1LE",
                    DistanceOfJourney = "114 km",
                    Duration = "1 hour 29 mins",
                    SmokingPreference = Preferences.SmokingYes,
                    AnimalPreference = Preferences.AnimalYes,
                    MusicPreference = Preferences.MusicYes
                },
                new Journey
                {
                    JourneyID = 17,
                    UserID = "0ac86f0b-e12e-4b61-9eec-ce3f3074c65f",
                    JourneyName = "Draperstown to Belfast",
                    Description = "Mon-Wed pickup at 6.15am",
                    JourneyPrice = 5.95,
                    AreaID = 1,
                    SeatsAvailable = 2,
                    JourneyDate = "29 May 2017",
                    TimeOfJourney = "13:00",
                    OriginPostcode = "BT45 7AB",
                    DestinationPostcode = "BT7 1LE",
                    DistanceOfJourney = "71.3 km",
                    Duration = "59 mins",
                    SmokingPreference = Preferences.SmokingNo,
                    AnimalPreference = Preferences.AnimalNo,
                    MusicPreference = Preferences.MusicNo
                },
                new Journey
                {
                    JourneyID = 18,
                    UserID = "0ac86f0b-e12e-4b61-9eec-ce3f3074c65f",
                    JourneyName = "Limavady to Belfast",
                    Description = "travel to belfast mon, wed and thurs leave at 6.30am",
                    JourneyPrice = 2.99,
                    AreaID = 1,
                    SeatsAvailable = 3,
                    JourneyDate = "13 May 2017",
                    TimeOfJourney = "11:00",
                    OriginPostcode = "BT49 0TF",
                    DestinationPostcode = "BT7 1LE",
                    DistanceOfJourney = "98.4 km",
                    Duration = "1 hour 19 mins",
                    SmokingPreference = Preferences.SmokingYes,
                    AnimalPreference = Preferences.AnimalYes,
                    MusicPreference = Preferences.MusicYes
                },
                new Journey
                {
                    JourneyID = 7,
                    UserID = "a44d3e2f-4cd3-48e5-bfff-6f9ff27e5e19",
                    JourneyName = "Magherafelt to City Centre Belfast",
                    Description = "Mon and fri only leaving at 7.15am",
                    JourneyPrice = 4.95,
                    AreaID = 1,
                    SeatsAvailable = 3,
                    JourneyDate = "21 May 2017",
                    TimeOfJourney = "08:00",
                    OriginPostcode = "BT45 6ED",
                    DestinationPostcode = "BT1 5GS",
                    DistanceOfJourney = "57.2 km",
                    Duration = "48 mins",
                    SmokingPreference = Preferences.SmokingNo,
                    AnimalPreference = Preferences.AnimalYes,
                    MusicPreference = Preferences.MusicNo
                },
                new Journey
                {
                    JourneyID = 8,
                    UserID = "a44d3e2f-4cd3-48e5-bfff-6f9ff27e5e19",
                    JourneyName = "Moneymore to Newtownards Rd Belfast ",
                    Description = "Tues-Sat leaving at 7.30am",
                    JourneyPrice = 4.95,
                    AreaID = 1,
                    SeatsAvailable = 3,
                    JourneyDate = "23 May 2017",
                    TimeOfJourney = "06:00",
                    OriginPostcode = "BT45 7PF",
                    DestinationPostcode = "BT4 1HB",
                    DistanceOfJourney = "64 km",
                    Duration = "49 mins",
                    SmokingPreference = Preferences.SmokingYes,
                    AnimalPreference = Preferences.AnimalYes,
                    MusicPreference = Preferences.MusicYes
                },
                new Journey
                {
                    JourneyID = 9,
                    UserID = "a44d3e2f-4cd3-48e5-bfff-6f9ff27e5e19",
                    JourneyName = "Newtownabbey to QUB ",
                    Description = "Monday to Friday, I leave at 8am",
                    JourneyPrice = 5.00,
                    AreaID = 2,
                    SeatsAvailable = 3,
                    JourneyDate = "18 May 2017",
                    TimeOfJourney = "08:00",
                    OriginPostcode = "BT36 5GG",
                    DestinationPostcode = "BT7 1NN",
                    DistanceOfJourney = "14.6 km",
                    Duration = "20 mins",
                    SmokingPreference = Preferences.SmokingNo,
                    AnimalPreference = Preferences.AnimalNo,
                    MusicPreference = Preferences.MusicYes
                },
                new Journey
                {
                    JourneyID = 4,
                    UserID = "2c09e341-f5f2-4362-8de7-f2f36f818c96",
                    JourneyName = "Ballymena to Belfast city center",
                    Description = "mon and wed only 10am",
                    JourneyPrice = 4.95,
                    AreaID = 2,
                    SeatsAvailable = 3,
                    JourneyDate = "12 May 2017",
                    TimeOfJourney = "16:00",
                    OriginPostcode = "BT43 5EY",
                    DestinationPostcode = "BT1 5GS",
                    DistanceOfJourney = "44.2 km",
                    Duration = "36 mins",
                    SmokingPreference = Preferences.SmokingYes,
                    AnimalPreference = Preferences.AnimalMaybe,
                    MusicPreference = Preferences.MusicMaybe
                },
                new Journey
                {
                    JourneyID = 5,
                    UserID = "2c09e341-f5f2-4362-8de7-f2f36f818c96",
                    JourneyName = "Carrickfergus to QUB",
                    Description = "travel to uni mon-thurs leave at 7.30am",
                    JourneyPrice = 2.95,
                    AreaID = 2,
                    SeatsAvailable = 3,
                    JourneyDate = "18 May 2017",
                    TimeOfJourney = "06:40",
                    OriginPostcode = "BT38 8AT",
                    DestinationPostcode = "BT7 1NN",
                    DistanceOfJourney = "20.2 km",
                    Duration = "28 mins",
                    SmokingPreference = Preferences.SmokingYes,
                    AnimalPreference = Preferences.AnimalYes,
                    MusicPreference = Preferences.MusicYes
                },
                new Journey
                {
                    JourneyID = 6,
                    UserID = "2c09e341-f5f2-4362-8de7-f2f36f818c96",
                    JourneyName = "Dunloy to Newtownards",
                    Description = "daily mon-thurs leaving at 7.30am.",
                    JourneyPrice = 3.95,
                    AreaID = 2,
                    SeatsAvailable = 3,
                    JourneyDate = "16 May 2017",
                    TimeOfJourney = "07:00",
                    OriginPostcode = "BT44 9AB",
                    DestinationPostcode = "BT23 7NX",
                    DistanceOfJourney = "84.3 km",
                    Duration = "1 hour 9 mins",
                    SmokingPreference = Preferences.SmokingMaybe,
                    AnimalPreference = Preferences.AnimalYes,
                    MusicPreference = Preferences.MusicMaybe
                },
                new Journey
                {
                    JourneyID = 10,
                    UserID = "678fcef4-4bc0-4870-901d-461f9886ae57",
                    JourneyName = "Bessbrook to Lisburn",
                    Description = "friday 10am.",
                    JourneyPrice = 5.00,
                    AreaID = 3,
                    SeatsAvailable = 3,
                    JourneyDate = "19 May 2017",
                    TimeOfJourney = "17:00",
                    OriginPostcode = "BT35 7DF",
                    DestinationPostcode = "BT28 2GB",
                    DistanceOfJourney = "49 km",
                    Duration = "39 mins",
                    SmokingPreference = Preferences.SmokingYes,
                    AnimalPreference = Preferences.AnimalYes,
                    MusicPreference = Preferences.MusicYes
                },
                new Journey
                {
                    JourneyID = 11,
                    UserID = "678fcef4-4bc0-4870-901d-461f9886ae57",
                    JourneyName = "Camlough to UUJ",
                    Description = "Travle to uni monday - friday leave at 7.20am.",
                    JourneyPrice = 6.00,
                    AreaID = 3,
                    SeatsAvailable = 3,
                    JourneyDate = "30 May 2017",
                    TimeOfJourney = "16:00",
                    OriginPostcode = "BT35 7JG",
                    DestinationPostcode = "BT37 0QB",
                    DistanceOfJourney = "65 km",
                    Duration = "48 mins",
                    SmokingPreference = Preferences.SmokingYes,
                    AnimalPreference = Preferences.AnimalMaybe,
                    MusicPreference = Preferences.MusicYes
                },
                new Journey
                {
                    JourneyID = 12,
                    UserID = "678fcef4-4bc0-4870-901d-461f9886ae57",
                    JourneyName = "Cullyhanna to Belfast City Centre",
                    Description = "Monday and Tuesday I leave at 11am",
                    JourneyPrice = 5.00,
                    AreaID = 3,
                    SeatsAvailable = 3,
                    JourneyDate = "27 May 2017",
                    TimeOfJourney = "16:20",
                    OriginPostcode = "BT35 9JH",
                    DestinationPostcode = "BT1 5GS",
                    DistanceOfJourney = "80.5 km",
                    Duration = "1 hour 10 mins",
                    SmokingPreference = Preferences.SmokingYes,
                    AnimalPreference = Preferences.AnimalMaybe,
                    MusicPreference = Preferences.MusicNo
                },
                new Journey
                {
                    JourneyID = 13,
                    UserID = "6b5525fb-0f27-46a1-995d-1a81547363c7",
                    JourneyName = "Portaferry to Newtownards",
                    Description = "Daily everyday at 7am",
                    JourneyPrice = 5.00,
                    AreaID = 4,
                    SeatsAvailable = 3,
                    JourneyDate = "16 May 2017",
                    TimeOfJourney = "09:55",
                    OriginPostcode = "BT22 1QT",
                    DestinationPostcode = "BT23 7JF",
                    DistanceOfJourney = "29.5 km",
                    Duration = "32 mins",
                    SmokingPreference = Preferences.SmokingYes,
                    AnimalPreference = Preferences.AnimalYes,
                    MusicPreference = Preferences.MusicYes
                },
                new Journey
                {
                    JourneyID = 14,
                    UserID = "6b5525fb-0f27-46a1-995d-1a81547363c7",
                    JourneyName = "Downpatrick to Crossgar",
                    Description = "daily Mon-fri Leave at 7.45am.",
                    JourneyPrice = 4.95,
                    AreaID = 4,
                    SeatsAvailable = 3,
                    JourneyDate = "15 May 2017",
                    TimeOfJourney = "06:00",
                    OriginPostcode = "BT30 6EH",
                    DestinationPostcode = "BT30 9EA",
                    DistanceOfJourney = "8.6 km",
                    Duration = "9 mins",
                    SmokingPreference = Preferences.SmokingYes,
                    AnimalPreference = Preferences.AnimalMaybe,
                    MusicPreference = Preferences.MusicYes
                },
                new Journey
                {
                    JourneyID = 15,
                    UserID = "6b5525fb-0f27-46a1-995d-1a81547363c7",
                    JourneyName = "Saintfield to Belfast",
                    Description = "Sat and Sunday leave at 8.30am",
                    JourneyPrice = 2.95,
                    AreaID = 4,
                    SeatsAvailable = 3,
                    JourneyDate = "19 May 2017",
                    TimeOfJourney = "10:00",
                    OriginPostcode = "BT24 7AA",
                    DestinationPostcode = "BT7 1LE",
                    DistanceOfJourney = "27.5 km",
                    Duration = "29 mins",
                    SmokingPreference = Preferences.SmokingYes,
                    AnimalPreference = Preferences.AnimalMaybe,
                    MusicPreference = Preferences.MusicNo
                },
                new Journey
                {
                    JourneyID = 1,
                    UserID = "83d2aef3-cd17-44b0-bfe4-651bb9957845",
                    JourneyName = "Blaney to Derry",
                    Description = "Sat&Sun only leave at 8am",
                    JourneyPrice = 2.95,
                    AreaID = 5,
                    SeatsAvailable = 3,
                    TimeOfJourney = "12:00",
                    JourneyDate = "20 May 2017",
                    OriginPostcode = "BT93 7EP",
                    DestinationPostcode = "BT48 8PZ",
                    DistanceOfJourney = "96.5 km",
                    Duration = "1 hour 36 mins",
                    SmokingPreference = Preferences.SmokingYes,
                    AnimalPreference = Preferences.AnimalMaybe,
                    MusicPreference = Preferences.MusicYes
                },
                new Journey
                {
                    JourneyID = 2,
                    UserID = "83d2aef3-cd17-44b0-bfe4-651bb9957845",
                    JourneyName = "Ballinderry to UUJ",
                    Description = "mon-friday only leave at 8am",
                    JourneyPrice = 2.95,
                    AreaID = 5,
                    SeatsAvailable = 3,
                    JourneyDate = "24 May 2017",
                    TimeOfJourney = "14:00",
                    OriginPostcode = "BT28 1UD",
                    DestinationPostcode = "BT37 0QB",
                    DistanceOfJourney = "64.1 km",
                    Duration = "1 hour 1 mins",
                    SmokingPreference = Preferences.SmokingMaybe,
                    AnimalPreference = Preferences.AnimalMaybe,
                    MusicPreference = Preferences.MusicYes
                },
                new Journey
                {
                    JourneyID = 3,
                    UserID = "83d2aef3-cd17-44b0-bfe4-651bb9957845",
                    JourneyName = "Newry to Belfast",
                    Description = "wednesday-friday only leave at 7.30am",
                    JourneyPrice = 2.95,
                    AreaID = 5,
                    SeatsAvailable = 3,
                    JourneyDate = "29 May 2017",
                    TimeOfJourney = "11:00",
                    OriginPostcode = "BT34 2PG",
                    DestinationPostcode = "BT7 1LE",
                    DistanceOfJourney = "62.3 km",
                    Duration = "48 mins",
                    SmokingPreference = Preferences.SmokingYes,
                    AnimalPreference = Preferences.AnimalNo,
                    MusicPreference = Preferences.MusicYes
                }
            );
            context.SaveChanges();


            //////////////////////////// ---- Seeding JourneyStatistics Information ---- ////////////////////////////

            context.JourneyStatistics.AddOrUpdate(
                new JourneyStatistics
                {
                    JourneyStatisticsID = 1,
                    UserID = "0ac86f0b-e12e-4b61-9eec-ce3f3074c65f",
                    TotalDistanceTravelled = 152,
                    DistanceAsDriver = 100,
                    DistanceAsPassenger = 52,
                    FuelCost = 15.60,
                    TotalJourneys = 15

                },
                new JourneyStatistics
                {
                    JourneyStatisticsID = 2,
                    UserID = "a44d3e2f-4cd3-48e5-bfff-6f9ff27e5e19",
                    TotalDistanceTravelled = 98,
                    DistanceAsDriver = 13,
                    DistanceAsPassenger = 85,
                    FuelCost = 20.56,
                    TotalJourneys = 61
                },
                new JourneyStatistics
                {
                    JourneyStatisticsID = 3,
                    UserID = "2c09e341-f5f2-4362-8de7-f2f36f818c96",
                    TotalDistanceTravelled = 210,
                    DistanceAsDriver = 156,
                    DistanceAsPassenger = 44,
                    FuelCost = 16.85,
                    TotalJourneys = 16
                },
                new JourneyStatistics
                {
                    JourneyStatisticsID = 4,
                    UserID = "678fcef4-4bc0-4870-901d-461f9886ae57",
                    TotalDistanceTravelled = 605,
                    DistanceAsDriver = 12,
                    DistanceAsPassenger = 593,
                    FuelCost = 1.08,
                    TotalJourneys = 78
                },
                new JourneyStatistics
                {
                    JourneyStatisticsID = 5,
                    UserID = "6b5525fb-0f27-46a1-995d-1a81547363c7",
                    TotalDistanceTravelled = 721,
                    DistanceAsDriver = 701,
                    DistanceAsPassenger = 20,
                    FuelCost = 19.78,
                    TotalJourneys = 95
                },
                new JourneyStatistics
                {
                    JourneyStatisticsID = 6,
                    UserID = "83d2aef3-cd17-44b0-bfe4-651bb9957845",
                    TotalDistanceTravelled = 35,
                    DistanceAsDriver = 10,
                    DistanceAsPassenger = 25,
                    FuelCost = 4.20,
                    TotalJourneys = 5
                },
                new JourneyStatistics
                {
                    JourneyStatisticsID = 7,
                    UserID = "0e327b31-bd41-45cb-afcb-b2ac3d8248ee",
                    TotalDistanceTravelled = 661,
                    DistanceAsDriver = 101,
                    DistanceAsPassenger = 560,
                    FuelCost = 210.31,
                    TotalJourneys = 71
                },
                new JourneyStatistics
                {
                    JourneyStatisticsID = 8,
                    UserID = "86b99f41-e3ed-4803-9d34-55fd9bdae955",
                    TotalDistanceTravelled = 89,
                    DistanceAsDriver = 16,
                    DistanceAsPassenger = 73,
                    FuelCost = 120.66,
                    TotalJourneys = 18
                },
                new JourneyStatistics
                {
                    JourneyStatisticsID = 9,
                    UserID = "8ba117ba-4d35-4e3d-9a60-724623ab4937",
                    TotalDistanceTravelled = 92,
                    DistanceAsDriver = 56,
                    DistanceAsPassenger = 36,
                    FuelCost = 10.15,
                    TotalJourneys = 3
                },
                new JourneyStatistics
                {
                    JourneyStatisticsID = 10,
                    UserID = "67150777-0c8a-43c9-b1f1-c57f7569d166",
                    TotalDistanceTravelled = 925,
                    DistanceAsDriver = 850,
                    DistanceAsPassenger = 75,
                    FuelCost = 47.36,
                    TotalJourneys = 85
                },
                new JourneyStatistics
                {
                    JourneyStatisticsID = 11,
                    UserID = "b4d20000-980d-4548-8d0a-b0eb0f16fcc1",
                    TotalDistanceTravelled = 777,
                    DistanceAsDriver = 561,
                    DistanceAsPassenger = 216,
                    FuelCost = 97.64,
                    TotalJourneys = 74

                },
                new JourneyStatistics
                {
                    JourneyStatisticsID = 12,
                    UserID = "b8fb7d2b-fe29-499c-a632-0a917eb8728e",
                    TotalDistanceTravelled = 896,
                    DistanceAsDriver = 553,
                    DistanceAsPassenger = 343,
                    FuelCost = 10.15,
                    TotalJourneys = 99

                },
                new JourneyStatistics
                {
                    JourneyStatisticsID = 13,
                    UserID = "bec65c7c-71eb-4760-ab30-1826c0f9c8f6",
                    TotalDistanceTravelled = 420,
                    DistanceAsDriver = 420,
                    DistanceAsPassenger = 0,
                    FuelCost = 4.20,
                    TotalJourneys = 42

                },
                new JourneyStatistics
                {
                    JourneyStatisticsID = 14,
                    UserID = "cb5edef2-6ede-4e42-aa7a-7462672cfb1d",
                    TotalDistanceTravelled = 1337,
                    DistanceAsDriver = 337,
                    DistanceAsPassenger = 1000,
                    FuelCost = 412.55,
                    TotalJourneys = 264,


                },
                new JourneyStatistics
                {
                    JourneyStatisticsID = 15,
                    UserID = "cd55e5c6-e346-4656-ad3c-ab8936639471",
                    TotalDistanceTravelled = 897,
                    DistanceAsDriver = 560,
                    DistanceAsPassenger = 337,
                    FuelCost = 62.98,
                    TotalJourneys = 310
                },
                new JourneyStatistics
                {
                    JourneyStatisticsID = 16,
                    UserID = "fe1a325f-9182-4a08-a9e7-8aa8741176c9",
                    TotalDistanceTravelled = 13,
                    DistanceAsDriver = 0,
                    DistanceAsPassenger = 13,
                    FuelCost = 10.15,
                    TotalJourneys = 1
                }
                );
            context.SaveChanges();

            //////////////////////////// ---- Seeding JourneyStatistics_Global Information ---- ////////////////////////////

            context.JourneyStatisticsGlobal.AddOrUpdate(
                new JourneyStatisticsGlobal
                {
                    JourneyStatisticsID = 1,
                    AreaID = 1,
                    TotalJourneys = 98,
                    TotalDistance = 2009
                },

                new JourneyStatisticsGlobal
                {
                    JourneyStatisticsID = 2,
                    AreaID = 2,
                    TotalJourneys = 76,
                    TotalDistance = 5024
                },
                new JourneyStatisticsGlobal
                {
                    JourneyStatisticsID = 3,
                    AreaID = 3,
                    TotalJourneys = 466,
                    TotalDistance = 10084
                },
                new JourneyStatisticsGlobal
                {
                    JourneyStatisticsID = 4,
                    AreaID = 4,
                    TotalJourneys = 156,
                    TotalDistance = 3012
                },
                new JourneyStatisticsGlobal
                {
                    JourneyStatisticsID = 5,
                    AreaID = 5,
                    TotalJourneys = 577,
                    TotalDistance = 12100
                },
                new JourneyStatisticsGlobal
                {
                    JourneyStatisticsID = 6,
                    AreaID = 6,
                    TotalJourneys = 23,
                    TotalDistance = 460
                }
                );
            context.SaveChanges();

            //////////////////////////// ---- Seeding JourneyStatistics_All Information ---- ////////////////////////////

            context.JourneyStatisticsAll.AddOrUpdate(
                new JourneyStatisticsAll
                {
                    JourneyStatisticsID = 1,
                    Name = "Connor Miller",
                    TotalDistance = 152,
                    TotalJourneys = 15

                },
                new JourneyStatisticsAll
                {
                    JourneyStatisticsID = 2,
                    Name = "Dervla Cullen",
                    TotalDistance = 98,
                    TotalJourneys = 61

                },
                new JourneyStatisticsAll
                {
                    JourneyStatisticsID = 3,
                    Name = "Ashlene Curran",
                    TotalDistance = 210,
                    TotalJourneys = 16
                },
                new JourneyStatisticsAll
                {
                    JourneyStatisticsID = 4,
                    Name = "Jacob White",
                    TotalDistance = 605,
                    TotalJourneys = 78
                },
                new JourneyStatisticsAll
                {
                    JourneyStatisticsID = 5,
                    Name = "Maeve Callaghan",
                    TotalDistance = 721,
                    TotalJourneys = 95
                },
                new JourneyStatisticsAll
                {
                    JourneyStatisticsID = 6,
                    Name = "Brendan Campbell",
                    TotalDistance = 35,
                    TotalJourneys = 5
                },
                new JourneyStatisticsAll
                {
                    JourneyStatisticsID = 7,
                    Name = "Rory O'Flaherty",
                    TotalDistance = 661,
                    TotalJourneys = 71
                },
                new JourneyStatisticsAll
                {
                    JourneyStatisticsID = 8,
                    Name = "Dominic Hill",
                    TotalDistance = 89,
                    TotalJourneys = 18
                },
                new JourneyStatisticsAll
                {
                    JourneyStatisticsID = 9,
                    Name = "Enda McShane",
                    TotalDistance = 92,
                    TotalJourneys = 3
                },
                new JourneyStatisticsAll
                {
                    JourneyStatisticsID = 10,
                    Name = "Oscar Bennett",
                    TotalDistance = 925,
                    TotalJourneys = 85
                },
                new JourneyStatisticsAll
                {
                    JourneyStatisticsID = 11,
                    Name = "Scarlett Wright",
                    TotalDistance = 777,
                    TotalJourneys = 74
                },
                new JourneyStatisticsAll
                {
                    JourneyStatisticsID = 12,
                    Name = "Donna Morgan",
                    TotalDistance = 896,
                    TotalJourneys = 99
                },
                new JourneyStatisticsAll
                {
                    JourneyStatisticsID = 13,
                    Name = "James Kelly",
                    TotalDistance = 420,
                    TotalJourneys = 42
                },
                new JourneyStatisticsAll
                {
                    JourneyStatisticsID = 14,
                    Name = "Joan Clark",
                    TotalDistance = 1337,
                    TotalJourneys = 264
                },
                new JourneyStatisticsAll
                {
                    JourneyStatisticsID = 15,
                    Name = "Emer Flanagan",
                    TotalDistance = 897,
                    TotalJourneys = 310
                },
                new JourneyStatisticsAll
                {
                    JourneyStatisticsID = 16,
                    Name = "Nathan Smith",
                    TotalDistance = 13,
                    TotalJourneys = 1
                },
                new JourneyStatisticsAll
                {
                    JourneyStatisticsID = 17,
                    Name = "Co.Tyrone",
                    TotalJourneys = 98,
                    TotalDistance = 2009
                },
                new JourneyStatisticsAll
                {
                    JourneyStatisticsID = 18,
                    Name = "Co.Fermanagh",
                    TotalJourneys = 76,
                    TotalDistance = 5024
                },
                new JourneyStatisticsAll
                {
                    JourneyStatisticsID = 19,
                    Name = "Co.Down",
                    TotalJourneys = 466,
                    TotalDistance = 10084
                },
                new JourneyStatisticsAll
                {
                    JourneyStatisticsID = 20,
                    Name = "Co.Armagh",
                    TotalJourneys = 156,
                    TotalDistance = 3012
                },
                new JourneyStatisticsAll
                {
                    JourneyStatisticsID = 21,
                    Name = "Co.Antrim",
                    TotalJourneys = 577,
                    TotalDistance = 12100
                },
                new JourneyStatisticsAll
                {
                    JourneyStatisticsID = 22,
                    Name = "Co.Derry/Londonderry",
                    TotalJourneys = 23,
                    TotalDistance = 460
                }
                );
            context.SaveChanges();

            context.Vehicles.AddOrUpdate(
                new Vehicle
                {
                    VehicleID = 1,
                    UserID = "0ac86f0b-e12e-4b61-9eec-ce3f3074c65f",
                    Colour = "WHITE",
                    Model = "COOPER D",
                    Make = "MINI",
                    Vrm = "AH51ENE",
                    FuelType = "DIESEL",
                    Co2EmissionsPerGallon = 95,
                    LitresPerKilometer = 3.5,
                    NumberOfSeats = 3
                },
                new Vehicle
                {
                    VehicleID = 2,
                    UserID = "a44d3e2f-4cd3-48e5-bfff-6f9ff27e5e19",
                    Colour = "WHITE",
                    Model = "COOPER D",
                    Make = "MINI",
                    Vrm = "AH51ENE",
                    FuelType = "DIESEL",
                    Co2EmissionsPerGallon = 95,
                    LitresPerKilometer = 3.5,
                    NumberOfSeats = 3
                },
                new Vehicle
                {
                    VehicleID = 3,
                    UserID = "2c09e341-f5f2-4362-8de7-f2f36f818c96",
                    Colour = "WHITE",
                    Model = "COOPER D",
                    Make = "MINI",
                    Vrm = "AH51ENE",
                    FuelType = "DIESEL",
                    Co2EmissionsPerGallon = 95,
                    LitresPerKilometer = 3.5,
                    NumberOfSeats = 3
                },
                new Vehicle
                {
                    VehicleID = 4,
                    UserID = "678fcef4-4bc0-4870-901d-461f9886ae57",
                    Colour = "WHITE",
                    Model = "COOPER D",
                    Make = "MINI",
                    Vrm = "AH51ENE",
                    FuelType = "DIESEL",
                    Co2EmissionsPerGallon = 95,
                    LitresPerKilometer = 3.5,
                    NumberOfSeats = 3
                },
                new Vehicle
                {
                    VehicleID = 5,
                    UserID = "6b5525fb-0f27-46a1-995d-1a81547363c7",
                    Colour = "WHITE",
                    Model = "COOPER D",
                    Make = "MINI",
                    Vrm = "AH51ENE",
                    FuelType = "DIESEL",
                    Co2EmissionsPerGallon = 95,
                    LitresPerKilometer = 3.5,
                    NumberOfSeats = 3
                },
                new Vehicle
                {
                    VehicleID = 6,
                    UserID = "83d2aef3-cd17-44b0-bfe4-651bb9957845",
                    Colour = "WHITE",
                    Model = "COOPER D",
                    Make = "MINI",
                    Vrm = "AH51ENE",
                    FuelType = "DIESEL",
                    Co2EmissionsPerGallon = 95,
                    LitresPerKilometer = 3.5,
                    NumberOfSeats = 3
                }
                );
            context.SaveChanges();
        }
    }
}

