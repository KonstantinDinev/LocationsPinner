﻿using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TravelRecord.Helpers;

namespace TravelRecord.Model
{
    public class LabeledLatLng
    {
        public string label { get; set; }
        public double lat { get; set; }
        public double lng { get; set; }
    }

    public class Category
    {
        public string name { get; set; }
        public string id { get; set; }
        public string pluralName { get; set; }
        public string shortName { get; set; }
        //ICON class
        public bool primary { get; set; }
    }

    public class Location
    {
        public string address { get; set; }
        public string crossStreet { get; set; }
        public double lat { get; set; }
        public double lng { get; set; }
        public List<LabeledLatLng> labeledLatLngs { get; set; }
        public int distance { get; set; }
        public string postalCode { get; set; }
        public string cc { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string country { get; set; }
        public List<string> formattedAddress { get; set; }
        public string neighborhood { get; set; }
    }

    public class Venue
    {
        public string id { get; set; }
        public string name { get; set; }
        public Location location { get; set; }
        public List<Category> categories { get; set; }
        public string referralId { get; set; }
        public bool hasPerk { get; set; }

        public async static Task<List<Venue>> GetVenues(double latitude, double longitude)
        {
            List<Venue> venues = new List<Venue>();

            var url = VenueRoot.GenerateURL(latitude, longitude);

            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync(url);
                var json = await response.Content.ReadAsStringAsync();

                var venueRoot = JsonConvert.DeserializeObject<VenueRoot>(json);

                venues = venueRoot.response.venues as List<Venue>;
            }

            return venues;
        }
    }

    public class Response
    {
        public List<Venue> venues { get; set; }
        public bool confident { get; set; }
    }


    // !Important
    public class VenueRoot
    {
        public Response response { get; set; }

        public static string GenerateURL(double latitude, double longitude)
        {
            string url = string.Format(Constants.VENUE_SEARCH, latitude, longitude, 
                                       Helpers.Constants.CLIENT_ID, Constants.CLIENT_SECRET, DateTime.Now.ToString("yyyyMMdd"));

            return url;
        }
    }
}
