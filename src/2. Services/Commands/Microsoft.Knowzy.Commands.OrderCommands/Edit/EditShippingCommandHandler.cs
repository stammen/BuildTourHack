using System.Threading.Tasks;
using Micrososft.Knowzy.Repositories.Contracts;

namespace Microsoft.Knowzy.Commands.OrderCommands.Edit
{
    public class EditShippingCommandHandler
    {
        private readonly IOrderRepository _orderRepository;

        public EditShippingCommandHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task Execute(EditShippingCommand command)
        {
            await _orderRepository.UpdateShipping(command.ShippingToEdit);
            await _orderRepository.UnitOfWork.SaveChangesAsync();
        }
    }
}
