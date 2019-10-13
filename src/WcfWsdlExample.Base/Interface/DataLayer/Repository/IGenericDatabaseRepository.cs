using System;
using System.Linq;

namespace WcfWsdlExample.Base.Interface.DataLayer.Repository
{
    public interface IGenericDatabaseRepository<TEntity, TKey>: IGenericRepository<TEntity> where TEntity : ISqlDataModel
    {
        IQueryable<TEntity> Get();

        IQueryable<TEntity> Get(Func<TEntity, bool> predicate);

        TEntity GetById(TKey id);

        void AddOrUpdate(TKey id, TEntity entity);

        void Add(TEntity entity);

        void Update(TEntity entity);

        void Delete(TEntity entity);

        void SaveChanges(TEntity entity);
    }
}