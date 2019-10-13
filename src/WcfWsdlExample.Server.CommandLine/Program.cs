using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Auk.CsharpBootstrapper.Helper;
using log4net;
using WcfWsdlExample.DataLayer.Implementation.Repository;
using WcfWsdlExample.DataStructure.StaticType;

namespace WcfWsdlExample.Server.CommandLine
{
    class Program
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(Program));
        private static readonly string Log4NetConfigPath = StaticPath.WcfWsdlExampleServerCommandLineLog4netPath;

        static void Main(string[] args)
        {
            LogHelper.EnableDebugMode();
            LogHelper.InjectLog4NetLogger(Log);
            LogHelper.GetConfiguredLog4Net(Log4NetConfigPath);

            var customerRepository = new NorthwindCustomRepository();

            var result = customerRepository.GetAll();

        }
    }
}
