using System;
using System.Collections.Generic;
using Auk.CsharpBootstrapper.Extensions;
using Auk.CsharpBootstrapper.Helper;
using Shouldly;
using WcfWsdlExample.DataLayer.DataModel;
using WcfWsdlExample.DataLayer.Interface.Repository;
using WcfWsdlExample.DataLayer.NorthwindDataSet;

namespace WcfWsdlExample.DataLayer.Implementation.Repository
{
    public class NorthwindCustomRepository : INorthwindCustomRepository
    {
        public NorthwindCustomRepository() => NorthwindDatasetReader = new NorthwindDatasetReader();

        #region Implementation of IGenericRepository<NorthwindCustomer>

        /// <inheritdoc />
        public NorthwindCustomerModel[] GetAll()
        {
            var northwindDataset = GetDataset;

            return new NorthwindCustomerModel[0];
        }

        /// <inheritdoc />
        public IList<NorthwindCustomerModel> GetToList() => throw new NotImplementedException();

        /// <inheritdoc />
        public LinkedList<NorthwindCustomerModel> GetToLinkedList() => throw new NotImplementedException();

        #endregion

        #region Implementation of INorthwindCustomRepository

        /// <inheritdoc />
        public NorthwindDatasetReader NorthwindDatasetReader { get; }

        /// <inheritdoc />
        public northwind GetDataset
        {
            get
            {
                NorthwindDatasetReader.ShouldNotBeNull(nameof(NorthwindDatasetReader));

                var northwindDataSetResult = NorthwindDatasetReader.GetCachedDataSet();

                if (northwindDataSetResult.IsPresentAndValid())
                {
                    var dataset = northwindDataSetResult.Result;

                    return dataset;
                }

                return null;
            }
        }

        #endregion

        #region Implementation of IDisposable

        /// <inheritdoc />
        public void Dispose()
        {
            NorthwindDatasetReader?.Dispose();
        }

        #endregion
    }
}