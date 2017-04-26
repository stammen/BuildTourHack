using Microsoft.AspNetCore.Mvc;
using Microsoft.Knowzy.Service.DataSource.Contracts;

namespace Microsoft.Knowzy.WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IDataSourceService _dataSourceService;

        public HomeController(IDataSourceService dataSourceService)
        {
            _dataSourceService = dataSourceService;
        }

        public IActionResult Index()
        {
            // TODO retrieve grid values
            var shippings = _dataSourceService.GetShippings();

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
