using System;
using System.IO;
using System.Xml.Serialization;
using Auk.CsharpBootstrapper.Helper;
using Auk.CsharpBootstrapper.Interfaces.ResultWrapper;
using WcfWsdlExample.Base.Helper;
using WcfWsdlExample.DataLayer.Interface;
using WcfWsdlExample.DataLayer.NorthwindDataSet;
using WcfWsdlExample.DataStructure.StaticType;

namespace WcfWsdlExample.DataLayer.Implementation
{
    public class NorthwindDatasetReader : INorthwindDataSetReader
    {
        private readonly string _path = StaticPath.NorthwindXmlPath;

        #region Implementation of INorthwindDataSetReader

        /// <inheritdoc />
        public ICommonValidateResult<northwind> ReadDataSet() =>
            ReadDataSet(_path);

        /// <inheritdoc />
        public ICommonValidateResult<northwind> GetCachedDataSet()
        {
            var cached = SingletonHelper.Create(ReadDataSet);

            return cached;
        }

        /// <inheritdoc />
        public ICommonValidateResult<northwind> ReadDataSet(string filePath) =>
            XmlHelper.ReadXmlAsSerialized<northwind>(filePath);

        #endregion

        #region IDisposable

        /// <inheritdoc />
        public void Dispose()
        { }

        #endregion
    }
}