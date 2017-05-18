using Microsoft.Knowzy.Common.Contracts;
using Microsoft.Knowzy.Common.Helpers;
using System;

namespace Microsoft.Knowzy.Configuration
{
    public class ConfigurationService : IConfigurationService
    {
        const string ConfigurationFilePath = "Config.json";

        public ConfigurationService()
        {
            Configuration = JsonHelper.Deserialize<ConfigurationModel>(FileHelper.ReadTextFile(AppDomain.CurrentDomain.BaseDirectory + ConfigurationFilePath));
        }

        public IConfigurationModel Configuration
        {
            get;
        } 
    }
}
