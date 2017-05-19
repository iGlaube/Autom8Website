using Microsoft.AspNet.Identity;
using SE_TeamZephyr.Models;
using System;
using System.Data;
using System.Data.Entity.Migrations;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.IO;
using System.Net;
using System.Xml;
using SE_TeamZephyr.Helpers;
using SE_TeamZephyr.Services;
using System.Web.UI.WebControls;
using System.Linq;
using System.Text.RegularExpressions;

namespace SE_TeamZephyr
{
    public partial class AddAJourney : System.Web.UI.Page
    {
        public string select = "Please Select:";

        //public double? PriceOfJourney;

        public double PriceofJourney { get; private set; }


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                SetTime();
            }
            JourneyError.Text = "";
            {
                //http://maps.googleapis.com/maps/api/distancematrix/xml?origins=NEW+YORK+11535&destinations=WASHINGTON+20544&sensor=true
            }
            //{
            //    if (Session["User_Type"].ToString() != "4")
            //    {
            //        Response.Redirect("../Account/Login.aspx");

            SmokingPreference.Items[0].Text = select;
            SmokingPreference.Items[1].Text = Preferences.SmokingYes;
            SmokingPreference.Items[2].Text = Preferences.SmokingMaybe;
            SmokingPreference.Items[3].Text = Preferences.SmokingNo;

            AnimalPreference.Items[0].Text = select;
            AnimalPreference.Items[1].Text = Preferences.AnimalYes;
            AnimalPreference.Items[2].Text = Preferences.AnimalMaybe;
            AnimalPreference.Items[3].Text = Preferences.AnimalNo;

            MusicPreference.Items[0].Text = select;
            MusicPreference.Items[1].Text = Preferences.MusicYes;
            MusicPreference.Items[2].Text = Preferences.MusicMaybe;
            MusicPreference.Items[3].Text = Preferences.MusicNo;

            SmokingPreference.Items[0].Value = select;
            SmokingPreference.Items[1].Value = Preferences.SmokingYes;
            SmokingPreference.Items[2].Value = Preferences.SmokingMaybe;
            SmokingPreference.Items[3].Value = Preferences.SmokingNo;

            AnimalPreference.Items[0].Value = select;
            AnimalPreference.Items[1].Value = Preferences.AnimalYes;
            AnimalPreference.Items[2].Value = Preferences.AnimalMaybe;
            AnimalPreference.Items[3].Value = Preferences.AnimalNo;

