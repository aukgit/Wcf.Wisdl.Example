using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WcfWsdlExample.DataLayer.DataModel;
using WcfWsdlExample.DataLayer.Implementation.Repository;
using WcfWsdlExample.Server.CommandLine.Interface;

namespace WcfWsdlExample.Server.CommandLine.Implementation
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "CustomerService" in both code and config file together.
    public class CustomerService : ICustomerService
    {
        #region Implementation of ICustomerService

        /// <inheritdoc />
        public NorthwindCustomerModel[] GetNorthwindCustomers()
        {
            var customerRepository = new NorthwindCustomRepository();

            var result = customerRepository.GetAll();

            return result;
        }

        #endregion
    }
}
