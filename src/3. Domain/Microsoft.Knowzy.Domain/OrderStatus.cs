using System.ComponentModel.DataAnnotations;

namespace Microsoft.Knowzy.Domain
{
    public enum OrderStatus
    {
        Pending,
        [Display(Name="In Transit")]
        InTransit,
        Delivered
    }
}
