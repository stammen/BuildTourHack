using Microsoft.Knowzy.Domain;

namespace Microsoft.Knowzy.Common.Messages
{
    public class EditItemMessage
    {
        public EditItemMessage(Product item)
        {
            Item = item;
        }

        public Product Item { get; }
    }
}