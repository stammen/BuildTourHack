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
    public class ReceivingsController : Controller
    {
        #region Fields

        private readonly IOrderQueries _orderQueries;
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        #endregion

        #region Constructor

        public ReceivingsController(IOrderQueries orderQueries, IOrderRepository orderRepository, IMapper mapper)
        {
            _orderQueries = orderQueries;
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        #endregion

        #region Public Methods

        public async Task<IActionResult> Index()
        {
            return View(await _orderQueries.GetReceivings());
        }

        public async Task<IActionResult> Details(string orderNumber)
        {
            return View(await _orderQueries.GetReceiving(orderNumber));
        }

        public async Task<IActionResult> Edit(string orderNumber)
        {
            var getReceivingTask = _orderQueries.GetReceiving(orderNumber);
            await Task.WhenAll(GenerateDropdowns(), getReceivingTask);
            return View(getReceivingTask.Result);
        }

        public async Task<IActionResult> Create()
        {
            await GenerateDropdowns();
            return View(new ReceivingViewModel { OrderLines = new List<OrderLineViewModel>() });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ReceivingViewModel receiving)
        {
            if (ModelState.IsValid)
            {
                var receivingModel = _mapper.Map<ReceivingViewModel, Receiving>(receiving);
                if (receivingModel.PostalCarrier == null)
                {
                    receivingModel.PostalCarrier = new PostalCarrier { Id = receiving.PostalCarrierId };
                }
                var command = new AddReceivingCommand(receivingModel);
                var handler = new AddReceivingCommandHandler(_orderRepository);
                await handler.Execute(command);
                return RedirectToAction("Index", "Receivings");
            }
            await GenerateDropdowns();
            return View(receiving);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ReceivingViewModel receiving)
        {
            if (ModelState.IsValid)
            {
                var receivingModel = _mapper.Map<ReceivingViewModel, Receiving>(receiving);
                if (receivingModel.PostalCarrier == null)
                {
                    receivingModel.PostalCarrier = new PostalCarrier { Id = receiving.PostalCarrierId };
                }
                var command = new EditReceivingCommand(receivingModel);
                var handler = new EditReceivingCommandHandler(_orderRepository);
                await handler.Execute(command);
                return RedirectToAction("Details", "Receivings", new { receiving.OrderNumber });
            }
            await GenerateDropdowns();
            return View(receiving);
        }

        public async Task<IActionResult> AddOrderItem(IEnumerable<string> itemNumbers)
        {
            var itemToAdd = (await _orderQueries.GetItems()).FirstOrDefault(item => itemNumbers.All(number => number != item.Number));
            var orderLineViewmodel = new OrderLineViewModel { ItemImage = itemToAdd.Image, ItemNumber = itemToAdd.Number, ItemPrice = itemToAdd.Price, Quantity = 1 };
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
