using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Auk.CsharpBootstrapper.Extensions;
using Auk.CsharpBootstrapper.Helper;
using Auk.CsharpBootstrapper.StaticTypes;
using WcfWsdlExample.Base.Interface.Configuration;
using WcfWsdlExample.DataStructure.StaticType;

namespace WcfWsdlExample.Base.Implementation.Configuration
{
    public class GenericStaticListTypesConfig : IGenericStaticListTypesConfig
    {
        private const string FilterKeyword = "Filter";
        private readonly IDictionary<string, string[]> _dictionary;
        private readonly IDictionary<string, IDictionary<string, string>> _dictionaryOfDictionary;

        public GenericStaticListTypesConfig(ICoreJsonConfiguration coreJsonConfiguration)
        {
            var givenLocationForStatic = coreJsonConfiguration.StaticListFolderPath;
            var extension              = coreJsonConfiguration.ListConfigExtension;
            var splitter               = CommonIdentifier.NewLineSlashNChar;

            var location    = Path.Combine(coreJsonConfiguration.ConfigurationRootFolderPath, givenLocationForStatic);
            var listOfFiles = DirectoryHelper.GetFilesAbsolute(location, extension);

            //consoleLogger.Info(GetType(), $"Static Config files Found : {listOfFiles.ToStringWithParametersJoiner()}");
            ListNames               = new string[listOfFiles.Length];
            _dictionary             = new Dictionary<string, string[]>(ListNames.Length + 2);
            _dictionaryOfDictionary = new Dictionary<string, IDictionary<string, string>>(ListNames.Length + 2);
            ReadDictionaryData(listOfFiles, splitter);
        }

        public string[] ListNames { get; }

        public string[] this[string configName] => Get(configName);

        public string[] this[StaticListTypeName configNames] => Get(configNames);

        public string[] Get(string configName)
        {
            if (_dictionary.ContainsKey(configName))
            {
                return _dictionary[configName];
            }

            throw new ArgumentException($"Config Name : {configName} not found in the static dictionary.");
        }

        /// <inheritdoc />
        public void ClearConfig(StaticListTypeName configNames)
        {
            ReWriteList(configNames, CommonIdentifier.EmptyStringArray);
        }

        /// <inheritdoc />
        public void ClearFilterConfigs()
        {
            var keys        = _dictionary.Keys;
            var removerKeys = new List<string>(10);

            foreach (var key in keys)
            {
                if (key.IndexOf(FilterKeyword, StringComparison.OrdinalIgnoreCase) > -1)
                {
                    removerKeys.Add(key);
                }
            }

            foreach (var removerKey in removerKeys)
            {
                _dictionary[removerKey] = CommonIdentifier.EmptyStringArray;
                _dictionaryOfDictionary.SafeDelete(removerKey);
            }
        }

        /// <inheritdoc />
        public void ReWriteList(StaticListTypeName configNames, string[] list)
        {
            var key = configNames.ToString();
            _dictionary[key] = list;
            _dictionaryOfDictionary.SafeDelete(key);
        }

        /// <summary>
        ///     Split single line by equal (=) left side used as key and right side used as value.
        /// </summary>
        /// <param name="configName"></param>
        /// <returns></returns>
        public IDictionary<string, string> GetAsDictionary(string configName)
        {
            if (_dictionaryOfDictionary.ContainsKey(configName))
            {
                return _dictionaryOfDictionary[configName];
            }

            var configData = Get(configName);

            if (configData == null)
            {
                throw new ArgumentException($"Config Name : {configName} not found in the static dictionary.");
            }

            var dictionary = new Dictionary<string, string>(configData.Length + 2);

            foreach (var singleLine in configData)
            {
                var splits = singleLine.Split(CommonIdentifier.EqualChar);
                var key    = splits[0];
                var value  = splits[1];
                dictionary[key] = value;
            }

            _dictionaryOfDictionary[configName] = dictionary;

            return dictionary;
        }

        /// <summary>
        ///     Split single line by equal (=) left side used as key and right side used as value.
        /// </summary>
        /// <param name="config"></param>
        /// <returns></returns>
        public IDictionary<string, string> GetAsDictionary(StaticListTypeName config)
        {
            var configName = config.ToString();

            return GetAsDictionary(configName);
        }

        /// <summary>
        ///     Get the data using enum StaticListTypeNames.
        /// </summary>
        /// <param name="configNames"></param>
        /// <returns></returns>
        public string[] Get(StaticListTypeName configNames) => Get(configNames.ToString());

        public string[] GetConfigNames() => ListNames;

        public bool IsExist(
            string configName,
            string valueLookingFor,
            StringComparison stringComparison = StringComparison.Ordinal)
        {
            var list = this[configName];

            if (list == null)
            {
                throw new NullReferenceException($"Config ({configName}) is not found in the list.");
            }

            return list.Any(predicate: n => n.Equals(valueLookingFor, stringComparison));
        }

        private void ReadDictionaryData(IList<string> listOfFiles, char splitter)
        {
            var i = 0;

            foreach (var fileLocation in listOfFiles)
            {
                var      file = new FileInfo(fileLocation);
                string[] data;

                if (splitter == CommonIdentifier.NewLineSlashNChar)
                {
                    var rawData = MutexHelper.ReadAllLines(fileLocation);
                    data = rawData.Result;
                }
                else
                {
                    var rawData = MutexHelper.ReadAllText(fileLocation);
                    data = rawData.Result.Split(splitter);
                }

                var fileName = file.Name.Replace(file.Extension, string.Empty);

                ListNames[i]          = fileName;
                _dictionary[fileName] = data;

                i++;
            }
        }
    }
}