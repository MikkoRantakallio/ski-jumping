using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace ski_jumping_score_calculator
{
    public class WeatherDescription
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("main")]
        public string WeatherParameterGroupID { get; set; }

        [JsonProperty("description")]
        public string GroupWeatherCondition { get; set; }

        [JsonProperty("icon")]
        public string Icon { get; set; }
    }
}
