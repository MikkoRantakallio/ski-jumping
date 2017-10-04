using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace ski_jumping_score_calculator
{
    public class Snow
    {
        [JsonProperty("3h")]
        public double SnowVolume3h { get; set; }
    }
}
