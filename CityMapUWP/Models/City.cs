using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CityMapUWP.Models
{
    [DataContract()]
    public class City
    {
        [JsonProperty]
        [DataMember(Name = "id")]
        public int Id { get; set; }

        [JsonProperty]
        [DataMember(Name = "title")]
        public string Name { get; set; }

        [JsonProperty]
        [DataMember(Name = "description")]
        public string Description { get; set; }

        [JsonProperty]
        [DataMember(Name = "url")]
        public string ImageUrl { get; set; }

        [JsonProperty]
        [DataMember(Name = "latitude")]
        public double Latitude { get; set; }

        [JsonProperty]
        [DataMember(Name = "longitude")]
        public double Longitude { get; set; }
    }
}