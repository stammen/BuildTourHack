using Microsoft.Knowzy.Domain;

namespace Microsoft.Knowzy.Commands.OrderCommands.AddOrder
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
