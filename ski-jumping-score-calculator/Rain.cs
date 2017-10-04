using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace ski_jumping_score_calculator
{
    public class Rain
    {
        [JsonProperty("3h")]
        public double RainVolume3h { get; set; }
    }
}
