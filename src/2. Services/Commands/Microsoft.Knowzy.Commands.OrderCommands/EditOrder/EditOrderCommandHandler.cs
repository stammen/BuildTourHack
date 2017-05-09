using System.Threading.Tasks;
using Micrososft.Knowzy.Repositories.Contracts;

namespace Microsoft.Knowzy.Commands.OrderCommands.EditOrder
{
    public class EditOrderCommandHandler
    {
        private readonly IOrderRepository _orderRepository;

        public EditOrderCommandHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task Execute(EditOrderCommand command)
        {
            await _orderRepository.UpdateShipping(command.ShippingToEdit);
            await _orderRepository.UnitOfWork.SaveChangesAsync();
        }
    }
}
