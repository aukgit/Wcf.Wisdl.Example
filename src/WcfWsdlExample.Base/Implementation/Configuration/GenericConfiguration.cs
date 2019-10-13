using System;
using System.IO;
using Auk.CsharpBootstrapper.Extensions;
using Auk.CsharpBootstrapper.Helper;
using Auk.CsharpBootstrapper.Interfaces;
using Newtonsoft.Json;
using WcfWsdlExample.Base.Interface.Configuration;

namespace WcfWsdlExample.Base.Implementation.Configuration
{
    public class GenericConfiguration : IGenericConfiguration
    {
        private readonly ILazyGetter<ICoreJsonConfiguration> _coreConfigurationGetter;

        public GenericConfiguration(string jsonConfigPath)
        {
            JsonConfigPath = jsonConfigPath;

            try
            {
                JsonConfigFileInfo = FileHelper.CreateSafeFileInfo(JsonConfigPath);
            }
            catch (Exception e)
            {
                LogHelper.PathErrorLog(GetType(), e, JsonConfigPath);
            }

            _coreConfigurationGetter = ActionHelper.LazyGetter(GetCoreJsonFileConfiguration);
        }

        private ICoreJsonConfiguration GetCoreJsonFileConfiguration()
        {
            try
            {
                if (JsonConfigFileInfo?.Exists == true)
                {
                    var jsonData = File.ReadAllText(JsonConfigPath);

                    var result = JsonConvert.DeserializeObject<CoreJsonConfiguration>(jsonData);

                    if (result.IsPresent())
                    {
                        result.ConfigurationRootFolderPath = JsonConfigPath;

                        var properties = result.GetType().GetAllProperties();

                        foreach (var propertyInfo in properties)
                        {
                            try
                            {
                                var isPropertyNeedsExpand = propertyInfo.PropertyType == typeof(string) &&
                                                            propertyInfo.Name.EndsWith("Path", StringComparison.OrdinalIgnoreCase);
                                if (!isPropertyNeedsExpand)
                                {
                                    continue;
                                }

                                var value = propertyInfo.GetPropertyValue(result, string.Empty);
                                var path  = DirectoryHelper.ExpandPaths(value, result);
                                propertyInfo.SetValue(result, path);
                            }
                            catch (Exception e)
                            {
                                LogHelper.Error(e, $"Property : {propertyInfo.Name}, Type : {propertyInfo.PropertyType.FullName} failed to extract. CoreConfig : {result.GetType().GetToString(result)}", result.GetType().FullName);
                            }
                        }

                        return result;
                    }
                }
                else
                {
                    LogHelper.Warning(GetType(), "FilePath not found for JsonConfig:", JsonConfigPath);
                }
            }
            catch (Exception e)

            {
                LogHelper.PathErrorLog(GetType(), e, JsonConfigPath);
            }

            return null;
        }

        #region Implementation of IGenericConfiguration

        /// <inheritdoc />
        public ICoreJsonConfiguration CoreJsonConfiguration => _coreConfigurationGetter.ValueAtOnce;

        /// <inheritdoc />
        public string JsonConfigPath { get; }

        /// <inheritdoc />
        public FileInfo JsonConfigFileInfo { get; }

        #endregion

        #region IDisposable

        /// <inheritdoc />
        public void Dispose()
        {
            if (_coreConfigurationGetter?.IsOneTimeValuePresent == true)
            {
                CoreJsonConfiguration?.Dispose();
                _coreConfigurationGetter?.Dispose();
            }
        }

        #endregion
    }
}