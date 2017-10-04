using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace ski_jumping_score_calculator
{
    public class WSystem
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("sunrise")]
        public string Sunrise { get; set; }

        [JsonProperty("sunset")]
        public string Sunset { get; set; }

        [JsonProperty("pod")]
        public string Pod { get; set; }
    }
}
