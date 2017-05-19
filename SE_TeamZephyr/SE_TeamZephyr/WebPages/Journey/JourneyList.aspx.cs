using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SE_TeamZephyr.Models;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.ModelBinding;
using Microsoft.AspNet.Identity;
using SE_TeamZephyr.Services;

namespace SE_TeamZephyr
{
    public partial class JourneyList : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        
        {
        }
        public List<Journey> GetJourneys([QueryString("id")] int? areaId)
        {
            JourneyService js = new JourneyService();
            var journeys = js.retrieveAllJourneys();
            string userId = Context.User.Identity.GetUserId();
            if (userId != null)
            {
                journeys = journeys.Where(q => q.UserID != userId).ToList();
            }
            if (areaId.HasValue && areaId > 0)
            {
                journeys = journeys.Where(p => p.AreaID == areaId).ToList();
            }

            journeys = journeys.Where(j => DateTime.Parse(j.JourneyDate) > DateTime.Now).ToList();
            return journeys;
        }

        public List<Area> GetAreas()
        {
            AreaService a = new AreaService();
            return a.retrieveAllAreas();
        }

        protected void SearchButton_Click(object sender, EventArgs e)
        {
            journeyList.SelectMethod = "Search";
            Search();
        }

        //Search only extracts journeys not belonging to current user
        public List<Journey> Search()
        {
            JourneyService js = new JourneyService();
            var journeys = js.searchJourneys(TextBox1.Text);
            string userId = Context.User.Identity.GetUserId();
            if (userId != null && journeys.Count>0)
            {
                journeys = journeys.Where(q => q.UserID != userId).ToList();
            }
            else
            {
                return journeys;
            }
            return journeys;
        }
    }
}