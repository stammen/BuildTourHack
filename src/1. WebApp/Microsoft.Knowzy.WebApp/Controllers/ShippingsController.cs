using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
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

        public IActionResult Error()
        {
            return View();
        }

        #endregion

        #region Private Methods

        private async Task GenerateDropdowns()
        {
            var itemsTask = _orderQueries.GetItems();
            var postalCarrierTask = _orderQueries.GetPostalCarriers();

            await Task.WhenAll(itemsTask, postalCarrierTask);
            ViewBag.PostalCarrier = postalCarrierTask.Result;
            ViewBag.Item = itemsTask.Result;
        }

        #endregion
    }
}
