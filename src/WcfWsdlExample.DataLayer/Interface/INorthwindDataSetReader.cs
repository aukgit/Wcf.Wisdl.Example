using System;
using Auk.CsharpBootstrapper.Interfaces.ResultWrapper;
using WcfWsdlExample.DataLayer.NorthwindDataSet;

namespace WcfWsdlExample.DataLayer.Interface
{
    public interface INorthwindDataSetReader : IDisposable
    {
        /// <summary>
        ///     read northwind dataset.
        /// </summary>
        /// <returns></returns>
        ICommonValidateResult<northwind> ReadDataSet();

        /// <summary>
        ///     read northwind dataset.
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        ICommonValidateResult<northwind> ReadDataSet(string filePath);

        /// <summary>
        ///     In memory data returned. Don't read from xml file.
        /// </summary>
        /// <returns></returns>
        ICommonValidateResult<northwind> GetCachedDataSet();
    }
}