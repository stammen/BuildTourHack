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

using Microsoft.Knowzy.Common.Contracts;
using Microsoft.Knowzy.Domain;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace Microsoft.Knowzy.JsonDataProvider
{
    public class JsonDataProvider : IDataProvider
    {
        private readonly IConfiguration _configuration;

        public JsonDataProvider(IConfiguration configuration)
        {
            _configuration = configuration;
            JsonConvert.DefaultSettings = () => new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
                Formatting = Formatting.Indented,
                NullValueHandling = NullValueHandling.Ignore,
            };
        }

        public DevelopmentItem[] GetData()
        {
            var jsonFilePath = _configuration.Configuration.JsonFilePath;
            // TODO: Read json file 
            var strData = "";

            return string.IsNullOrWhiteSpace(strData)
            ? default(DevelopmentItem[])
            : JsonConvert.DeserializeObject<DevelopmentItem[]>(strData, new StringEnumConverter());
        }
    }
}
