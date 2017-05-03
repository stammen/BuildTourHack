using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Knowzy.Domain.Data;
using Microsoft.Knowzy.Models.ViewModels;
using Microsoft.Knowzy.Service.DataSource.Contracts;

namespace Microsoft.Knowzy.Service.DataSource.Core
{
    public class OrderQueriesDatabase : IOrderQueries
    {
        #region Fields

        private readonly KnowzyContext _context;

        #endregion

        #region Constructor

        public OrderQueriesDatabase(KnowzyContext context)
        {
            _context = context;
        }

        #endregion

        #region Public Methods

        public async Task<IEnumerable<ShippingsViewModel>> GetShippings()
        {
            return await _context.Shippings.ProjectTo<ShippingsViewModel>().ToListAsync();
        }

        public async Task<IEnumerable<ShippingsViewModel>> GetShippings(int pageNumber, int pageCount)
        {
            return await _context.Shippings.ProjectTo<ShippingsViewModel>()
                        .Skip(pageCount * pageNumber)
                        .Take(pageCount)
                        .ToListAsync();
        }

        public async Task<IEnumerable<ReceivingsViewModel>> GetReceivings()
        {
            return await _context.Receivings.ProjectTo<ReceivingsViewModel>().ToListAsync();
        }

        public async Task<IEnumerable<ReceivingsViewModel>> GetReceivings(int pageNumber, int pageCount)
        {
            return await _context.Receivings.ProjectTo<ReceivingsViewModel>()
                        .Skip(pageCount * pageNumber)
                        .Take(pageCount)
                        .ToListAsync();
        }

        public async Task<ShippingViewModel> GetShipping(string orderNumber)
        {
            return await _context.Shippings.ProjectTo<ShippingViewModel>()
                        .FirstOrDefaultAsync(shipping => shipping.OrderNumber == orderNumber);
        }

        public async Task<ReceivingViewModel> GetReceiving(string orderNumber)
        {
            return await _context.Receivings.ProjectTo<ReceivingViewModel>()
                        .FirstOrDefaultAsync(receiving => receiving.OrderNumber == orderNumber);
        }

        public async Task<int> GetShippingCount()
        {
            return await _context.Shippings.CountAsync();
        }

        public async Task<int> GetReceivingCount()
        {
            return await _context.Receivings.CountAsync();
        }

        #endregion
    }
}
