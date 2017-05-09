using Microsoft.Knowzy.Domain;

namespace Microsoft.Knowzy.Commands.OrderCommands.Edit
{
    public class EditShippingCommand
    {
        public Shipping ShippingToEdit { get; }
        public EditShippingCommand(Shipping shippingToEdit)
        {
            ShippingToEdit = shippingToEdit;
        }
    }
}
