using System.Threading.Tasks;
using Micrososft.Knowzy.Repositories.Contracts;

namespace Microsoft.Knowzy.Commands.OrderCommands.Edit
{
    public class EditReceivingCommandHandler
    {
        private readonly IOrderRepository _orderRepository;

        public EditReceivingCommandHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task Execute(EditReceivingCommand command)
        {
            await _orderRepository.UpdateReceiving(command.ReceivingToEdit);
            await _orderRepository.UnitOfWork.SaveChangesAsync();
        }
    }
}
