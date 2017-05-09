using Microsoft.Knowzy.Domain;

namespace Microsoft.Knowzy.Commands.OrderCommands.Edit
{
    public class EditReceivingCommand
    {
        public Receiving ReceivingToEdit { get; }
        public EditReceivingCommand(Receiving receivingToEdit)
        {
            ReceivingToEdit = receivingToEdit;
        }
    }
}
