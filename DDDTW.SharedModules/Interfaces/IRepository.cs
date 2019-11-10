using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using DDDTW.SharedModules.BaseClasses;

namespace DDDTW.SharedModules.Interfaces
{
    public interface IRepository<Tpo, Tdm, Tid>
        where Tpo : class, IPersistentObject<Tid>
        where Tid : EntityId
        where Tdm : AggregateRoot<Tid>
    {
        ValueTask<IEnumerable<Tresult>> Get<Tresult>(
            Expression<Func<Tpo, Tresult>> selector = null,
            Expression<Func<Tpo, bool>> predicate = null,
            int pageNo = 1, int pageSize = 10)
            where Tresult : class, new();

        ValueTask<long> Count(Expression<Func<Tpo, bool>> predicate = null);

        ValueTask<Tresult> GetBy<Tresult>(
            Expression<Func<Tpo, Tresult>> selector = null,
            Expression<Func<Tpo, bool>> predicate = null)
            where Tresult : class;

        ValueTask<Tdm> GetBy(Expression<Func<Tpo, bool>> predicate = null);

        ValueTask<bool> Any(Expression<Func<Tpo, bool>> predicate = null);

        Task SaveChanges(Tdm domainModel);

        Task Remove(Tdm domainModel);
    }
}