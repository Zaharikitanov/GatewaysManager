using GatewaysManager.Factories.Interfaces;
using GatewaysManager.Models.Database;
using GatewaysManager.Models.View;
using System;

namespace GatewaysManager.Factories
{
    public class PeripheralFactory : IPeripheralFactory
    {
        public Peripheral Create(PeripheralInputData viewData)
        {
            return new Peripheral
            {
                UID = viewData.UID,
                Vendor = viewData.Vendor,
                GatewayId = viewData.GatewayId,
                Status = viewData.Status,
                DateCreated = DateTime.Now.ToString()
            };
        }
    }
}
