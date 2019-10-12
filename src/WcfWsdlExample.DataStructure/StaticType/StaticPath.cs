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
    }
}