using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RetailFlow.Data;
using RetailFlow.Models;
namespace RetailFlow.Controllers;
public class ProductsController : Controller
{
    private readonly RetailFlowDbContext _context;
    public ProductsController(RetailFlowDbContext context) => _context = context;

    public async Task<IActionResult> Index(string? search, string? category)
    {
        var query = _context.Products.AsNoTracking().AsQueryable();
        if (!string.IsNullOrWhiteSpace(search))
            query = query.Where(p => p.Name.Contains(search) || p.Category.Contains(search));
        if (!string.IsNullOrWhiteSpace(category))
            query = query.Where(p => p.Category == category);
        ViewData["Search"] = search;
        ViewData["Category"] = category;
        ViewData["Categories"] = await _context.Products.AsNoTracking().Select(p => p.Category).Distinct().OrderBy(c => c).ToListAsync();
        return View(await query.OrderBy(p => p.Name).ToListAsync());
    }

    public async Task<IActionResult> Details(int? id)
    {
        if (id is null) return NotFound();
        var product = await _context.Products.AsNoTracking().FirstOrDefaultAsync(p => p.Id == id);
        return product is null ? NotFound() : View(product);
    }

    public IActionResult Create() => View(new Product());
    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Product product)
    {
        if (!ModelState.IsValid) return View(product);
        product.UpdatedAt = DateTime.UtcNow;
        _context.Products.Add(product);
        await _context.SaveChangesAsync();
        TempData["Success"] = "Product created successfully.";
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Edit(int? id)
    {
        if (id is null) return NotFound();
        var product = await _context.Products.FindAsync(id);
        return product is null ? NotFound() : View(product);
    }
    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, Product product)
    {
        if (id != product.Id) return NotFound();
        if (!ModelState.IsValid) return View(product);
        var existing = await _context.Products.FindAsync(id);
        if (existing is null) return NotFound();
        existing.Name = product.Name; existing.Category = product.Category;
        existing.Quantity = product.Quantity; existing.UnitPrice = product.UnitPrice;
        existing.Description = product.Description; existing.UpdatedAt = DateTime.UtcNow;
        await _context.SaveChangesAsync();
        TempData["Success"] = "Product updated successfully.";
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Delete(int? id)
    {
        if (id is null) return NotFound();
        var product = await _context.Products.AsNoTracking().FirstOrDefaultAsync(p => p.Id == id);
        return product is null ? NotFound() : View(product);
    }
    [HttpPost, ActionName("Delete"), ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var product = await _context.Products.FindAsync(id);
        if (product is not null) { _context.Products.Remove(product); await _context.SaveChangesAsync(); TempData["Success"] = "Product deleted successfully."; }
        return RedirectToAction(nameof(Index));
    }
}
