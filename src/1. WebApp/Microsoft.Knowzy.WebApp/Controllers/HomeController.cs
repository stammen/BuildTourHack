using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Knowzy.Service.DataSource.Contracts;

namespace Microsoft.Knowzy.WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IOrderQueries _orderQueries;

        public HomeController(IOrderQueries orderQueries)
        {
            _orderQueries = orderQueries;
        }

        public async Task<IActionResult> Index()
        {
            // TODO retrieve grid values
            var shippings = await _orderQueries.GetShippings();

            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
