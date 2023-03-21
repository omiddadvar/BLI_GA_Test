using BLI_GA_Test.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BLI_GA_Test.Repositories
{
    public class GenericRepository<TEntity> where TEntity : class
    {
        private TestEntities _db;
        private DbSet<TEntity> _dbSet;

        public GenericRepository(TestEntities db)
        {
            _db = db;
            _dbSet = _db.Set<TEntity>();
        }


        //Get All With Where
        public virtual IEnumerable<TEntity> Get(
            Expression<Func<TEntity, bool>> Where = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            params Expression<Func<TEntity, object>>[] includeProperties)
        {
            IQueryable<TEntity> query = _dbSet;

            if (Where != null)
            {
                query = query.Where(Where);
            }

            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }
            else
            {
                return query.ToList();
            }
        }
        public async virtual Task<IEnumerable<TEntity>> GetAsync(
            Expression<Func<TEntity, bool>> Where = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            params Expression<Func<TEntity, object>>[] includeProperties)
        {
            IQueryable<TEntity> query = _dbSet;

            if (Where != null)
            {
                query = query.Where(Where);
            }

            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                return await orderBy(query).ToListAsync();
            }
            else
            {
                return await query.ToListAsync();
            }
        }
        public virtual void Insert(TEntity entity)
        {
            _dbSet.Add(entity);
        }

        public virtual TEntity GetByID(object ID)
        {
            return _dbSet.Find(ID);
        }


        public virtual void Update(TEntity entity)
        {
            _dbSet.Attach(entity);
            _db.Entry(entity).State = EntityState.Modified;
        }

        public virtual void Delete(TEntity entity)
        {
            _dbSet.Attach(entity);
            _dbSet.Remove(entity);
        }

        public virtual void Delete(object ID)
        {
            var entity = GetByID(ID);
            Delete(entity);
        }
    }
}
