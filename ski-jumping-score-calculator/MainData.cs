using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace ski_jumping_score_calculator
{
    public class MainData
    {
        [JsonProperty("temp")]
        public double Temperature { get; set; }

        [JsonProperty("pressure")]
        public double Pressure { get; set; }

        [JsonProperty("humidity")]
        public int Humidity { get; set; }

        [JsonProperty("temp_min")]
        public double Temperature_min { get; set; }

        [JsonProperty("temp_max")]
        public double Temperature_max { get; set; }

        [JsonProperty("sea_level")]
         public double SeaLevel { get; set; }

        [JsonProperty("grnd_level")]
        public double GroundLevel { get; set; }

        [JsonProperty("temp_kf")]
        public double tempKf { get; set; }
    }
}
