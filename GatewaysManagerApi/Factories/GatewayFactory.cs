using GatewaysManager.Factories.Interfaces;
using GatewaysManager.Models.Database;
using GatewaysManager.Models.View;

namespace GatewaysManager.Factories
{
    public class GatewayFactory : IGatewayFactory
    {
        public Gateway Create(GatewayInputData viewData)
        {
            return new Gateway
            {
                SerialNumber = viewData.SerialNumber,
                Name = viewData.Name,
                IPv4 = viewData.IPv4 
            };
        }
    }
}
