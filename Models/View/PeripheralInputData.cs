using Newtonsoft.Json;

namespace GatewaysManager.Models.View
{
    public class PeripheralInputData
    {
        [JsonProperty("uid")]
        public int UID { get; set; }

        [JsonProperty("vendor")]
        public string Vendor { get; set; }

        [JsonProperty("gatewayId")]
        public string GatewayId { get; set; }

        [JsonProperty("status")]
        public DeviceStatus Status { get; set; }
    }
}
