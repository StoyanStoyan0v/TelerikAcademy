﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Countries.Data.Repositories
{
    using Countries.Data;
    using System;
    using System.Data.Entity;
    using System.Linq;
    using System.Linq.Expressions;
    using Countries.Repositories;

    public class GenericRepository<T> : IGenericRepository<T>
        where T : class
    {
        private readonly ICountriesContext context;

        public GenericRepository(ICountriesContext context)
        {
            this.context = context;
        }

        public IQueryable<T> All()
        {
            return this.context.Set<T>();
        }

        public IQueryable<T> SearchFor(Expression<Func<T, bool>> conditions)
        {
            return this.All().Where(conditions);
        }

        public void Add(T entity)
        {
            this.ChangeState(entity, EntityState.Added);
        }

        public void Update(T entity)
        {
            this.ChangeState(entity, EntityState.Modified);
        }

        public T Delete(T entity)
        {
            this.ChangeState(entity, EntityState.Deleted);
            return entity;
        }

        public void Detach(T entity)
        {
            this.ChangeState(entity, EntityState.Detached);
        }

        private void ChangeState(T entity, EntityState state)
        {
            this.context.Set<T>().Attach(entity);
            this.context.Entry(entity).State = state;
        }

        public void SaveChanges()
        {
            this.context.SaveChanges();
        }
    }
}