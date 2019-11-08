using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DDDTW.SharedModules.BaseClasses;

namespace DDDTW.SharedModules.Interfaces
{
    public interface IRepository<Tpo, Tdm, Tid>
        where Tpo : class, IPersistentObject
        where Tid : EntityId
        where Tdm : AggregateRoot<Tid>
    {
        Tid GenerateId();

        ValueTask<IEnumerable<Tresult>> Get<Tresult>(
            Expression<Func<Tpo, Tresult>> selector = null,
            Expression<Func<Tpo, bool>> predicate = null,
            int pageNo = 1, int pageSize = 10)
            where Tresult : class, new();

        Task<long> Count(Expression<Func<Tpo, bool>> predicate = null);

        ValueTask<Tresult> GetBy<Tresult>(
            Expression<Func<Tpo, Tresult>> selector = null,
            Expression<Func<Tpo, bool>> predicate = null)
            where Tresult : class;

        ValueTask<Tdm> GetBy(Expression<Func<Tpo, bool>> predicate = null);

        Task<bool> Any(Expression<Func<Tpo, bool>> predicate = null);

        ValueTask<int> SaveChanges(Tdm domainModel);

        Task<int> Delete(Tdm domainModel);
    }
}