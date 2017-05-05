using System.ComponentModel.DataAnnotations;
using Microsoft.Knowzy.Domain;

namespace Microsoft.Knowzy.Models.ViewModels
{
    public class OrdersViewModel
    {
        [Display(Name = "Order No.")]
        public string OrderNumber { get; set; }
        [Display(Name = "Company Name")]
        public string CompanyName { get; set; }
        public string Tracking { get; set; }
        public OrderStatus Status { get; set; }
    }
}
