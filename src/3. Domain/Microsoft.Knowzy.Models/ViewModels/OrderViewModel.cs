using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.Knowzy.Domain;

namespace Microsoft.Knowzy.Models.ViewModels
{
    public class OrderViewModel
    {
        [Display(Name = "Order Number:")]
        public string OrderNumber { get; set; }
        [Display(Name = "Company name:")]
        public string CompanyName { get; set; }
        [Display(Name = "Address:")]
        public string Address { get; set; }
        [Display(Name = "Contact Person:")]
        public string ContactPerson { get; set; }
        [Display(Name = "Contact email:")]
        public string Email { get; set; }
        [Display(Name = "Phone number:")]
        public string PhoneNumber { get; set; }
        [Display(Name = "Tracking:")]
        public string Tracking { get; set; }
        [Display(Name = "Postal Carrier:")]
        public string PostalCarrierName { get; set; }
        [Display(Name = "Status:")]
        public OrderStatus Status { get; set; }
        public List<OrderLineViewModel> OrderLines { get; set; }
    }
}
