using Microsoft.Knowzy.Domain;

namespace Microsoft.Knowzy.Common.Messages
{
    public class EditItemMessage
    {
        public EditItemMessage(DevelopmentItem item)
        {
            Item = item;
        }

        public DevelopmentItem Item { get; }
    }
}