using System.Collections.Generic;

namespace DDDTW.SharedModules.BaseClasses
{
    public class AggregateRoot<TId> : Entity<TId>
        where TId : EntityId
    {
        private readonly List<DomainEvent> domainEvents = new List<DomainEvent>();
        public IReadOnlyCollection<DomainEvent> DomainEvents => this.domainEvents;

        protected void RaiseEvent(DomainEvent @evt)
        {
            this.domainEvents.Add(@evt);
        }
    }
}