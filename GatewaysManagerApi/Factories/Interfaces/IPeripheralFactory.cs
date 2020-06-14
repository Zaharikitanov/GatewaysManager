using GatewaysManager.Models.Database;
using GatewaysManager.Models.View;

namespace GatewaysManager.Factories.Interfaces
{
    public interface IPeripheralFactory
    {
        Peripheral Create(PeripheralInputData viewData);
    }
}