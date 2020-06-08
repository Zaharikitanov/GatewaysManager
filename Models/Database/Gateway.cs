using System.Collections.Generic;

namespace GatewaysManager.Models.Database
{
    public class Gateway : Entity
    {
        public string SerialNumber { get; set; }

        public string Name { get; set; }

        public string IPv4 { get; set; }

        public List<Peripheral> Peripherals { get; set; } = new List<Peripheral>();
    }
}
