using Core.API.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Data.API.Repositories.Abstract
{
    public interface IGenericRepository<T> where T : class,IEntityBase,new()
    {
        Task<List<T>> GetAllAync(Expression<Func<T,bool>> predicate = null,params Expression<Func<T, object>>[] includePredicate);
        Task<T> GetIdListAsync(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includePredicate);
        Task<T> GetByID(int id);
        Task AddAsync(T entity);
        void Delete(T entity);
        T Update(T entity);
    }
}
