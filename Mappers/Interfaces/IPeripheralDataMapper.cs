using GatewaysManager.Models.Database;
using GatewaysManager.Models.View;

namespace GatewaysManager.Mappers.Interfaces
{
    public interface IPeripheralDataMapper
    {
        Peripheral MapToDataModel(PeripheralInputData entity);
        PeripheralViewData MapToViewModel(Peripheral entity);
    }
}