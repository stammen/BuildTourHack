// ******************************************************************

// Copyright (c) Microsoft. All rights reserved.
// This code is licensed under the MIT License (MIT).
// THE CODE IS PROVIDED “AS IS”, WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED,
// INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT.
// IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM,
// DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT,
// TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH
// THE CODE OR THE USE OR OTHER DEALINGS IN THE CODE.

// ******************************************************************

using System;
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
            var jsonFilePath = _configuration.Configuration.JsonFilePath;

            return JsonHelper.Deserialize<Product[]>(FileHelper.ReadTextFile(jsonFilePath));
        }

        public void SetData(Product[] products)
        {
            var jsonFilePath = _configuration.Configuration.JsonFilePath;

            FileHelper.WriteTextFile(jsonFilePath, JsonHelper.Serialize(products));
        }
    }
}
