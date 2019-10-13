using Auk.CsharpBootstrapper.Extensions;
using WcfWsdlExample.Base.Interface.DataLayer;
using WcfWsdlExample.DataLayer.NorthwindDataSet;

namespace WcfWsdlExample.DataLayer.DataModel
{
    public class NorthwindCustomerModel : ISqlDataModel
    {
        public NorthwindCustomerModel(northwind.CustomerRow customerRow)
        {
            this.SafeInjectPropertiesValuesWithSameNames(customerRow, isLogWarningIfPropertyMismatchOrNotFound: true);
        }

        public string CompanyName { get; set; }

        public string ContactName { get; set; }

        public string ContactTitle { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public string Region { get; set; }

        public string PostalCode { get; set; }

        public string Country { get; set; }

        public string Phone { get; set; }

        public string Fax { get; set; }

        public string CustomerID { get; set; }
    }
}