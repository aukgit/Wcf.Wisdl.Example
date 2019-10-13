using System.ServiceModel;
using WcfWsdlExample.DataLayer.DataModel;

namespace WcfWsdlExample.Server.CommandLine.Interface
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ICustomerService" in both code and config file together.
    [ServiceContract]
    public interface ICustomerService
    {
        [OperationContract]
        NorthwindCustomerModel[] GetNorthwindCustomers();
    }
}
