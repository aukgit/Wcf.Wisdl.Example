using Auk.CsharpBootstrapper.Interfaces.Model;

namespace WcfWsdlExample.Base.Interface.Configuration
{
    public interface ICoreJsonConfiguration: IGenericModel
    {
        string OpenVpnDataTemplateRelativePath { get; set; }

        bool IsDebugMode { get; set; }

        string DefaultRunningProtocol { get; set; }

        /// <summary>
        ///     Dynamically populated the current config path.
        /// </summary>
        string ConfigurationRootFolderPath { get; set; }

        string StaticMappingFolderPath { get; set; }

        string StaticListFolderPath { get; set; }

        string MappingConfigExtension { get; set; }

        string ListConfigExtension { get; set; }
    }
}