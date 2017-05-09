using System.Threading.Tasks;
using Micrososft.Knowzy.Repositories.Contracts;

namespace Microsoft.Knowzy.Commands.OrderCommands.Add
{
    public class AddReceivingCommandHandler
    {
        private readonly IOrderRepository _orderRepository;

        public AddReceivingCommandHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task Execute(AddReceivingCommand command)
        {
            await _orderRepository.AddReceiving(command.ReceivingToAdd);
            await _orderRepository.UnitOfWork.SaveChangesAsync();
        }
    }
}
