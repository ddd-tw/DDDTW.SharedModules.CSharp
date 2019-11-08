using System.Collections.Generic;

namespace DDDTW.SharedModules.BaseClasses
{
    public abstract class Entity<TId> : IEqualityComparer<Entity<TId>>
        where TId : EntityId
    {
        public TId Id { get; protected set; }

        protected virtual object Self => this;

        public override bool Equals(object obj)
        {
            var other = obj as Entity<TId>;

            if (other is null) return false;

            if (ReferenceEquals(this, other)) return true;

            if (this.Self.GetType() != other.Self.GetType()) return false;

            return this.Id == other.Id;
        }

        public override int GetHashCode()
        {
            return (this.GetType(), this.Id).GetHashCode();
        }

        public static bool operator ==(Entity<TId> left, Entity<TId> right)
        {
            if (left is null && right is null) return true;

            if (left is null || right is null) return false;

            return left.Equals(right);
        }

        public static bool operator !=(Entity<TId> left, Entity<TId> right)
        {
            return !(left == right);
        }

        public bool Equals(Entity<TId> left, Entity<TId> right)
        {
            return left == right;
        }

        public int GetHashCode(Entity<TId> obj)
        {
            return obj.GetHashCode();
        }
    }
}