using GatewaysManager.Factories.Interfaces;
using GatewaysManager.Mappers.Interfaces;
using GatewaysManager.Models.Database;
using GatewaysManager.Models.View;

namespace GatewaysManager.Factories
{
    public class GatewayFactory : IGatewayFactory
    {
        private IGatewayDataMapper _mapper;

        public GatewayFactory(IGatewayDataMapper mapper)
        {
            _mapper = mapper;
        }

        public Gateway Create(GatewayInputData viewData)
        {
            return _mapper.MapToDataModel(viewData);
        }
    }
}
