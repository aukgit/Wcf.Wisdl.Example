using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Auk.CsharpBootstrapper.Extensions;
using Auk.CsharpBootstrapper.Helper;
using Auk.CsharpBootstrapper.Implementations.ResultWrapper;
using Auk.CsharpBootstrapper.Interfaces.ResultWrapper;

namespace WcfWsdlExample.Base.Helper
{
    public static class XmlHelper
    {
        /// <summary>
        /// Read and serialize the data to the given {T}
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static ICommonValidateResult<T> ReadXmlAsSerialized<T>(string filePath)
        {
            var type = typeof(T);
            var xmlSerializer = new XmlSerializer(typeof(T));
            string errorLogs = null;

            try
            {
                using (var fileStreamer = new FileStream(filePath, FileMode.Open))
                {
                    var rawData = xmlSerializer.Deserialize(fileStreamer);

                    if (rawData is T result)
                    {
                        return new CommonValidateResult<T>(result != null, result);
                    }
                }
            }
            catch (Exception e)
            {
                errorLogs = e.PathErrorLogAndThrow(filePath, type.FullName);
            }

            return new CommonValidateResult<T>(false, default(T), errorLogs);
        }

        /// <summary>
        /// Read and serialize the data to the given {T}
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static ICommonValidateResult<T> MutexReadXmlAsSerialized<T>(string filePath)
        {
            var    type          = typeof(T);
            var    xmlSerializer = new XmlSerializer(typeof(T));
            string errorLogs     = null;

            try
            {
                using (var fileStreamer = new FileStream(filePath, FileMode.Open))
                {
                    var rawData =  MutexHelper.GetResultWithMutex(() => xmlSerializer.Deserialize(fileStreamer));

                    if (rawData is T result)
                    {
                        return new CommonValidateResult<T>(result != null, result);
                    }
                }
            }
            catch (Exception e)
            {
                errorLogs = e.PathErrorLogAndThrow(filePath, type.FullName);
            }

            return new CommonValidateResult<T>(false, default(T), errorLogs);
        }
    }
}
