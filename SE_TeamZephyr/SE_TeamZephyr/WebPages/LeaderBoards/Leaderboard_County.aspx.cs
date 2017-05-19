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
    public partial class Leaderboard_County : System.Web.UI.Page
    {
        JourneyStatisticsGlobalService jdsa = new JourneyStatisticsGlobalService();

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        public List<JourneyStatisticsGlobal> GetJourneyStatistics()
        {
            var jStats = jdsa.retrieveAllJourneyStatisticsGlobal();
            return jStats;
        }
        public List<JourneyStatisticsGlobal> getJourneyStatisticsByRank()
        {
            return GetJourneyStatistics().OrderBy(o => o.JourneyStatisticsID).ToList();
        }

        public List<JourneyStatisticsGlobal> getJourneyStatisticsByName()
        {
            return GetJourneyStatistics().OrderBy(o => o.AreaID).ToList();
        }
        public List<JourneyStatisticsGlobal> getJourneyStatisticsByJourneys()
        {
            return GetJourneyStatistics().OrderByDescending(o => o.TotalJourneys).ToList();
        }
        public List<JourneyStatisticsGlobal> getJourneyStatisticsByDistance()
        {
            return GetJourneyStatistics().OrderBy(o => o.TotalDistance).ToList();
        }

        /*
         * Sort Methods
         */
        public void sortByRank(object sender, EventArgs e)
        {
            leaderboardListCounty.SelectMethod = "getJourneyStatisticsByRank";
        }

        public void sortByName(object sender, EventArgs e)
        {
            leaderboardListCounty.SelectMethod = "getJourneyStatisticsByName";
        }

        public void sortByTotal(object sender, EventArgs e)
        {
            leaderboardListCounty.SelectMethod = "getJourneyStatisticsByJourneys";
        }

        public void sortByDistance(object sender, EventArgs e)
        {
            leaderboardListCounty.SelectMethod = "getJourneyStatisticsByDistance";
        }

        public string getAreaName(int id)
        {
            AreaService aService = new AreaService();
            var area = aService.retrieveArea(id);
            return area.AreaName;
        }
    }
}


