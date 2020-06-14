using GatewaysManager.Factories.Interfaces;
using GatewaysManager.Models;
using System.Net;

namespace GatewaysManager.Factories
{
    public class StatusCodeResultFactory : IStatusCodeResultFactory
    {
        public HttpStatusCode Create(EntityActionOutcome entityOutcome)
        {
            switch (entityOutcome)
            {
                case EntityActionOutcome.Success:
                    return HttpStatusCode.OK;

                case EntityActionOutcome.CreateFailed:
                case EntityActionOutcome.UpdateFailed:
                    return HttpStatusCode.Conflict;

                case EntityActionOutcome.MissingFullEntityData:
                    return HttpStatusCode.UnprocessableEntity;

                case EntityActionOutcome.PeripheralsLimitReached:
                    return HttpStatusCode.NotAcceptable;

                case EntityActionOutcome.EntityNotFound:
                    return HttpStatusCode.NotFound;

                default:
                    return HttpStatusCode.InternalServerError;
            }
        }
    }
}
