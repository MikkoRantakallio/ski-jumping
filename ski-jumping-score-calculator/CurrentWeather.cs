using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ski_jumping_score_calculator
{
    // Current weather 
    public class CurrentWeather
    {
        [JsonProperty("name")]
        public string LocationName { get; set; }

        [JsonProperty("id")]
        public string LocationId { get; set; }

        [JsonProperty("coord")]
        public Geolocation Geolocation { get; set; }

        [JsonProperty("main")]
        public MainData MainData { get; set; }

        [JsonProperty("wind")]
        public WindData Wind { get; set; }

        [JsonProperty("weather")]
        public List<WeatherDescription> Descriptions { get; set; }

        [JsonProperty("base")]
        public string Base { get; set; }

        [JsonProperty("clouds")]
        public Clouds Clouds { get; set; }

        [JsonProperty("rain")]
        public Rain Rain { get; set; }

        [JsonProperty("snow")]
        public Snow Snow { get; set; }

        [JsonProperty("dt")]
        public string TimeStamp { get; set; }

        [JsonProperty("sys")]
        public WSystem System { get; set; }

        [JsonProperty("cod")]
        public string Cod { get; set; }

        [JsonProperty("dt_txt")]
        public string TimeTxt { get; set; }
    }
}
