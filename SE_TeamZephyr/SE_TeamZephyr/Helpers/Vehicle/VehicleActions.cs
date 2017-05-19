using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;

namespace SE_TeamZephyr.Helpers
{
    public class VehicleActions
    {
        // Used from UKVehicleData {Dependency}



        public VehicleJson.VehicleJson getVehicleData(string licencePlate)
        {
            // Add Package Name & Vehicle Registration Mark into the request URL
            string url = String.Format("https://uk1.ukvehicledata.co.uk/api/datapackage/{0}?v=2&api_nullitems=1&key_vrm={1}", "VehicleData", licencePlate.Replace(" ", String.Empty));
            // Note your package name here. There are 5 standard packagenames. Please see your control panel > weblookup or contact your account manager

            // Create Web Request
            WebRequest request = WebRequest.Create(url);

            // Specify the format of data returned
            request.ContentType = "application/json; charset=utf-8";

            // Required Authorization Header
            request.Headers.Add("authorization", "ukvd-ipwhitelist e1fc470f-59c8-4223-b845-e9064dbd491a");

            // This Header Forces caches to submit the request to the server for validation, before releasing a cached copy
            request.Headers.Add("cache-control", "no-cache");


            // Create Web Response
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            // Construct a StreamReader
            string stream;
            using (StreamReader streamRdr = new StreamReader(response.GetResponseStream()))
            {
                stream = streamRdr.ReadToEnd();
            }

            JToken token = JObject.Parse(stream);

            var height = token.SelectToken("Height");

            if (height != null)
            {
                // Deserialize Stream
                VehicleJson.VehicleJson vehicle = JsonConvert.DeserializeObject<VehicleJson.VehicleJson>(stream);
                // Finally, for demonstration purposes - Output Deserialized Stream to ASP Label Control (ID= "Output")
                return vehicle;
            }
            else
            {
                return new VehicleJson.VehicleJson();
            }
        }
    }
}