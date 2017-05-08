using System;
using Microsoft.Knowzy.Common.Contracts;
using Microsoft.Knowzy.Common.Models;

namespace Microsoft.Knowzy.Configuration
{
    public class Configuration : IConfiguration
    {
        ConfigurationModel IConfiguration.Configuration => throw new NotImplementedException();
    }
}
