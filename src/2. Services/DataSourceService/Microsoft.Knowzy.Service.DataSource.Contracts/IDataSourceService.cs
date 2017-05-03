using System.Collections.Generic;
using Microsoft.Knowzy.Domain;

namespace Microsoft.Knowzy.Service.DataSource.Contracts
{
    public interface IDataSourceService
    {
        IEnumerable<Shipping> GetShippings();
        IEnumerable<Shipping> GetShippings(int pageNumber, int pageCount);
        IEnumerable<Receiving> GetReceivings();
        IEnumerable<Receiving> GetReceivings(int pageNumber, int pageCount);
        Shipping GetShipping(string orderNumber);
        Receiving GetReceiving(string orderNumber);
        int GetShippingCount();
        int GetReceivingCount();
    }
}
