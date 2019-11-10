using DDDTW.SharedModules.BaseClasses;

namespace DDDTW.SharedModules.Interfaces
{
    public interface IEntity<TId>
        where TId : EntityId
    {
        TId Id { get; }
    }
}