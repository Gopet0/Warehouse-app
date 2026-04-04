using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;
using Warehouse.Models;

namespace Warehouse.Controllers
{
    public class StockTransactionController : Controller
    {
        private AppDbContext db = new AppDbContext();

        public ActionResult Index()
        {
            var transactions = db.StockTransactions
                .Include(t => t.Product)
                .Include(t => t.Supplier)
                .ToList();
            return View(transactions);
        }

        public ActionResult Create()
        {
            ViewBag.ProductId = new SelectList(db.Products, "Id", "Name");
            ViewBag.SupplierId = new SelectList(db.Suppliers, "Id", "CompanyName");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(StockTransaction transaction)
        {
            if (ModelState.IsValid)
            {
                // Update product quantity
                var product = db.Products.Find(transaction.ProductId);
                if (product != null)
                {
                    if (transaction.Type == "stock_in")
                        product.Quantity += transaction.Quantity;
                    else
                        product.Quantity -= transaction.Quantity;
                }

                db.StockTransactions.Add(transaction);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProductId = new SelectList(db.Products, "Id", "Name");
            ViewBag.SupplierId = new SelectList(db.Suppliers, "Id", "CompanyName");
            return View(transaction);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing) db.Dispose();
            base.Dispose(disposing);
        }
    }
}

