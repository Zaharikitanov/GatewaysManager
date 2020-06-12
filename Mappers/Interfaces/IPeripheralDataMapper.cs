using GatewaysManager.Models.Database;
using GatewaysManager.Models.View;

namespace GatewaysManager.Mappers.Interfaces
{
    public interface IPeripheralDataMapper
    {
        PeripheralViewData MapToViewModel(Peripheral entity);
    }
}