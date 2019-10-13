using WcfWsdlExample.Base.Interface.Configuration;

namespace WcfWsdlExample.Base.Implementation.Configuration
{
    public class CoreJsonConfiguration : ICoreJsonConfiguration
    {
        public string OpenVpnDataTemplateRelativePath { get; set; }

        public bool IsDebugMode { get; set; }

        public string DefaultRunningProtocol { get; set; }

        /// <inheritdoc />
        public string ConfigurationRootFolderPath { get; set; }

        /// <inheritdoc />
        public string StaticMappingFolderPath { get; set; }

        /// <inheritdoc />
        public string StaticListFolderPath { get; set; }

        /// <inheritdoc />
        public string MappingConfigExtension { get; set; }

        /// <inheritdoc />
        public string ListConfigExtension { get; set; }

        #region Implementation of IDisposable

        /// <inheritdoc />
        public void Dispose()
        { }

        #endregion
    }
}