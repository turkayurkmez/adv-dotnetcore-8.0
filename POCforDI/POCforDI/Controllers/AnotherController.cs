using Microsoft.AspNetCore.Mvc;
using POCforDI.Services;

namespace POCforDI.Controllers
{
    public class AnotherController(IScopedGuidGenerator guidGenerator) : Controller
    {


        public IActionResult Index()
        {
            var guidData = guidGenerator.Guid.ToString();
            ViewBag.GuidData = guidData;
            return View();
        }
    }
}
