using Microsoft.Knowzy.Domain;

namespace Microsoft.Knowzy.Commands.OrderCommands.Add
{
    public class AddReceivingCommand
    {
        public Receiving ReceivingToAdd { get; }
        public AddReceivingCommand(Receiving receivingToAdd)
        {
            ReceivingToAdd = receivingToAdd;
        }
    }
}
