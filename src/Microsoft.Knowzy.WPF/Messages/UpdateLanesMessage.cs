using Microsoft.Knowzy.Domain.Enums;
using Microsoft.Knowzy.WPF.ViewModels;

namespace Microsoft.Knowzy.WPF.Messages
{
    public class UpdateLanesMessage
    {
        public UpdateLanesMessage(ItemViewModel item, DevelopmentStatus previousStatus)
        {
            Item = item;
            PreviousStatus = previousStatus;
        }

        public ItemViewModel Item { get; }

        public DevelopmentStatus PreviousStatus { get; }
    }
}
