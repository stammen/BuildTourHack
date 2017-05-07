using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Knowzy.Service.DataSource.Contracts;
using Newtonsoft.Json;
using System.IO;
using Newtonsoft.Json.Serialization;
using Microsoft.AspNetCore.Hosting;
using System.Linq;
using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Knowzy.Domain;
using Microsoft.Knowzy.Models;
using Microsoft.Knowzy.Models.ViewModels;

namespace Microsoft.Knowzy.Service.DataSource.Core
{
    public class OrderQueriesInMemory : IOrderQueries
    {
        #region Fields

        private IEnumerable<Shipping> _shippings = new List<Shipping>();
        private IEnumerable<Receiving> _receivings = new List<Receiving>();
        private readonly string _jsonCompletePath;
        private readonly IMapper _mapper;

        #endregion

        #region Constructor

        public OrderQueriesInMemory(IHostingEnvironment env, IConfiguration config, IMapper mapper)
        {
            _jsonCompletePath = env.WebRootPath + config["AppSettings:JsonPath"];
            _mapper = mapper;
            ImportData().Wait();
        }

        #endregion

        #region Public Methods

        public async Task<IEnumerable<ShippingsViewModel>> GetShippings()
        {
            return await  Task.Run(() => _shippings.Select(_mapper.Map<Shipping, ShippingsViewModel>));
        }

        public async Task<IEnumerable<ShippingsViewModel>> GetShippings(int pageNumber, int pageCount)
        {
            return await Task.Run(() => _shippings.Select(_mapper.Map<Shipping, ShippingsViewModel>)
                                        .Skip(pageCount * pageNumber)
                                        .Take(pageCount));
        }

        public async Task<IEnumerable<ReceivingsViewModel>> GetReceivings()
        {
            return await Task.Run(() => _receivings.Select(_mapper.Map<Receiving, ReceivingsViewModel>));
        }

        public async Task<IEnumerable<ReceivingsViewModel>> GetReceivings(int pageNumber, int pageCount)
        {
            return await Task.Run(() => _receivings.Select(_mapper.Map<Receiving, ReceivingsViewModel>)
                                        .Skip(pageCount * pageNumber)
                                        .Take(pageCount));
        }

        public async Task<ShippingViewModel> GetShipping(string orderNumber)
        {
            return await Task.Run(() => _shippings.Select(_mapper.Map<Shipping, ShippingViewModel>)
                                        .FirstOrDefault(shipping => shipping.OrderNumber == orderNumber));
        }

        public async Task<ReceivingViewModel> GetReceiving(string orderNumber)
        {
            return await  Task.Run(() => _receivings.Select(_mapper.Map<Receiving, ReceivingViewModel>)
                                        .FirstOrDefault(receiving => receiving.OrderNumber == orderNumber));
        }

        public async Task<IEnumerable<Item>> GetItems()
        {
            return await Task.Run(() => _shippings
                .SelectMany(shipping => shipping.OrderLines.Select(orderLine => orderLine.Item))
                .GroupBy(item => item.Number)
                .First()
                .ToList());
        }

        public async Task<IEnumerable<PostalCarrier>> GetPostalCarriers()
        {
            return await Task.Run(() => _shippings.Select(shipping => shipping.PostalCarrier)
                .GroupBy(postalCarrier => postalCarrier.Id)
                .First()
                .ToList());
        }

        public async Task<int> GetShippingCount()
        {
            return await Task.Run(() => _shippings.Count());
        }

        public async Task<int> GetReceivingCount()
        {
            return await Task.Run(() => _receivings.Count());
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
