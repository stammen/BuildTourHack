using System.Threading.Tasks;
using Micrososft.Knowzy.Repositories.Contracts;

namespace Microsoft.Knowzy.Commands.OrderCommands.AddOrder
{
    public class AddShippingCommandHandler
    {
        private readonly IOrderRepository _orderRepository;

        public AddShippingCommandHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task Execute(AddShippingCommand command)
        {
            await _orderRepository.AddShipping(command.ShippingToAdd);
            await _orderRepository.UnitOfWork.SaveChangesAsync();
        }
    }
}
