using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Knowzy.Models.ViewModels;

namespace Microsoft.Knowzy.Service.DataSource.Contracts
{
    public interface IOrderQueries
    {
        Task<IEnumerable<ShippingsViewModel>> GetShippings();
        Task<IEnumerable<ShippingsViewModel>> GetShippings(int pageNumber, int pageCount);
        Task<IEnumerable<ReceivingsViewModel>> GetReceivings();
        Task<IEnumerable<ReceivingsViewModel>> GetReceivings(int pageNumber, int pageCount);
        Task<ShippingViewModel> GetShipping(string orderNumber);
        Task<ReceivingViewModel> GetReceiving(string orderNumber);
        Task<int> GetShippingCount();
        Task<int> GetReceivingCount();
    }
}
