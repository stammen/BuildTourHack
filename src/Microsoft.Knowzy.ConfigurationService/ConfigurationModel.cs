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

namespace Microsoft.Knowzy.Configuration
{
    public class ConfigurationModel : IConfigurationModel
    {
        public string JsonFilePath { get; set; }
        public string DataSourceUrl { get; set; }
    }
}
