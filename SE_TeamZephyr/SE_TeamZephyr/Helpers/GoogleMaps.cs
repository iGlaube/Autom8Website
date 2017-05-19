using SE_TeamZephyr.Models;
using SE_TeamZephyr.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Xml;
using System.Xml.Linq;

namespace SE_TeamZephyr.Helpers
{
    public class GoogleMaps
    {
        // get the latitude longitude of input address
        public string[] latitudeLongitude(string address)
        {
            var requestUri = string.Format("http://maps.googleapis.com/maps/api/geocode/xml?address={0}&sensor=false", Uri.EscapeDataString(address));

            var request = WebRequest.Create(requestUri);
            var response = request.GetResponse();
            var xdoc = XDocument.Load(response.GetResponseStream());
            var result = xdoc.Element("GeocodeResponse").Element("result");
            var locationElement = result.Element("geometry").Element("location");
            char[] trim = { '<', '>', '/', 'l', 'a', 't', 'n', 'g' };
            string[] latLong = { locationElement.Element("lat").ToString().Trim(trim), locationElement.Element("lng").ToString().Trim(trim) };
            return latLong;
        }

        // Creates string array for Javascript that contains pickup points sorted by their distance from the origin
        public string getWaypoints(string departurePostcode, int journeyID)
        {
            JourneyPassengerService jps = new JourneyPassengerService();
            PayPalOrderDetailsService os = new PayPalOrderDetailsService();
            AspNetUserService us = new AspNetUserService();
            List<JourneyPassenger> finalList= new List<JourneyPassenger>();

            var allOrderDetails = os.retrieveAllPayPalOrderDetailss();

            // gets the journey passengers that are assigned to this journey that has been accepted
            var journeys = jps.retrieveAllJourneyPassengers().Where(jp => jp.JourneyID == journeyID && jp.pending == false && jp.accepted == true).ToArray();

            for (int i = 0; i < journeys.Length; i++)
            {
                // if the orderdetails table contains an entry for the passenger, add them to the final list 
                if (allOrderDetails.Where(a => a.JourneyID == journeys[i].JourneyID && a.Username == us.retrieveUser(journeys[i].passengerID).UserName).ToList().Count > 0)
                {
                    finalList.Add(journeys[i]);
                }
            }

            string latlongs = "[";

            if (finalList.Count > 0)
            {
                //add to double object array the distance and pickup point postcode and sorts
                object[,] journeysWithDistance = new object[finalList.Count, 2];
                for (int i = 0; i < finalList.Count; i++)
                {
                    journeysWithDistance[i, 0] = getDistance(departurePostcode, finalList[i].pickupPointPostcode);
                    journeysWithDistance[i, 1] = finalList[i].pickupPointPostcode;
                }
                object[,] sortedJourneysByDistance = journeysWithDistance.OrderBy(x => x[0]);

                //creates array within string for JavaScript frontend of latitude and longitude of pickup point postcode
                for (int i = 0; i < finalList.Count; i++)
                {
                    var waypoint = latitudeLongitude(sortedJourneysByDistance[i, 1].ToString());
                    latlongs += "[" + waypoint[0] + ",";
                    latlongs += waypoint[1] + "]";
                    if (i != journeys.Length - 1)
                    {
                        latlongs += ",";
                    }
                }
                latlongs += "]";
                return latlongs;
            }
            else
            {
                return "[]";
            }
        }

        // gets the distance between two points
        public double getDistance(string origin, string destination)
        {
            string url = @"http://maps.googleapis.com/maps/api/distancematrix/xml?origins=" + origin + "&destinations=" + destination + "&sensor=false";

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            WebResponse response = request.GetResponse();
            Stream dataStream = response.GetResponseStream();
            StreamReader sreader = new StreamReader(dataStream);
            string responsereader = sreader.ReadToEnd();
            response.Close();

            XmlDocument xmldoc = new XmlDocument();
            xmldoc.LoadXml(responsereader);

            //if the request was ok return distance
            if (xmldoc.GetElementsByTagName("status")[0].ChildNodes[0].InnerText == "OK")
            {
                XmlNodeList distance = xmldoc.GetElementsByTagName("distance");
                return Convert.ToDouble(distance[0].ChildNodes[1].InnerText.Replace(" km", ""));
            }
            return 0;
        }
    }
}