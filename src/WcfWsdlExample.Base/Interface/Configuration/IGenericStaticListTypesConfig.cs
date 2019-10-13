using System;
using System.Collections.Generic;
using Auk.CsharpBootstrapper.StaticTypes;
using WcfWsdlExample.DataStructure.StaticType;

namespace WcfWsdlExample.Base.Interface.Configuration
{
    public interface IGenericStaticListTypesConfig
    {
        string[] this[StaticListTypeName configNames] { get; }

        string[] this[string configName] { get; }

        string[] ListNames { get; }

        string[] Get(StaticListTypeName configNames);

        string[] Get(string configName);

        /// <summary>
        /// Clear list for given <see cref="StaticListTypeName"/>
        /// </summary>
        /// <param name="configName"></param>
        void ClearConfig(StaticListTypeName configName);

        /// <summary>
        ///     Set all the filter containing keys to <see cref="CommonIdentifier.EmptyStringArray" />
        /// </summary>
        void ClearFilterConfigs();

        /// <summary>
        /// Rewrite list 
        /// </summary>
        /// <param name="configNames"></param>
        /// <param name="list"></param>
        void ReWriteList(StaticListTypeName configNames, string[] list);

        /// <summary>
        /// Get the data as dictionary.
        /// </summary>
        /// <param name="config"></param>
        /// <returns></returns>
        IDictionary<string, string> GetAsDictionary(StaticListTypeName config);

        IDictionary<string, string> GetAsDictionary(string configName);

        string[] GetConfigNames();

        bool IsExist(
            string configName,
            string valueLookingFor,
            StringComparison stringComparison = StringComparison.Ordinal);
    }
}