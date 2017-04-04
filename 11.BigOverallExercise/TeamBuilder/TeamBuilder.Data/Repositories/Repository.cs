namespace TeamBuilder.App.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Linq.Expressions;
    using TeamBuilder.App.Contracts;

    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly DbContext Context;

        public Repository(DbContext context)
        {
            this.Context = context;
        }

        public void Add(TEntity entity)
        {
            this.Context.Set<TEntity>().Add(entity);
        }

        public void AddRange(IEnumerable<TEntity> entities)
        {
            this.Context.Set<TEntity>().AddRange(entities);
        }

        public bool Any(Expression<Func<TEntity, bool>> predicate)
        {
            return this.Context.Set<TEntity>().Any(predicate);
        }

        public void Delete(TEntity entity)
        {
            this.Context.Set<TEntity>().Remove(entity);
        }

        public void DeleteRange(IEnumerable<TEntity> entities)
        {
            this.Context.Set<TEntity>().RemoveRange(entities);
        }

        public IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return this.Context.Set<TEntity>().Where(predicate);
        }

        public TEntity FirstOrDefault(Expression<Func<TEntity, bool>> predicate)
        {
            return this.Context.Set<TEntity>().FirstOrDefault(predicate);
        }

        public TEntity GetById(int id)
        {
            return this.Context.Set<TEntity>().Find(id);
        }

        public TEntity GetById(Expression<Func<TEntity, bool>> predicate)
        {
            return this.Context.Set<TEntity>().FirstOrDefault(predicate);
        }

        public TEntity GetByName(Expression<Func<TEntity, bool>> predicate)
        {
            return this.Context.Set<TEntity>().FirstOrDefault(predicate);
        }

        public IQueryable<TEntity> Include(string v)
        {
            return this.Context.Set<TEntity>().Include(v);
        }
        //public IQueryable<Order> GetAll(params Expression<Func<CandidateTest, object>>[] includeExpressions)
        //{
        //    IQueryable<Order> set = _context.Orders;

        //    foreach (var includeExpression in includeExpressions)
        //    {
        //        set = set.Include(includeExpression);
        //    }
        //    return set;
        //}

        public IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> predicate, params string[] navigationProperties)
        {
            IEnumerable<TEntity> list;
            using (var ctx = new TeamBuilderContext())
            {
                var query = ctx.Set<TEntity>().AsQueryable();

                foreach (string navigationProperty in navigationProperties)
                    query = query.Include(navigationProperty);//got to reaffect it.

                list = query.Where(predicate).ToList<TEntity>();
            }
            return list.AsQueryable();
        }

        //public IEnumerable<TEntity> Where(IEnumerable<TEntity> source, Func<TEntity, bool> predicate)
        //{
        //    return this.Context.Set<TEntity>().Where(predicate);
        //}
    }
}
