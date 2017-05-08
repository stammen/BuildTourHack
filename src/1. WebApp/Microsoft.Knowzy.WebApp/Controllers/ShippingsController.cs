using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Knowzy.Commands.OrderCommands.AddOrder;
using Microsoft.Knowzy.Commands.OrderCommands.EditOrder;
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
            if (ModelState.IsValid)
            {
                var command = new AddShippingCommand(_mapper.Map<ShippingViewModel, Shipping>(shipping));
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
                var command = new EditOrderCommand(_mapper.Map<ShippingViewModel, Shipping>(shipping));
                var handler = new EditOrderCommandHandler(_orderRepository);
                await handler.Execute(command);
                return RedirectToAction("Details", "Shippings", new { shipping.OrderNumber });
            }
            await GenerateDropdowns();
            return View(shipping);
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
