using Microsoft.AspNetCore.Mvc;
using PriceTrackerWithMySQL.Data;
using PriceTrackerWithMySQL.Models;

namespace PriceTrackerWithMySQL.Controllers
{
    public class PriceController : Controller
    {
        private readonly PriceTrackerDbContext _context;

        public PriceController(PriceTrackerDbContext context)
        {
            _context = context;
        }
        public IActionResult IndexPrice()
        {
            var allPrices = _context.TblPrice.ToList();
            return View(allPrices);
        }  
        public IActionResult CreateEditPrice()
        {
          
            return View();
        }  
        public IActionResult DeletePrice(int id)
        {
            var priceIdInDb = _context.TblPrice.SingleOrDefault(priceDataId => priceDataId.id == id);
            _context.Remove(priceIdInDb);
            _context.SaveChanges();
            return RedirectToAction("IndexPrice");
        } 
        public IActionResult CreateEditPriceForm(PriceModel model)
        {
            _context.TblPrice.Add(model);
            _context.SaveChanges();
            return RedirectToAction("IndexPrice");
        }
    }
}
