namespace TeamBuilder.Data.Contracts
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;

    public interface IRepository<TEntity> where TEntity : class
    {
        void Add(TEntity entity);

        void AddRange(IEnumerable<TEntity> entities);

        void Delete(TEntity entity);

        void DeleteRange(IEnumerable<TEntity> entities);

        TEntity GetById(int id);

        TEntity GetById(Expression<Func<TEntity, bool>> predicate);

        TEntity GetByName(Expression<Func<TEntity, bool>> predicate);

        IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);

        TEntity FirstOrDefault(Expression<Func<TEntity, bool>> predicate);

        IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> predicate, params string[] navigationProperties);

        IQueryable<TEntity> Include(string v);
        //IEnumerable<TEntity> Where(IEnumerable<TEntity> source, Func<TEntity, bool> predicate);
    }
}
