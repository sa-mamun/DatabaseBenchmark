using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseBenchmark.Core.Repositories
{
    public interface IRepository<T>
    {
        void Insert(List<T> entity);
        void Update(T entity);
        void Delete(T entity);
        T GetById(int id);
        IList<T> GetList();
        IList<T> GetList(Expression<Func<T, bool>> predicate = null);
        int GetCount(Expression<Func<T, bool>> predicate = null);
    }
}
