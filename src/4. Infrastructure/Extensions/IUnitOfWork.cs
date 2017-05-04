using System.Threading;
using System.Threading.Tasks;

namespace Extensions
{
    public interface IUnitOfWork
    {
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));
    }
}
