using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using POCforDI.Models;
using POCforDI.Services;

namespace POCforDI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ISingletonGuidGenerator _singletonGuidGenerator;
        private readonly IScopedGuidGenerator _scopedGuidGenerator;
        private readonly ITransientGuidGenerator _transientGuidGenerator;
        private readonly ScopedService _scopedService;

        public HomeController(ILogger<HomeController> logger, ISingletonGuidGenerator singleton, IScopedGuidGenerator scoped, ITransientGuidGenerator transient, ScopedService scopedService)
        {
            _singletonGuidGenerator = singleton;
            _scopedGuidGenerator = scoped;
            _transientGuidGenerator = transient;
            _scopedService = scopedService;

            _logger = logger;
        }

        public IActionResult Index()
        {
            ViewBag.SingletonGuid = _singletonGuidGenerator.Guid.ToString();
            ViewBag.ScopedGuid = _scopedGuidGenerator.Guid.ToString();
            ViewBag.TransientGuid = _transientGuidGenerator.Guid.ToString();

            //ScopedService scopedService = new ScopedService(_singletonGuidGenerator, _scopedGuidGenerator, _transientGuidGenerator);
            ViewBag.ServiceSingletonGuid = _scopedService.Singleton.Guid.ToString();
            ViewBag.ServiceScopedGuid = _scopedService.Scoped.Guid.ToString();
            ViewBag.ServiceTransientGuid = _scopedService.Transient.Guid.ToString();


            return View();
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
