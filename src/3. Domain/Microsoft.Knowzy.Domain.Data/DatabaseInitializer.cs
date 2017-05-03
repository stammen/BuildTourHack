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
            var jsonCompletePath = env.WebRootPath + config["AppSettings:JsonPath"];

            var dataAsString = await ReadDataFromFile(jsonCompletePath);
            var data = JsonConvert.DeserializeObject<DataImport>(dataAsString, new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                NullValueHandling = NullValueHandling.Ignore
            });

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

        #endregion

        #region Private Methods

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
