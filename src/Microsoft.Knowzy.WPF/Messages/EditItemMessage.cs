using Microsoft.Knowzy.WPF.ViewModels;

namespace Microsoft.Knowzy.WPF.Messages
{
    public class EditItemMessage
    {
        public EditItemMessage(ItemViewModel item)
        {
            Item = item;
        }

        public ItemViewModel Item { get; }
    }
}