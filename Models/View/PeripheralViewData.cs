using Newtonsoft.Json;

namespace GatewaysManager.Models.View
{
    public class PeripheralViewData : PeripheralInputData
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("dateCreated")]
        public string DateCreated { get; set; }
    }
}
