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
    public class AppData
    {
        [JsonProperty]
        [DataMember(Name = "photos")]
        public IEnumerable<City> Cities { get; set; }
    }
}

