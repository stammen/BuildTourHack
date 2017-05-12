using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Knowzy.Commands.OrderCommands.Add;
using Microsoft.Knowzy.Commands.OrderCommands.Edit;
using Microsoft.Knowzy.Domain;
using Microsoft.Knowzy.Models.ViewModels;
using Microsoft.Knowzy.Service.DataSource.Contracts;
using Micrososft.Knowzy.Repositories.Contracts;

namespace Microsoft.Knowzy.WebApp.Controllers
{
    public class ShippingsController : Controller
    {
        #region Fields

        private readonly IOrderQueries _orderQueries;
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        #endregion

        #region Constructor

        public ShippingsController(IOrderQueries orderQueries, IOrderRepository orderRepository, IMapper mapper)
        {
            _orderQueries = orderQueries;
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        #endregion

        #region Public Methods

        public async Task<IActionResult> Index()
        {
            return View(await _orderQueries.GetShippings());
        }

        public async Task<IActionResult> Details(string orderId)
        {
            return View(await _orderQueries.GetShipping(orderId));
        }

        public async Task<IActionResult> Edit(string orderId)
        {
            var getShippingTask = _orderQueries.GetShipping(orderId);
            var getNumberOfAvailableProducts = _orderQueries.GetProductCount();
            await Task.WhenAll(GenerateDropdowns(), getShippingTask, getNumberOfAvailableProducts);
            var order = getShippingTask.Result;
            order.MaxAvailableItems = getNumberOfAvailableProducts.Result;
            return View(order);
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
            if (ModelState.IsValid)
            {
                var shippingModel = _mapper.Map<ShippingViewModel, Shipping>(shipping);
                var command = new AddShippingCommand(shippingModel);
                var handler = new AddShippingCommandHandler(_orderRepository);
                await handler.Execute(command);
                return RedirectToAction("Index", "Shippings");
            }
            await GenerateDropdowns();
            return View(shipping);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ShippingViewModel shipping)
        {
            if (ModelState.IsValid)
            {
                var shippingModel = _mapper.Map<ShippingViewModel, Shipping>(shipping);
                var command = new EditShippingCommand(shippingModel);
                var handler = new EditShippingCommandHandler(_orderRepository);
                await handler.Execute(command);
                return RedirectToAction("Details", "Shippings", new { orderId = shipping.Id });
            }
            await GenerateDropdowns();
            return View(shipping);
        }

        public async Task<IActionResult> AddOrderItem(IEnumerable<string> productIds)
        {
            var itemToAdd =  (await _orderQueries.GetProducts()).FirstOrDefault(product => productIds.All(id => id != product.Id));            
            var orderLineViewmodel = new OrderLineViewModel{ ProductImage = itemToAdd.Image, ProductId = itemToAdd.Id, ProductPrice = itemToAdd.Price, Quantity = 1 };
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
