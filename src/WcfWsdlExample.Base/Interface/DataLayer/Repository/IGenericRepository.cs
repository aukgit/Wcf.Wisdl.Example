using System;
using System.Collections.Generic;

namespace WcfWsdlExample.Base.Interface.DataLayer.Repository
{
    /// <summary>
    /// Non persistent repository
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public interface IGenericRepository<TEntity> : IDisposable where TEntity : IDataModel
    {
        /// <summary>
        ///     Get all records of the type.
        /// </summary>
        /// <returns></returns>
        TEntity[] GetAll();

        /// <summary>
        ///     Get all the records as To List
        /// </summary>
        /// <returns></returns>
        IList<TEntity> GetToList();

        /// <summary>
        ///     Get all the records as To LinkedList
        /// </summary>
        /// <returns></returns>
        LinkedList<TEntity> GetToLinkedList();
    }
}