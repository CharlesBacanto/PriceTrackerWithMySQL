using Microsoft.AspNetCore.Mvc;

namespace PriceTrackerWithMySQL.Controllers
{
    public class PriceController : Controller
    {
        public IActionResult IndexPrice()
        {
            return View();
        }
    }
}
