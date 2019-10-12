using System;
using System.Collections.Generic;
using System.Linq;

namespace WcfWsdlExample.DataLayer.Interface.Repository
{
    public interface IGenericRepository<TEntity, TKey> where TEntity : ISqlDataModel
    {
        IList<TEntity> GetAll();

        IQueryable<TEntity> Get();

        IQueryable<TEntity> Get(Func<TEntity, bool> predicate);

        TEntity GetById(TKey id);

        void AddOrUpdate(TEntity entity);

        void Add(TEntity entity);

        void Update(TEntity entity);

        void Delete(TEntity entity);

        void SaveChanges();
    }
}