            MusicPreference.Items[0].Value = select;
            MusicPreference.Items[1].Value = Preferences.MusicYes;
            MusicPreference.Items[2].Value = Preferences.MusicMaybe;
            MusicPreference.Items[3].Value = Preferences.MusicNo;
        }

        private void SetTime()
        {
            // Set the start time (00:00 means 12:00 AM)
            DateTime StartTime = DateTime.ParseExact("00:00", "HH:mm", null);
            // Set the end time (23:55 means 11:55 PM)
            DateTime EndTime = DateTime.ParseExact("23:55", "HH:mm", null);
            //Set 5 minutes interval
            TimeSpan Interval = new TimeSpan(0, 5, 0);
            //To set 1 hour interval
            //TimeSpan Interval = new TimeSpan(1, 0, 0);           
            TimeSelected.Items.Clear();

            while (StartTime <= EndTime)
            {
                TimeSelected.Items.Add(StartTime.ToShortTimeString());

                StartTime = StartTime.Add(Interval);
            }
            TimeSelected.Items.Insert(0, new ListItem("--Select--", "0"));

        }


        protected void submit_Click(object sender, EventArgs e)
        {
            string oP = OriginPostcode.Text.ToString();
            string dP = DestinationPostcode.Text.ToString();
            if (!String.IsNullOrWhiteSpace(oP) || !String.IsNullOrWhiteSpace(dP))
            {
                SetDistance(OriginPostcode.Text, DestinationPostcode.Text);
                char[] trim = { ' ', 'k', 'm' };
                setPrice(Distance.Text.Trim(trim));
                JourneyError.Text = "";
            } else if(String.IsNullOrWhiteSpace(oP) || !String.IsNullOrWhiteSpace(dP))
            {
                JourneyError.Text = "Please enter a valid Postcode";
            }
        }

        public void setPrice(string distance)
        {
            JourneyPriceInput.Text = "£" + Math.Round((Double.Parse(distance) * Globals.FUEL_COST * 0.7), 2).ToString();
        }

        public void SetDistance(string origin, string destination)
        {
            string url = @"http://maps.googleapis.com/maps/api/distancematrix/xml?origins=" + origin + "&destinations=" + destination + "&sensor=false";

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            WebResponse response = request.GetResponse();
            Stream dataStream = response.GetResponseStream();
            StreamReader sreader = new StreamReader(dataStream);
            string responsereader = sreader.ReadToEnd();
            response.Close();

            DataSet ds = new DataSet();
            ds.ReadXml(new XmlTextReader(new StringReader(responsereader)));

            if (ds.Tables.Count == 0)
            {
                JourneyError.Text = "Please fill out all the required fields.";
            }
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables["element"].Rows[0]["status"].ToString() == "OK")

                {
                    Duration.Text = ds.Tables["duration"].Rows[0]["text"].ToString();
                    Distance.Text = ds.Tables["distance"].Rows[0]["text"].ToString();
                }

            }

        }


        //ONLY GET THIS BY CLICKIN BTN ON DESGIN VIEW..
        protected void submitnewjourney_Click(object sender, EventArgs e)
        {
            char[] trim = { ' ', '£' };
            VehicleService cds = new VehicleService();
            var vehicle = cds.retrieveVehicleForUser(Context.User.Identity.GetUserId());

            if (vehicle == null)
            {
                JourneyError.Text = "You must register a car on your profile before you can advertise a journey! Click <a href=\"../Profile/MyProfile_Vehicle\" class=\"wrnLink\">here</a> to add one";
            }
            else if(JourneyNametxt.Text == null || AreaID.Text == "" || JourneyPriceInput.Text == "" || JourneyDescriptiontxt.Text == "" ||  
            SmokingPreference.SelectedValue == select || MusicPreference.SelectedValue == select || AnimalPreference.SelectedValue == select)
            {
                JourneyError.Text = "Please fill out all the required fields.";
            }  
            else if(Int32.Parse(NoOfSeats.Value) > vehicle.NumberOfSeats)
            {
                JourneyError.Text = "You have more seats advertised than you have in your vehicle!";
            }
            else if(Int32.Parse(NoOfSeats.Value) < 1)
            {
                JourneyError.Text = "You have to have at least one passenger!";
            }
            else
            {
                JourneyService js = new JourneyService();
                js.createJourney(
                    Context.User.Identity.GetUserId().ToString(),
                    Int32.Parse(AreaID.SelectedValue),
                    JourneyNametxt.Text,
                    JourneyDescriptiontxt.Text,
                    Double.Parse(JourneyPriceInput.Text.Trim(trim)),
                    Duration.Text,
                    Distance.Text,
                    JourneyDate.Text,
                    Int32.Parse(NoOfSeats.Value),
                    TimeSelected.SelectedValue,
                    SmokingPreference.SelectedItem.Text.ToString(),
                    MusicPreference.SelectedItem.Text.ToString(),
                    AnimalPreference.SelectedItem.Text.ToString(),
                    OriginPostcode.Text,
                    DestinationPostcode.Text
                );

                JourneyNametxt.Text = "";
                //   JourneyPriceInput =   Items.         //JourneyPriceInput.Value = "0";
                JourneyDate.Text = "";
                JourneyDescriptiontxt.Text = "";
                Distance.Text = "";
                Duration.Text = "";

            }
        }

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {

            JourneyDate.Text = (Calendar1.SelectedDate).ToLongDateString();
            ;
        }



    }
}



