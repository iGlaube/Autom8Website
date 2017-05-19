using SE_TeamZephyr.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity;
using SE_TeamZephyr.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SE_TeamZephyr.Services;
using SE_TeamZephyr.Helpers;

namespace SE_TeamZephyr.Profile
{
    public partial class MyProfile_JourneyEdit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SmokingPreference.Items[0].Text = Preferences.SmokingYes;
            SmokingPreference.Items[1].Text = Preferences.SmokingMaybe;
            SmokingPreference.Items[2].Text = Preferences.SmokingNo;

            AnimalPreference.Items[0].Text = Preferences.AnimalYes;
            AnimalPreference.Items[1].Text = Preferences.AnimalMaybe;
            AnimalPreference.Items[2].Text = Preferences.AnimalNo;

            MusicPreference.Items[0].Text = Preferences.MusicYes;
            MusicPreference.Items[1].Text = Preferences.MusicMaybe;
            MusicPreference.Items[2].Text = Preferences.MusicNo;

            SmokingPreference.Items[0].Value = Preferences.SmokingYes;
            SmokingPreference.Items[1].Value = Preferences.SmokingMaybe;
            SmokingPreference.Items[2].Value = Preferences.SmokingNo;

            AnimalPreference.Items[0].Value = Preferences.AnimalYes;
            AnimalPreference.Items[1].Value = Preferences.AnimalMaybe;
            AnimalPreference.Items[2].Value = Preferences.AnimalNo;

            MusicPreference.Items[0].Value = Preferences.MusicYes;
            MusicPreference.Items[1].Value = Preferences.MusicMaybe;
            MusicPreference.Items[2].Value = Preferences.MusicNo;

            JourneyService js = new JourneyService();
            var journeyId = Int32.Parse(Request.QueryString["journeyId"]);
            var journey = js.retrieveJourney(journeyId);

            if (!Page.IsPostBack)
            {
                SetTime();
            }

            if (!IsPostBack)
            {
                //TxtBox_JourneyNumber.Text = journey.JourneyID.ToString();
                TxtBox_JourneyName.Text = journey.JourneyName;
                TxtBox_JourneyDescription.Text = journey.Description;
                TxtBox_TimeSelected.Items.FindByValue(journey.TimeOfJourney).Selected = true;
                TxtBox_JourneyDateSelect.Text = journey.JourneyDate;
                TxtBox_SeatsAvailable.Text = journey.SeatsAvailable.ToString();
                AnimalPreference.Items.FindByValue(journey.AnimalPreference).Selected = true;
                MusicPreference.Items.FindByValue(journey.MusicPreference).Selected = true;
                SmokingPreference.Items.FindByValue(journey.SmokingPreference).Selected = true;
            }
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
            TxtBox_TimeSelected.Items.Clear();

            while (StartTime <= EndTime)
            {
                TxtBox_TimeSelected.Items.Add(StartTime.ToShortTimeString());

                StartTime = StartTime.Add(Interval);
            }
            TxtBox_TimeSelected.Items.Insert(0, new ListItem("--Select--", "0"));

        }
        public IQueryable<Journey> GetJourney([QueryString("journeyID")] int? journeyId)
        {
            var _db = new Autom8DBAppContext11();
            IQueryable<Journey> query = _db.Journeys;
            if (journeyId.HasValue && journeyId > 0)
            {
                query = query.Where(p => p.JourneyID == journeyId);
            }
            else
            {
                query = null;
            }
            return query;
        }

        protected void updateJourney_Click(object sender, EventArgs e)
        {
            JourneyService js = new JourneyService();
            JourneyPassengerService jps = new JourneyPassengerService();

            var journey = js.retrieveJourney(Int32.Parse(Request.QueryString["journeyID"]));
            var journeyPassengers = jps.retrieveAllJourneyPassengers().Where(jp => jp.JourneyID == journey.JourneyID && jp.accepted == true).ToList();

            if(Int32.Parse(TxtBox_SeatsAvailable.Text) < journeyPassengers.Count)
            {
                EditError.Text = "You already have more passengers accepted for this journey than the updated seat number!";
            }
            else
            {
                js.updateJourney(journey.JourneyID, journey.UserID, journey.AreaID.Value, TxtBox_JourneyName.Text, TxtBox_JourneyDescription.Text, journey.JourneyPrice.Value, TxtBox_JourneyDateSelect.Text, Int32.Parse(TxtBox_SeatsAvailable.Text), TxtBox_TimeSelected.SelectedValue, SmokingPreference.SelectedItem.Text.ToString(), MusicPreference.SelectedItem.Text.ToString(), AnimalPreference.SelectedItem.Text.ToString());
            }
        }

        protected void deleteJourney_Click(object sender, EventArgs e)
        {
            JourneyService js = new JourneyService();
            js.deleteJourney(Int32.Parse(Request.QueryString["journeyID"]));
            Response.Redirect("MyProfile_Journeys");
        }

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
           TxtBox_JourneyDateSelect.Text = (Calendar1.SelectedDate).ToLongDateString();
        }
    }
}