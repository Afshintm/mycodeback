 using Microsoft.EntityFrameworkCore; 
using System.Collections.Generic; 

namespace Essence.Communication.DataAccessLayer
{
    public interface IRepository<TEntity> where TEntity : class
    {
        TEntity Get(int id);
        IEnumerable<TEntity> GetAll();
        void Add(TEntity entity);
        void Remove(TEntity entity);
        int Complete();
    }

    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly DbContext _context;

        public Repository(DbContext context)
        {
            _context = context;
        }

        public void Add(TEntity entity)
        {
            _context.Add(entity);
        }

        public TEntity Get(int id)
        {
            return _context.Set<TEntity>().Find(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _context.Set<TEntity>();
        }

        public void Remove(TEntity entity)
        {
        
        }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        
    }
}
