using Microsoft.Knowzy.Domain;

namespace Microsoft.Knowzy.Commands.OrderCommands.Add
{
    public class AddShippingCommand
    {
        public Shipping ShippingToAdd { get; }
        public AddShippingCommand(Shipping shippingToAdd)
        {
            ShippingToAdd = shippingToAdd;
        }
    }
}
