using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.IO;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;
using TopSpotsAPI.Models;

namespace TopSpotsAPI.Controllers
{
    public class TopSpotsController : ApiController
    {
        //read /api/TopSpots
        public IEnumerable<TopSpot> Get()
        {
            // 1. get/read file into a string and deserialize JSON to a type
            TopSpot[] topspots = JsonConvert.DeserializeObject<TopSpot[]>(File.ReadAllText(@"C:\Users\wishi\Documents\OCA\13-TopSpotsAPI\TopSpotsAPI\TopSpotsAPI\topspots.json"));
            return topspots;
        }

        //create
        public TopSpotsAPI Post()
        {

        }

        //update

        //delete

        public void Delete()
        {

        }
    }
}