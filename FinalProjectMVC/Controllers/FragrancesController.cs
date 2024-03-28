using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FinalProjectMVC.Data;
using FinalProjectMVC.Models;
using Microsoft.AspNetCore.Authorization;

namespace FinalProjectMVC.Controllers
{
    [Authorize(Roles = "Admin")]
    public class FragrancesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FragrancesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Fragrances
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Fragrances.Include(f => f.Category);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Fragrances/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fragrance = await _context.Fragrances
                .Include(f => f.Category)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (fragrance == null)
            {
                return NotFound();
            }

            return View(fragrance);
        }

        // GET: Fragrances/Create
        public IActionResult Create()
        {
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "CategoryName");
            return View();
        }

        // POST: Fragrances/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Perfumer,Price,Image,CategoryId")] Fragrance fragrance)
        {
            if (!ModelState.IsValid)
            {
                _context.Add(fragrance);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "CategoryName", fragrance.CategoryId);
            return View(fragrance);
        }

        // GET: Fragrances/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fragrance = await _context.Fragrances.FindAsync(id);
            if (fragrance == null)
            {
                return NotFound();
            }
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "CategoryName", fragrance.CategoryId);
            return View(fragrance);
        }

        // POST: Fragrances/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Perfumer,Price,Image,CategoryId")] Fragrance fragrance)
        {
            if (id != fragrance.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(fragrance);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FragranceExists(fragrance.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "CategoryName", fragrance.CategoryId);
            return View(fragrance);
        }

        // GET: Fragrances/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fragrance = await _context.Fragrances
                .Include(f => f.Category)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (fragrance == null)
            {
                return NotFound();
            }

            return View(fragrance);
        }

        // POST: Fragrances/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var fragrance = await _context.Fragrances.FindAsync(id);
            if (fragrance != null)
            {
                _context.Fragrances.Remove(fragrance);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FragranceExists(int id)
        {
            return _context.Fragrances.Any(e => e.Id == id);
        }
    }
}
