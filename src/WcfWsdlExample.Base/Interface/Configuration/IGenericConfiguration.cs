using System;
using System.IO;

namespace WcfWsdlExample.Base.Interface.Configuration
{
    public interface IGenericConfiguration : IDisposable
    {
        ICoreJsonConfiguration CoreJsonConfiguration { get; }

        string JsonConfigPath { get; }

        FileInfo JsonConfigFileInfo { get; }
    }
}