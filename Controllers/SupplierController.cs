using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Warehouse.Models;

namespace Warehouse.Controllers;

public class SupplierController : Controller
{
    private readonly AppDbContext _db;

    public SupplierController(AppDbContext db)
    {
        _db = db;
    }

    public async Task<IActionResult> Index()
    {
        return View(await _db.Suppliers.ToListAsync());
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Supplier supplier)
    {
        if (ModelState.IsValid)
        {
            _db.Suppliers.Add(supplier);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        return View(supplier);
    }

    public async Task<IActionResult> Edit(int id)
    {
        var supplier = await _db.Suppliers.FindAsync(id);
        if (supplier == null)
            return NotFound();
        return View(supplier);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(Supplier supplier)
    {
        if (ModelState.IsValid)
        {
            _db.Entry(supplier).State = EntityState.Modified;
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        return View(supplier);
    }

    public async Task<IActionResult> Delete(int id)
    {
        var supplier = await _db.Suppliers.FindAsync(id);
        if (supplier == null)
            return NotFound();
        return View(supplier);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var supplier = await _db.Suppliers.FindAsync(id);
        if (supplier != null)
        {
            _db.Suppliers.Remove(supplier);
            await _db.SaveChangesAsync();
        }

        return RedirectToAction(nameof(Index));
    }
}
