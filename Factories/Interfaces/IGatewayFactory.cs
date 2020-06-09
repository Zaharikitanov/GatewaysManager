using GatewaysManager.Models.Database;
using GatewaysManager.Models.View;

namespace GatewaysManager.Factories.Interfaces
{
    public interface IGatewayFactory
    {
        Gateway Create(GatewayInputData viewData);
    }
}