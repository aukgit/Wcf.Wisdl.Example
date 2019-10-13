using WcfWsdlExample.Base.Interface.DataLayer.Repository;
using WcfWsdlExample.DataLayer.DataModel;
using WcfWsdlExample.DataLayer.Implementation;
using WcfWsdlExample.DataLayer.NorthwindDataSet;

namespace WcfWsdlExample.DataLayer.Interface.Repository
{
    public interface INorthwindCustomRepository : IGenericRepository<NorthwindCustomerModel>
    {
        NorthwindDatasetReader NorthwindDatasetReader { get; }

        northwind GetDataset { get; }
    }
}