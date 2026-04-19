using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Warehouse.Models;

namespace Warehouse.Controllers;

[Authorize]
public class StockTransactionController : Controller
{
    private readonly AppDbContext _db;

    public StockTransactionController(AppDbContext db)
    {
        _db = db;
    }

    public async Task<IActionResult> Index()
    {
        var transactions = await _db.StockTransactions
            .Include(t => t.Product)
            .Include(t => t.Supplier)
            .ToListAsync();
        return View(transactions);
    }

    public async Task<IActionResult> Create()
    {
        await PopulateTransactionLookupsAsync();
        return View(new StockTransaction
        {
            Quantity = 1,
            TransactionDate = DateTime.Now
        });
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(
        [Bind(Prefix = "")] StockTransaction transaction)
    {
        transaction.Notes = transaction.Notes?.Trim() ?? string.Empty;
        if (transaction.TransactionDate == default)
            transaction.TransactionDate = DateTime.Now;

        if (ModelState.IsValid)
        {
            var product = await _db.Products.FindAsync(transaction.ProductId);
            if (product != null)
            {
                if (transaction.Type == "stock_in")
                    product.Quantity += transaction.Quantity;
                else
                    product.Quantity -= transaction.Quantity;
            }

            _db.StockTransactions.Add(transaction);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        await PopulateTransactionLookupsAsync();
        return View(transaction);
    }

    private async Task PopulateTransactionLookupsAsync()
    {
        ViewBag.ProductId = new SelectList(await _db.Products.ToListAsync(), "Id", "Name");
        ViewBag.SupplierId = new SelectList(await _db.Suppliers.ToListAsync(), "Id", "CompanyName");
    }
}
