using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TestApp.Domain;
using TestApp.Domain.Entities;
using TestApp.Infrastructure;

namespace Infrastructure.RDBMS
{
    public class BaseRepository<TEntity> : IDisposable, IRepository<TEntity> where TEntity : class,  IEntityBase
    {
        protected readonly AppDbContext Context;
        protected DbSet<TEntity> Entities;

        public BaseRepository(AppDbContext context)
        {
            Context = context;
            Entities = context.Set<TEntity>();
        }

        public virtual IQueryable<TEntity> GetAll()
        {
            return Entities.AsQueryable();
        }

        public virtual async Task<TEntity> FindByIdAsync(params object[] keys)
        {
            return await Entities.FindAsync(keys);
        }

        public virtual async Task<TEntity> FindByCondition(Expression<Func<TEntity, bool>> predicate)
        {
            return await Entities.FirstOrDefaultAsync(predicate);
        }

        public virtual void Add(TEntity entity)
        {
            Entities.Add(entity);
        }

        public virtual void AddRange(IEnumerable<TEntity> entity)
        {
            Entities.AddRange(entity);
        }

        public virtual void Remove(TEntity entity)
        {
            Entities.Remove(entity);
        }


        public virtual void Update(TEntity entity)
        {
            Entities.Update(entity);
        }



        public async Task<int> SaveChangesAsync()
        {
            lock (Context)
            {
                 var result = Context.SaveChangesAsync().Result;
                return result;
            }
        }

        #region IDisposable Support
        private bool _disposedValue = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                if (disposing)
                {
                    Entities = null;
                }
                Context?.Dispose();
                _disposedValue = true;
            }
        }
        ~BaseRepository()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void RemoveRange(IEnumerable<TEntity> entity)
        {
            throw new NotImplementedException();
        }

        public Task Update(TEntity entity, IEnumerable<string> fieldMasks)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
