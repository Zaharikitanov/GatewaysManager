namespace GatewaysManager.Models
{
    public enum EntityActionOutcome
    {
        Success,
        EntityNotFound,
        PeripheralsLimitReached,
        UpdateFailed,
        MissingFullEntityData,
        CreateFailed
    }
}
