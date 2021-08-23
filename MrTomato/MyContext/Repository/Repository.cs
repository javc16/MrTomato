using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MrTomato.MyContext.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly AppContext _context;

        public Repository(AppContext context)
        {
            _context = context;
        }

        public async Task<TEntity> GetById(int id)
        {
            var entity = await _context.Set<TEntity>().FindAsync(id);
           
            if (entity != null) 
            {
                _context.Entry(entity).State = EntityState.Detached;
                return entity;
            }
            return null;
            
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _context.Set<TEntity>().ToList();
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return _context.Set<TEntity>().Where(predicate);
        }

        public void Add(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
        }

        public TEntity Update(TEntity entity)
        {
            //_context.Set<TEntity>().Attach(entity);
            // var entry = _context.Entry(entity);
            //entry.State = EntityState.Modified;
            _context.Entry(entity).State = EntityState.Modified;
           
            return entity;
        }

        public void AddRange(IEnumerable<TEntity> entities)
        {
            _context.Set<TEntity>().AddRange(entities);
        }   

        public void Remove(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            _context.Set<TEntity>().RemoveRange(entities);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
