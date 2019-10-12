using System;
using System.IO;
using System.Xml.Serialization;
using WcfWsdlExample.DataLayer.Interface;
using WcfWsdlExample.DataLayer.NorthwindDataSet;

namespace WcfWsdlExample.DataLayer.Implementation
{
    public class NorthwindDataSetReader : INorthwindDataSetReader
    {
        #region Implementation of INorthwindDataSetReader

        /// <inheritdoc />
        public northwind ReadDataSet() => throw new NotImplementedException();

        /// <inheritdoc />
        public northwind ReadDataSet(string filePath) => throw new NotImplementedException();

        #endregion
    }
}