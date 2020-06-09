using GatewaysManager.Models.Database;
using GatewaysManager.Models.View;

namespace GatewaysManager.Mappers.Interfaces
{
    public interface IGatewayDataMapper
    {
        Gateway MapToDataModel(GatewayInputData entity);
        GatewayViewData MapToViewModel(Gateway entity);
    }
}