using System.Net;
using GatewaysManager.Models.Outcomes;

namespace GatewaysManager.Factories.Interfaces
{
    public interface IStatusCodeResultFactory
    {
        HttpStatusCode Create(CreateEntityOutcome createEntityOutcome);
        HttpStatusCode Update(UpdateEntityOutcome updateEntityOutcome);
    }
}