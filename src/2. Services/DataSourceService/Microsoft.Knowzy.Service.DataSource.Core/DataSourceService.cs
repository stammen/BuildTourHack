using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Knowzy.Service.DataSource.Contracts;
using Newtonsoft.Json;
using System.IO;
using Newtonsoft.Json.Serialization;
using Microsoft.AspNetCore.Hosting;
using System.Linq;
using Microsoft.Extensions.Configuration;
using Microsoft.Knowzy.Domain;
using Microsoft.Knowzy.Models;

namespace Microsoft.Knowzy.Service.DataSource.Core
{
    public class DataSourceService : IDataSourceService
    {
        #region Fields

        private IEnumerable<Shipping> _shippings = new List<Shipping>();
        private IEnumerable<Receiving> _receivings = new List<Receiving>();
        private readonly string _jsonCompletePath;

        #endregion

        #region Constructor

        public DataSourceService(IHostingEnvironment env, IConfiguration config)
        {
            _jsonCompletePath = env.WebRootPath + config["AppSettings:JsonPath"];
            ImportData().Wait();
        }

        #endregion

        #region Public Methods

        public Receiving GetReceiving(string orderNumber)
        {
            return _receivings.FirstOrDefault(receiving => receiving.OrderNumber == orderNumber);
        }

        public IEnumerable<Receiving> GetReceivings()
        {
            return _receivings;
        }

        public IEnumerable<Receiving> GetReceivings(int pageNumber, int pageCount)
        {
            return _receivings.Skip(pageCount * pageNumber).Take(pageCount);
        }

        public int GetReceivingCount()
        {
            return _receivings.Count();
        }

        public Shipping GetShipping(string orderNumber)
        {
            return _shippings.FirstOrDefault(shipping => shipping.OrderNumber == orderNumber);
        }

        public IEnumerable<Shipping> GetShippings(int pageNumber, int pageCount)
        {
            return _shippings.Skip(pageCount * pageNumber).Take(pageCount);
        }

        public IEnumerable<Shipping> GetShippings()
        {
            return _shippings;
        }

        public int GetShippingCount()
        {
            return _shippings.Count();
        }

        #endregion

        #region Private Methods

        private async Task ImportData()
        {
            var dataAsString = await ReadDataFromFile(_jsonCompletePath);
            var data = JsonConvert.DeserializeObject<DataImport>(dataAsString, new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                NullValueHandling = NullValueHandling.Ignore
            });

            _receivings = data.Receivings;
            _shippings = data.Shippings;
        }

        private async Task<string> ReadDataFromFile(string path)
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
