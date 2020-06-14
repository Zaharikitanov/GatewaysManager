using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace GatewaysManager.Models.View
{
    public class GatewayViewData : GatewayInputData
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }

        [JsonProperty("peripherals")]
        public List<PeripheralViewData> Peripherals { get; set; }
    }
}
