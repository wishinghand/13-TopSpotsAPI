using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.IO;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;
using TopSpotsAPI.Models;
using System.Web;

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

            //cameron's way
            //string fileName = HttpContext.Current.Server.MapPath("../topspots.json");
            //string json = File.ReadAllText(fileName)
            //IEnumerable<TopSpot> topSpots = JsonConvert.DeserializeObject<IEnumerable<TopSpot>>(json);
            //return topSpots;
        }

        //create
        public void Post([FromBody]TopSpot value)
       {
            // get file name
            string fileName = HttpContext.Current.Server.MapPath("../topspots.json");
            
            //read json from file system
            string json = File.ReadAllText(fileName);
            
            //deserialize
            List<TopSpot> topSpots = JsonConvert.DeserializeObject<List<TopSpot>>(json);
            
            //add to the list
            topSpots.Add(value);

            //turn list back into json
            json = JsonConvert.SerializeObject(topSpots);

            //save it to .json file
            File.WriteAllText(fileName, json);
        }

        //update
        public void Put(int id, [FromBody]TopSpot updatedTopSpot)
        {
            // get file name
            string fileName = HttpContext.Current.Server.MapPath("../topspots.json");

            //read json from file system
            string json = File.ReadAllText(fileName);

            //deserialize
            List<TopSpot> topSpots = JsonConvert.DeserializeObject<List<TopSpot>>(json);

            //find top spot to be udpated
          foreach (var topSpot in topSpots)
          {
              if(topSpot.Id == updatedTopSpot.Id)
              {
                  topSpot.Name = updatedTopSpot.Name;
                  topSpot.Description = updatedTopSpot.Description;
                  topSpot.Location = updatedTopSpot.Location;
              }
          }

            //modify the properties


            //turn list back into json
            json = JsonConvert.SerializeObject(topSpots);

            //save it to .json file
            File.WriteAllText(fileName, json);
        }

        //delete

        public void Delete(int id)
        {
            // get file name
            string fileName = HttpContext.Current.Server.MapPath("../topspots.json");

            //read json from file system
            string json = File.ReadAllText(fileName);

            //deserialize
            List<TopSpot> topSpots = JsonConvert.DeserializeObject<List<TopSpot>>(json);

            //find top spot to remove
            foreach (var topSpot in topSpots)
            {
                if(topSpot.Id == id)
                {
                    topSpots.Remove(topSpot);
                    break;
                }
            }

            //turn list back into json
            json = JsonConvert.SerializeObject(topSpots);

            //save it to .json file
            File.WriteAllText(fileName, json);

        }
    }
}