using Microsoft.AspNetCore.Mvc;
using POCforDI.Services;

namespace POCforDI.Controllers
{
    public class TestController : Controller
    {
        private readonly ISingletonGuidGenerator _singletonGuidGenerator;

        public TestController(ISingletonGuidGenerator guidGenerator)
        {
            _singletonGuidGenerator = guidGenerator;
        }

        public IActionResult Index()
        {
            ViewBag.SingletonGuid = _singletonGuidGenerator.Guid.ToString();
            return View();
        }
    }
}
