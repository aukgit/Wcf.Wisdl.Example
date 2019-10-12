using WcfWsdlExample.DataLayer.NorthwindDataSet;

namespace WcfWsdlExample.DataLayer.Interface
{
    public interface INorthwindDataSetReader
    {
        /// <summary>
        /// read northwind dataset.
        /// </summary>
        /// <returns></returns>
        northwind ReadDataSet();

        /// <summary>
        /// read northwind dataset.
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        northwind ReadDataSet(string filePath);
    }
}