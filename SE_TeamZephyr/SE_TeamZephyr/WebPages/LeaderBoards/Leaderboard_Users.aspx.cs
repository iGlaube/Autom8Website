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
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.Optimization;

namespace SE_TeamZephyr.WebPages.LeaderBoards
{
    public partial class Leaderboard_Users : System.Web.UI.Page
    {
        //Database variables
        JourneyStatisticsService jds = new JourneyStatisticsService();
        private Autom8DBAppContext11 _db = new Autom8DBAppContext11();

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        public List<JourneyStatistics> GetJourneyStatistics()
        {
            var jStats = jds.retrieveAllJourneyDetails();
            return jStats;
        }


        public List<JourneyStatistics> getJourneyStatisticsByRank()
        {
            return GetJourneyStatistics().OrderBy(o => o.UserID).ToList();
        }

        public List<JourneyStatistics> getJourneyStatisticsByTotal()
        {
            return GetJourneyStatistics().OrderBy(o => o.TotalDistanceTravelled).ToList();
        }

        public List<JourneyStatistics> getJourneyStatisticsByDriver()
        {
            return GetJourneyStatistics().OrderBy(o => o.DistanceAsDriver).ToList();
        }

        public List<JourneyStatistics> getJourneyStatisticsByPassenger()
        {
            return GetJourneyStatistics().OrderBy(o => o.DistanceAsPassenger).ToList();
        }

        public List<JourneyStatistics> getJourneyStatisticsByFuel()
        {
            return GetJourneyStatistics().OrderBy(o => o.FuelCost).ToList();
        }
        public List<JourneyStatistics> getJourneyByJourneyTotal()
        {
            return GetJourneyStatistics().OrderByDescending(o => o.TotalJourneys).ToList();
        }

        /*
         * Sort Methods
         */
        public void sortByRank(object sender, EventArgs e)
        {
            leaderboardList.SelectMethod = "getJourneyStatisticsByRank";
        }

        public void sortByName(object sender, EventArgs e)
        {
            leaderboardList.SelectMethod = "getJourneyStatisticsByUsername";
        }

        public void sortByTotal(object sender, EventArgs e)
        {
            leaderboardList.SelectMethod = "getJourneyStatisticsByTotal";
        }

        public void sortByDriver(object sender, EventArgs e)
        {
            leaderboardList.SelectMethod = "getJourneyStatisticsByDriver";
        }

        public void sortByPassenger(object sender, EventArgs e)
        {
            leaderboardList.SelectMethod = "getJourneyStatisticsByPassenger";
        }

        public void sortBySavings(object sender, EventArgs e)
        {
            leaderboardList.SelectMethod = "getJourneyStatisticsByFuel";
        }

        public string getUsernameByID(string id)
        {
            AspNetUserService userService = new AspNetUserService();
            var user = userService.retrieveUser(id);
            return user.FirstName + " " + user.LastName;
        }
        public void sortByTotalJourney(object sender, EventArgs e)
        {
            leaderboardList.SelectMethod = "getJourneyByJourneyTotal";
        }
    }
}


