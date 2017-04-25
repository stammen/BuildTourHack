using Microsoft.Knowzy.Domain.Models;
using System.Collections.Generic;

namespace Microsoft.Knowzy.Service.DataSource.Contracts
{
    public interface IDataSourceService
    {
        IEnumerable<Shipping> GetShippings();
        IEnumerable<Shipping> GetShippings(int pageNumber, int pageCount);
        IEnumerable<Receiving> GetReceivings();
        IEnumerable<Receiving> GetReceivings(int pageNumber, int pageCount);
        Shipping GetShipping(string orderNumber);
        Receiving GetReceiving(string receiptNumber);
        int GetShippingCount();
        int GetReceivingCount();
    }
}
