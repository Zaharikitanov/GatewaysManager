using GatewaysManager.Models;
using System.Net;

namespace GatewaysManager.Factories.Interfaces
{
    public interface IStatusCodeResultFactory
    {
        HttpStatusCode Create(EntityActionOutcome entityOutcome);
    }
}