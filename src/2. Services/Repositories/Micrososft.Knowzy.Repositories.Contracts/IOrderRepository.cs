using System.Threading.Tasks;
using Extensions;
using Microsoft.Knowzy.Domain;

namespace Micrososft.Knowzy.Repositories.Contracts
{
    public interface IOrderRepository
    {
        Task AddShipping(Shipping shipping);
        Task UpdateShipping(Shipping shipping);
        IUnitOfWork UnitOfWork { get; }
    }
}
