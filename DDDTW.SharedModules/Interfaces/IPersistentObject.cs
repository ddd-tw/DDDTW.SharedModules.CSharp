namespace DDDTW.SharedModules.Interfaces
{
    public interface IPersistentObject<TId>
        where TId : IEntityId
    {
        TId Id { get; }
    }
}