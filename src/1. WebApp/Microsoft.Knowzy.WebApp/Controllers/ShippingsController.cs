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

        public IActionResult Error()
        {
            return View();
        }

        #endregion
    }
}
