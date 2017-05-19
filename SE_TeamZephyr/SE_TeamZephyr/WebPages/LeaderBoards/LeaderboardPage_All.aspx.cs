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
    public partial class LeaderboardPage_All : System.Web.UI.Page
    {
        JourneyStatisticsAllService jdsa = new JourneyStatisticsAllService();

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        public List<JourneyStatisticsAll> GetJourneyStatistics()
        {
            var jStats = jdsa.retrieveAllJourneyStatisticsAll();
            return jStats;
        }
        public List<JourneyStatisticsAll> getJourneyStatisticsByRank()
        {
            return GetJourneyStatistics().OrderBy(o => o.JourneyStatisticsID).ToList();
        }

        public List<JourneyStatisticsAll> getJourneyStatisticsByName()
        {
            return GetJourneyStatistics().OrderBy(o => o.Name).ToList();
        }
        public List<JourneyStatisticsAll> getJourneyStatisticsByJourneys()
        {
            return GetJourneyStatistics().OrderByDescending(o => o.TotalJourneys).ToList();
        }
        public List<JourneyStatisticsAll> getJourneyStatisticsByDistance()
        {
            return GetJourneyStatistics().OrderBy(o => o.TotalDistance).ToList();
        }

        /*
         * Sort Methods
         */
        public void sortByRank(object sender, EventArgs e)
        {
            leaderboardListAll.SelectMethod = "getJourneyStatisticsByRank";
        }

        public void sortByName(object sender, EventArgs e)
        {
            leaderboardListAll.SelectMethod = "getJourneyStatisticsByName";
        }

        public void sortByTotalJourney(object sender, EventArgs e)
        {
            leaderboardListAll.SelectMethod = "getJourneyStatisticsByJourneys";
        }

        public void sortByDistance(object sender, EventArgs e)
        {
            leaderboardListAll.SelectMethod = "getJourneyStatisticsByDistance";
        }
    }
}




