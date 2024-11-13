using DI_Service_LifeTime.Models;
using DI_Service_LifeTime.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Text;

namespace DI_Service_LifeTime.Controllers
{
    public class HomeController : Controller
    {
        private readonly ISingletonGuidService _singleton1;
        private readonly ISingletonGuidService _singleton2;

        private readonly IScopedGuidService _scoped1;
        private readonly IScopedGuidService _scoped2;

        private readonly ITransientGuidService _transient1;
        private readonly ITransientGuidService _transient2;
        
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, ISingletonGuidService singleton1, ISingletonGuidService singleton2, 
            IScopedGuidService scoped1, IScopedGuidService scoped2, ITransientGuidService transient1, ITransientGuidService transient2)
        {
            _logger = logger;
            _singleton1 = singleton1;
            _singleton2 = singleton2;
            _scoped1 = scoped1;
            _scoped2 = scoped2;
            _transient1 = transient1;
            _transient2 = transient2;
        }

        public IActionResult Index()
        {
            StringBuilder messages = new StringBuilder();
            messages.Append($"Transient1 : {_transient1.GetGuid()}\n");
            messages.Append($"Transient2 : {_transient2.GetGuid()}\n\n\n");
            messages.Append($"Scoped1 : {_scoped1.GetGuid()}\n");
            messages.Append($"Scoped2 : {_scoped2.GetGuid()}\n\n\n"); 
            messages.Append($"Singleton1 : {_singleton1.GetGuid()}\n");
            messages.Append($"Singleton2 : {_singleton2.GetGuid()}\n\n\n");

            return Ok( messages.ToString() );
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
