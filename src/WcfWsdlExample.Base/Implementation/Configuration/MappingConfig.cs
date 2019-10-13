using System;
using System.Collections.Generic;
using System.IO;
using Auk.CsharpBootstrapper.Extensions;
using Auk.CsharpBootstrapper.Helper;
using Auk.CsharpBootstrapper.StaticTypes;
using Newtonsoft.Json;
using WcfWsdlExample.Base.Interface.Configuration;
using WcfWsdlExample.DataStructure.Model;
using WcfWsdlExample.DataStructure.StaticType;

namespace WcfWsdlExample.Base.Implementation.Configuration
{
    public class MappingConfig : IMappingConfig
    {
        private const string DefaultMappingConfigFileNameWithoutExtension = "Mapping";
        private const string DefaultMappingConfigFileName = "Mapping.Config.json";
        private const string MappingConfigFileExtension = ".Config.json";
        private const string MappingConfigFileExtensionWithAstrek = "*Config.json";
        private readonly IDictionary<string, MappingConfigModel> _configDictionary;
        private readonly IDictionary<string, IDictionary<string, string>> _dictionary;
        private readonly IDictionary<string, IDictionary<string, dynamic>> _dictionaryOfDictionary;

        public MappingConfig(ICoreJsonConfiguration coreJsonConfiguration)
        {
            var givenLocationForMapping = coreJsonConfiguration.StaticMappingFolderPath;
            var extension               = coreJsonConfiguration.MappingConfigExtension;
            var splitter                = CommonIdentifier.NewLineSlashN;

            var locations         = Path.Combine(coreJsonConfiguration.ConfigurationRootFolderPath, givenLocationForMapping);
            var listOfFiles       = DirectoryHelper.GetFilesAbsolute(locations, extension);
            var listOfConfigFiles = DirectoryHelper.GetFilesAbsolute(locations, MappingConfigFileExtensionWithAstrek);
            ListNames              = new string[listOfFiles.Length];
            MappingConfigListNames = new string[listOfConfigFiles.Length];

            var dictionaryLength = ListNames.Length + 2;
            _dictionary             = new Dictionary<string, IDictionary<string, string>>(dictionaryLength);
            _configDictionary       = new Dictionary<string, MappingConfigModel>(dictionaryLength);
            _dictionaryOfDictionary = new Dictionary<string, IDictionary<string, dynamic>>(dictionaryLength);
            ReadAndPopulateJsonConfigData(listOfConfigFiles);
            ReadDictionaryData(listOfFiles, splitter);
        }

        public string[] ListNames { get; }

        public string[] MappingConfigListNames { get; }

        public IDictionary<string, string> this[string configName] => Get(configName);

        public dynamic this[string configName, string subConfigName] => Get(configName, subConfigName);

        public IDictionary<string, string> this[MappingConfigName configName] => Get(configName.ToString());

        public dynamic this[MappingConfigName configName, string subConfigName] => Get(configName.ToString(), subConfigName);

        public IDictionary<string, string> Get(string configName)
        {
            if (_dictionary.ContainsKey(configName))
            {
                return _dictionary[configName];
            }

            throw new NullReferenceException($"{nameof(configName)}: {configName} doesn't exist in the dictionary.");
        }

        public dynamic Get(string configName, string subConfigName)
        {
            var dictionary = Get(configName);

            if (dictionary != null)
            {
                if (dictionary.ContainsKey(subConfigName))
                {
                    return dictionary[subConfigName];
                }
            }

            throw new NullReferenceException($"{nameof(configName)}: {configName} doesn't exist in the dictionary.");
        }

        /// <summary>
        ///     Get the data using enum StaticListTypeName.
        /// </summary>
        /// <param name="configName"></param>
        /// <returns></returns>
        public IDictionary<string, string> Get(MappingConfigName configName) => Get(configName.ToString());

        public string[] GetConfigNames() => ListNames;

        public string[] GetMappingConfigNames() => MappingConfigListNames;

        public bool IsExist(
            string configName,
            string subConfigName,
            string valueLookingFor,
            StringComparison stringComparison = StringComparison.Ordinal)
        {
            var result = this[configName, subConfigName];

            if (result == null)
            {
                throw new NullReferenceException($"Config ({configName}: {configName}) is not found in the list.");
            }

            return string.Equals(result, valueLookingFor, stringComparison);
        }

        private void ReadDictionaryData(IEnumerable<string> listOfFiles, string splitter)
        {
            var i             = 0;
            var defaultConfig = _configDictionary[DefaultMappingConfigFileNameWithoutExtension];

            foreach (var fileLocation in listOfFiles)
            {
                var      file     = new FileInfo(fileLocation);
                var      fileName = file.Name.Replace(file.Extension, string.Empty);
                string[] data;
                var      specificConfigModel = defaultConfig;

                if (_configDictionary.ContainsKey(fileName))
                {
                    specificConfigModel = _configDictionary[fileName];
                }

                if (splitter == CommonIdentifier.NewLineSlashN)
                {
                    data = File.ReadAllLines(fileLocation);
                }
                else
                {
                    var rawData = File.ReadAllText(fileLocation);
                    data = rawData.SplitByString(splitter);
                }

                ListNames[i] = fileName;

                var dataDictionary = new Dictionary<string, string>(data.Length + 2);

                foreach (var line in data)
                {
                    try
                    {
                        var    lineSplit = line.SplitByString(specificConfigModel.ValueKeySplitter);
                        string key       = null;
                        string value     = null;

                        if (specificConfigModel.IsValueKeptInRight)
                        {
                            key   = lineSplit[0];
                            value = lineSplit[1];
                        }
                        else
                        {
                            key   = lineSplit[1];
                            value = lineSplit[0];
                        }

                        dataDictionary[key] = value;
                    }
                    catch (Exception e)
                    {
                        LogHelper.Error(GetType(), e, $"Mapping File Name: {fileName}, Line : {line}, Splitter : {specificConfigModel.ValueKeySplitter}");
                    }
                }

                _dictionary[fileName] = dataDictionary;

                i++;
            }
        }

        private static MappingConfigModel GetConfigModel(string json) => JsonConvert.DeserializeObject<MappingConfigModel>(json);

        private void ReadAndPopulateJsonConfigData(IEnumerable<string> listOfConfigFiles)
        {
            var i = 0;

            foreach (var fileLocation in listOfConfigFiles)
            {
                var file               = new FileInfo(fileLocation);
                var jsonConfigString   = File.ReadAllText(fileLocation);
                var mappingConfigModel = GetConfigModel(jsonConfigString);
                var fileName           = file.Name.Replace(MappingConfigFileExtension, string.Empty);

                MappingConfigListNames[i]   = fileName;
                _configDictionary[fileName] = mappingConfigModel;

                i++;
            }
        }
    }
}