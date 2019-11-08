using System;

namespace DDDTW.SharedModules.BaseClasses
{
    public class DomainEvent
    {
        protected DomainEvent()
        {
            this.EventId = Guid.NewGuid();
            this.OccuredDate = DateTimeOffset.Now;
        }

        public Guid EventId { get; private set; }

        public DateTimeOffset OccuredDate { get; private set; }
    }
}