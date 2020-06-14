using System;

namespace GatewaysManager.Models.Database
{
    public class Peripheral : Entity
    {
        public int UID { get; set; }

        public string Vendor { get; set; }

        public string DateCreated { get; set; }

        public Guid GatewayId { get; set; }

        public Gateway Gateway { get; set; }

        public DeviceStatus Status { get; set; }
    }
}
