using Auk.CsharpBootstrapper.Helper;

namespace WcfWsdlExample.DataStructure.StaticType
{
    /// <summary>
    ///     Collection of Paths except for DataTemplate Paths, for datatemplates path please use
    ///     <see cref="StaticTemplatesPath" />
    /// </summary>
    public static class StaticPath
    {
        /// <summary>
        ///     PathHelper.GetPathCombineFromBase("Resources")
        ///     RunDir\Resources
        /// </summary>
        public static readonly string ResourceDirectory = PathHelper.GetPathCombineFromBase(StaticDirectoryName.Resources);

        /// <summary>
        ///     Example : "RunningDirectory\Resources\CacheData\personalVPN.db"
        /// </summary>
        public static readonly string DataCachePath = DirectoryHelper.CombinePaths(
            ResourceDirectory,
            "DataCache");

        /// <summary>
        ///     Example : "RunningDirectory\Resources\DataCache\northwind.xml"
        /// </summary>
        public static readonly string NorthwindXmlPath = DirectoryHelper.CombinePaths(
            DataCachePath,
            StaticFileName.NorthwindXmlFile);

        /// <summary>
        ///     Example : "RunningDirectory\Resources\ConfigurationFiles"
        /// </summary>
        public static readonly string ResourceConfigurationDirectory = DirectoryHelper.CombinePaths(
            ResourceDirectory,
            "ConfigurationFiles");

        /// <summary>
        ///     Example : "RunningDirectory\Resources\ConfigurationFiles\LogsConfiguration"
        /// </summary>
        public static readonly string Log4NetConfigDirectory = DirectoryHelper.CombinePaths(
            ResourceConfigurationDirectory,
            "LogsConfiguration");

        /// <summary>
        ///     <see cref="Log4NetConfigDirectory"/>\"WcfWsdlExample.Server.CommandLine.log4net.config"
        ///     Example : "RunningDirectory\Resources\ConfigurationFiles\LogsConfiguration\WcfWsdlExample.Server.CommandLine.log4net.config"
        /// </summary>
        public static readonly string WcfWsdlExampleServerCommandLineLog4netPath = DirectoryHelper.CombinePaths(
            Log4NetConfigDirectory,
            "WcfWsdlExample.Server.CommandLine.log4net.config");

        /// <summary>
        ///     <see cref="Log4NetConfigDirectory"/>\"WcfWsdlExample.Server.CommandLine.log4net.config"
        ///     Example : "RunningDirectory\Resources\ConfigurationFiles\LogsConfiguration\WcfWsdlExample.Server.CommandLine.log4net.config"
        /// </summary>
        public static readonly string WcfWsdlExampleClientCommandLineLog4netPath = DirectoryHelper.CombinePaths(
            Log4NetConfigDirectory,
            "WcfWsdlExample.Client.CommnadLine.log4net.config");
    }
}