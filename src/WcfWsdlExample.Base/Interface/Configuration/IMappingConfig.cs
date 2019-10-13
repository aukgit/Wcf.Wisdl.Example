using System;
using System.Collections.Generic;
using WcfWsdlExample.DataStructure.StaticType;

namespace WcfWsdlExample.Base.Interface.Configuration
{
    public interface IMappingConfig
    {
        IDictionary<string, string> this[MappingConfigName configName] { get; }

        IDictionary<string, string> this[string configName] { get; }

        dynamic this[MappingConfigName configName, string subConfigName] { get; }

        dynamic this[string configName, string subConfigName] { get; }

        string[] ListNames { get; }

        string[] MappingConfigListNames { get; }

        IDictionary<string, string> Get(MappingConfigName configName);

        IDictionary<string, string> Get(string configName);

        dynamic Get(string configName, string subConfigName);

        string[] GetConfigNames();

        string[] GetMappingConfigNames();

        bool IsExist(string configName, string subConfigName, string valueLookingFor, StringComparison stringComparison = StringComparison.Ordinal);
    }
}