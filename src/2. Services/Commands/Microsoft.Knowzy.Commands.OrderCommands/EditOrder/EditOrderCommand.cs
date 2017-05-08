using Microsoft.Knowzy.Domain;

namespace Microsoft.Knowzy.Commands.OrderCommands.EditOrder
{
    public class EditOrderCommand
    {
        public Shipping ShippingToEdit { get; }
        public EditOrderCommand(Shipping shippingToEdit)
        {
            ShippingToEdit = shippingToEdit;
        }
    }
}
