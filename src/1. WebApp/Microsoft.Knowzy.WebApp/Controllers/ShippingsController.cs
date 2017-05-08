using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Knowzy.Models.ViewModels;
using Microsoft.Knowzy.Service.DataSource.Contracts;

namespace Microsoft.Knowzy.WebApp.Controllers
{
    public class ShippingsController : Controller
    {
        #region Fields

        private readonly IOrderQueries _orderQueries;

        #endregion

        #region Constructor

        public ShippingsController(IOrderQueries orderQueries)
        {
            _orderQueries = orderQueries;
        }

        #endregion

        #region Public Methods

        public async Task<IActionResult> Index()
        {
            return View(await _orderQueries.GetShippings());
        }

        public async Task<IActionResult> Details(string orderNumber)
        {
            return View(await _orderQueries.GetShipping(orderNumber));
        }

        public async Task<IActionResult> Edit(string orderNumber)
        {
            var getShippingsTask = _orderQueries.GetShipping(orderNumber);
            await Task.WhenAll(GenerateDropdowns(), getShippingsTask);
            return View(getShippingsTask.Result);
        }

        public async Task<IActionResult> Create()
        {
            await GenerateDropdowns();
            return View(new ShippingViewModel{OrderLines = new List<OrderLineViewModel>()});
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ShippingViewModel shipping)
        {
            return null;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ShippingViewModel shipping)
        {
            return RedirectToAction("Details", "Shippings", new { shipping.OrderNumber});
        }

        public async Task<IActionResult> AddOrderItem(IEnumerable<string> itemNumbers)
        {
            var itemToAdd =  (await _orderQueries.GetItems()).FirstOrDefault(item => itemNumbers.All(number => number != item.Number));            
            var orderLineViewmodel = new OrderLineViewModel{ ItemImage = itemToAdd.Image, ItemNumber = itemToAdd.Number, Quantity = 1 };
            return PartialView("EditorTemplates/OrderLineViewModel", orderLineViewmodel);
        }

        public IActionResult Error()
        {
            return View();
        }

        #endregion

        #region Private Methods

        private async Task GenerateDropdowns()
        {
            ViewBag.PostalCarrier = await _orderQueries.GetPostalCarriers();
        }

        #endregion
    }
}
