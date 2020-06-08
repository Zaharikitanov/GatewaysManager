using Newtonsoft.Json;
using System.Collections.Generic;

namespace GatewaysManager.Models.View
{
    public class GatewayViewData : GatewayInputData
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("peripherals")]
        public List<PeripheralViewData> Peripherals { get; set; }
    }
}
