//*********************************************************
//
// Copyright (c) Microsoft. All rights reserved.
// This code is licensed under the MIT License (MIT).
// THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
// ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
// IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
// PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.
//
//*********************************************************

using System;
using System.IO;
using Microsoft.Knowzy.Common.Contracts;
using Microsoft.Knowzy.Common.Helpers;
using Microsoft.Knowzy.Domain;

namespace Microsoft.Knowzy.DataProvider
{
    public class JsonDataProvider : IDataProvider
    {
        private readonly IConfigurationService _configuration;

        public JsonDataProvider(IConfigurationService configuration)
        {
            _configuration = configuration;
        }

        public Product[] GetData()
        {
            String jsonFilePath;

            if (ExecutionMode.IsRunningAsUwp())
            {
                jsonFilePath = Path.Combine(AppFolders.Current, "desktop", _configuration.Configuration.JsonFilePath);
            }
            else
            {
                jsonFilePath = _configuration.Configuration.JsonFilePath;
            }

            return JsonHelper.Deserialize<Product[]>(FileHelper.ReadTextFile(jsonFilePath));
        }
    }
}
