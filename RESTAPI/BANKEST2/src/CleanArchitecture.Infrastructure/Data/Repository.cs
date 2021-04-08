using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using BANKEST2.Core.Interfaces;

namespace BANKEST2.Infrastructure.Data
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly AppDbContext _appDbContext;
        public Repository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public TEntity GetById(int id)
        {
            return _appDbContext.Set<TEntity>().Find(id);
        }
        public IEnumerable<TEntity> GetAll()
        {
            return _appDbContext.Set<TEntity>();
        }
        public IEnumerable<TEntity> GetFiltered(Expression<Func<TEntity, bool>> predicate)
        {
            return _appDbContext.Set<TEntity>().Where(predicate);
        }

        public void Add(TEntity entity)
        {
            _appDbContext.Set<TEntity>().Add(entity);
            _appDbContext.SaveChanges();
        }
        public void AddRange(IEnumerable<TEntity> entity)
        {
            _appDbContext.Set<TEntity>().AddRange(entity);
            _appDbContext.SaveChanges();
        }

        public void Remove(TEntity entity)
        {
            _appDbContext.Set<TEntity>().Remove(entity);
            _appDbContext.SaveChanges();
        }
        public void RemoveRange(IEnumerable<TEntity> entity)
        {
            _appDbContext.Set<TEntity>().RemoveRange(entity);
            _appDbContext.SaveChanges();
        }
    }
}
