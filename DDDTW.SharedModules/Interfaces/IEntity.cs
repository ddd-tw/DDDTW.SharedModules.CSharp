namespace DDDTW.SharedModules.Interfaces
{
    public interface IEntity<TId>
        where TId : IEntityId
    {
        TId Id { get; }
    }
}