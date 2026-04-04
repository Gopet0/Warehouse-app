using Microsoft.AspNetCore.Mvc;
using Warehouse.Models;

namespace Warehouse.Controllers
{
    public class HomeController: Controller
    {
        private AppDbContext db = new AppDbContext();

        public ActionResult Index()
        {
            ViewBag.TotalProducts = db.Products.Count();
            ViewBag.TotalSuppliers = db.Suppliers.Count();
            ViewBag.LowStock = db.Products.Count(p => p.Quantity <= p.MinQuantity);
            ViewBag.TotalTransactions = db.StockTransactions.Count();
            return View();
        }

    }
}
