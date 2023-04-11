using Core.API.Entity;
using Data.API.Context;
using Data.API.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Data.API.Repositories.Cocrate
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class, IEntityBase, new()
    {
        private readonly DbContext _context;
        public GenericRepository(AppDbContext context)
        {
            _context = context;
        }

        public DbSet<T> Table { get => _context.Set<T>(); }

        public async Task AddAsync(T entity)
        {
            await Table.AddAsync(entity);
           
        }

        public void Delete(T entity)
        {
           Table.Remove(entity);
        }

        public async Task<T> GetIdListAsync(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includePredicate)
        {
            IQueryable<T> query = Table;
              query = query.Where(predicate);
           
            if(includePredicate.Any())
            {
                foreach (var item in includePredicate)
                {
                    query = query.Include(item);
                }
            }

            return await query.FirstOrDefaultAsync();
        }

        public async Task<List<T>> GetAllAync(Expression<Func<T, bool>> predicate = null, params Expression<Func<T, object>>[] includePredicate)
        {
            IQueryable<T> query = Table;
            if (predicate != null)
            {
                query = query.Where(predicate);
            }

            if (includePredicate.Any())
            {
                foreach (var item in includePredicate)
                {
                    query = query.Include(item);
                }
            }

            return await query.ToListAsync();
        }

        public async Task<T> GetByID(int id)
        {
           var entity = await Table.FindAsync(id);
            if(entity != null)
            {
                _context.Entry(entity).State = EntityState.Detached;
            }
            return entity;
        }

        public T Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            return entity;
        }
    }
}
