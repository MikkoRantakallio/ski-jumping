using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace ski_jumping_score_calculator
{
    public class Clouds
    {
        [JsonProperty("all")]
        public double CloudinessPercentage { get; set; }
    }
}
