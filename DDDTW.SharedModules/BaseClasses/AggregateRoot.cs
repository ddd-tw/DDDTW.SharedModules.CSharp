using System.Collections.Generic;
using DDDTW.SharedModules.Interfaces;

namespace DDDTW.SharedModules.BaseClasses
{
    public class AggregateRoot<TId> : Entity<TId>
        where TId : IEntityId
    {
        private readonly List<DomainEvent> domainEvents = new List<DomainEvent>();
        public IReadOnlyCollection<DomainEvent> DomainEvents => this.domainEvents;

        protected void RaiseEvent(DomainEvent @evt)
        {
            this.domainEvents.Add(@evt);
        }
    }
}