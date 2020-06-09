using Newtonsoft.Json;
using System;

namespace GatewaysManager.Models.View
{
    public class PeripheralViewData : PeripheralInputData
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }

        [JsonProperty("dateCreated")]
        public string DateCreated { get; set; }
    }
}
