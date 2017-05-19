using SE_TeamZephyr.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SE_TeamZephyr.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "AreaService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select AreaService.svc or AreaService.svc.cs at the Solution Explorer and start debugging.
    public class AreaService : IAreaService
    {
        public void createArea(string areaName, string description)
        {
            using (Autom8DBAppContext11 DBContext = new Autom8DBAppContext11())
            {
                Area area = new Area()
                {
                    AreaName = areaName,
                    Description = description
                };
                DBContext.Areas.Add(area);
                DBContext.SaveChanges();
            }
        }

        public Area retrieveArea(int areaID)
        {
            using (Autom8DBAppContext11 DBContext = new Autom8DBAppContext11())
            {
                var area = DBContext.Areas.Where(a => a.AreaID == areaID).FirstOrDefault();
                if (area == new Area())
                {
                    throw new Exception();
                }
                return area;
            }
        }

        public List<Area> retrieveAllAreas()
        {
            using (Autom8DBAppContext11 DBContext = new Autom8DBAppContext11())
            {
                var areas = DBContext.Areas.ToList();
                if (areas.Count > 0)
                {
                    return areas;
                }
                return new List<Area>();
            }
        }

        public void updateArea(int areaID, string areaName, string description)
        {
            using (Autom8DBAppContext11 DBContext = new Autom8DBAppContext11())
            {
                var existingArea = DBContext.Areas.Single(a => a.AreaID == areaID);
                existingArea.AreaID = areaID;
                existingArea.AreaName = areaName;
                existingArea.Description = description;
                DBContext.SaveChanges();
            }
        }

        public void deleteArea(int areaID)
        {
            using (Autom8DBAppContext11 DBContext = new Autom8DBAppContext11())
            {
                DBContext.Areas.Remove(DBContext.Areas.Where(a => a.AreaID == areaID).First());
                DBContext.SaveChanges();
            }
        }
    }
}
