using Newtonsoft.Json;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace CityMapUWP.Models
{
    [DataContract()]
    public sealed class AppData
    {
        [JsonProperty]
        [DataMember(Name = "photos")]
        public IEnumerable<City> Cities { get; set; }
    }
}
