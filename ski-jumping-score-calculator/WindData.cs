using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ski_jumping_score_calculator
{
    public class WindData
    {
        [JsonProperty("speed")]
        public double Speed { get; set; }

        [JsonProperty("deg")]
        public double Degree { get; set; }
    }
}
