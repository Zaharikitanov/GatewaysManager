using Newtonsoft.Json;

namespace GatewaysManager.Models.View
{
    public class GatewayInputData
    {
        [JsonProperty("serialNumber")]
        public string SerialNumber { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("ipv4")]
        public string IPv4 { get; set; }
    }
}
