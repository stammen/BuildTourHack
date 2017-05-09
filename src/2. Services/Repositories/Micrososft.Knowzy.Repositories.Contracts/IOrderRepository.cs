using System.Threading.Tasks;
using Extensions;
using Microsoft.Knowzy.Domain;

namespace Micrososft.Knowzy.Repositories.Contracts
{
    public interface IOrderRepository
    {
        Task AddShipping(Shipping shipping);
        Task UpdateShipping(Shipping shipping);
        Task AddReceiving(Receiving receiving);
        Task UpdateReceiving(Receiving receiving);
        IUnitOfWork UnitOfWork { get; }
    }
}
