﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Services.Utilities.Common;

namespace Services.Utilities.DataAccess
{
    public interface IRepository<TEntity> : IDisposable where TEntity : class
    {
        TEntity FindById(object id);
        void Update(TEntity entity);
        void Delete(object id);
        void Delete(TEntity entity);
        void Insert(TEntity entity);
        RepositoryQuery<TEntity> Query();

    }

    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        internal DbContext Context;
        internal DbSet<TEntity> DbSet;

        public Repository(DbContext context)
        {
            Context = context;
            DbSet = context.Set<TEntity>();
        }

        public virtual TEntity FindById(object id)
        {
            return DbSet.Find(id);
        }

 
        public virtual void Insert(TEntity entity)
        {
 
            DbSet.Add(entity);
        }

        /// <summary>
        /// Update just the root entity unless 
        /// </summary>
        /// <param name="entity"></param>
        public virtual void Update(TEntity entity)
        {
            EntityEntry dbEntityEntry = Context.Entry(entity);
            DbSet.Update(entity);
       }

        public virtual void Delete(object id)
        {
            var entity = DbSet.Find(id);

            if (entity != null)
                Delete(entity);
        }

        public virtual void Delete(TEntity entity)
        {
 
            EntityEntry dbEntityEntry = Context.Entry(entity);
            
        }

        public virtual RepositoryQuery<TEntity> Query()
        {
            var repositoryGetFluentHelper =
                new RepositoryQuery<TEntity>(this);

            return repositoryGetFluentHelper;
        }

        /// <summary>
        /// Repository Get method is accessable inside the repository assembly
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="orderBy"></param>
        /// <param name="includeProperties"></param>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        internal IQueryable<TEntity> Get(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            List<Expression<Func<TEntity, object>>> includeProperties = null,
            int? page = null,
            int? pageSize = null)
        {
            IQueryable<TEntity> query = DbSet;

            if (includeProperties != null)
                includeProperties.ForEach(i => { query = query.Include(i); });

            if (filter != null)
                query = query.Where(filter);

            if (orderBy != null)
                query = orderBy(query);

            if (page != null && pageSize != null)
                query = query
                    .Skip((page.Value - 1) * pageSize.Value)
                    .Take(pageSize.Value);

            return query;
        }

        #region New accessor methods on Repository

        public TEntity Find(object id)
        {
            return DbSet.Find(id);
        }
        #endregion

        public void Dispose()
        {
            Context.Dispose();
        }
    }
}