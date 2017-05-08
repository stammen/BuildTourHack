using System.ComponentModel.DataAnnotations;

namespace Microsoft.Knowzy.Models.ViewModels
{
    public class OrderLineViewModel
    {
        public int Id { get; set; }
        [Display(Name = "Item number")]
        public string ItemNumber { get; set; }
        [Display(Name = "Item image")]
        public string ItemImage { get; set; }

        public int Quantity { get; set; }
    }
}
