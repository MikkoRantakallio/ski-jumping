using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ski_jumping_score_calculator
{
    public class Geolocation
    {
        [JsonProperty("lon")]
        public double Longitude { get; set; }

        [JsonProperty("lat")]
        public double Latitude { get; set; }
    }
}
