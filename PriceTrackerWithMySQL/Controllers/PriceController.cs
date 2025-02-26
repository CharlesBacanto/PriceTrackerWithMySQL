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
        public IActionResult IndexPrice(string? searchTag)
        {
            var searchInDb = _context.TblPrice.Where(dataInDb => dataInDb.description.Contains(searchTag));
            var searchPrice = searchInDb.ToList();
            if (!string.IsNullOrEmpty(searchTag)) {
                return View(searchPrice);
            }
            var allPrices = _context.TblPrice.ToList();
            return View(allPrices);
        }  
        public IActionResult CreateEditPrice(int? id)
        {
            var priceIdInDb = _context.TblPrice.SingleOrDefault(priceDataId => priceDataId.id == id);
            if(id != null)
            {
            return View(priceIdInDb);
            }
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
            try
            {

                if (model.id == 0)
                {
                    _context.TblPrice.Add(model);
                }
                else
                {
                    _context.TblPrice.Update(model);
                }
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                
            }
                return RedirectToAction("IndexPrice");
        }
    }
}
