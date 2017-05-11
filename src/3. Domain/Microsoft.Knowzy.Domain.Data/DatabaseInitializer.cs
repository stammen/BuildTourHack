using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Knowzy.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Microsoft.Knowzy.Domain.Data
{
    public static class DatabaseInitializer
    {
        #region Public Methods

        public static async Task Seed(IHostingEnvironment env, IConfiguration config, KnowzyContext context)
        {
            var customerJsonPath = $"{env.WebRootPath}{config["AppSettings:CustomerJsonPath"]}";
            var productJsonPath = $"{env.WebRootPath}{config["AppSettings:ProductJsonPath"]}";
            var orderJsonPath = $"{env.WebRootPath}{config["AppSettings:OrderJsonPath"]}";

            await SeedCustomers(customerJsonPath, context);
            await SeedProducts(productJsonPath, context);
            await SeedOrders(orderJsonPath, context);            
        }

        private static async Task SeedOrders(string jsonPath, KnowzyContext context)
        {
            var data = await GetData<OrderImport>(jsonPath);

            if (data?.Receivings != null)
            {
                context.Receivings.AddRange(data.Receivings);
            }

            if (data?.Shippings != null)
            {
                context.Shippings.AddRange(data.Shippings);
            }

            await context.SaveChangesAsync();
        }

        private static async Task SeedProducts(string jsonPath, KnowzyContext context)
        {
            var data = await GetData<IEnumerable<Product>>(jsonPath);

            if (data != null)
            {
                context.Products.AddRange(data);
            }

            await context.SaveChangesAsync();
        }

        private static async Task SeedCustomers(string customerJsonPath, KnowzyContext context)
        {
            var data = await GetData<IEnumerable<Customer>>(customerJsonPath);

            if (data != null)
            {
                context.Customers.AddRange(data);
            }

            await context.SaveChangesAsync();
        }

        #endregion

        #region Private Methods

        private static async Task<T> GetData<T>(string jsonPath)
        {
            var dataAsString = await ReadDataFromFile(jsonPath);
            return JsonConvert.DeserializeObject<T>(dataAsString, new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                NullValueHandling = NullValueHandling.Ignore
            });
        }

        private static async Task<string> ReadDataFromFile(string path)
        {
            string result;

            using (var reader = File.OpenText(path))
            {
                result = await reader.ReadToEndAsync();
            }

            return result;
        }

        #endregion 
    }
}
