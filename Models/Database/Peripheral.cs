namespace GatewaysManager.Models.Database
{
    public class Peripheral : Entity
    {
        public int UID { get; set; }

        public string Vendor { get; set; }

        public string DateCreated { get; set; }

        public string GatewayId { get; set; }

        public Gateway Gateway { get; set; }

        public DeviceStatus Status { get; set; }
    }
}
