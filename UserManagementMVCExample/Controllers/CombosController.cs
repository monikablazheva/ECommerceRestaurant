using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using UserManagementMVCExample.Data;
using UserManagementMVCExample.Models;

namespace UserManagementMVCExample.Controllers
{
    public class CombosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CombosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Combos
        public async Task<IActionResult> Index()
        {
              return View(await _context.Combo.ToListAsync());
        }

        // GET: Combos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Combo == null)
            {
                return NotFound();
            }

            var combo = await _context.Combo
                .FirstOrDefaultAsync(m => m.Id == id);
            if (combo == null)
            {
                return NotFound();
            }

            return View(combo);
        }

        // GET: Combos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Combos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Count,Price")] Combo combo, string[] selectedSushis)
        {
            try
            {
                if (selectedSushis != null)
                {
                    combo.Sushis = new List<Sushi>();
                    foreach (var sushi in selectedSushis)
                    {
                        var sushiToAdd = new Sushi { Id = int.Parse(sushi) };
                        combo.Sushis.Add(sushiToAdd);
                    }
                }
                if (ModelState.IsValid)
                {
                    //var c = new Combo { Name = combo.Name };
                    //AddOrUpdateSushis(c, combo.Sushis);
                    _context.Add(combo);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }

            }
            catch (DbUpdateException /* ex */)
            {
                //Log the error (uncomment ex variable name and write a log.
                ModelState.AddModelError("", "Unable to save changes. " +
                    "Try again, and if the problem persists " +
                    "see your system administrator.");
            }
            return View(combo);
        }
        /*private void AddOrUpdateSushis(Combo combo, IEnumerable<Sushi> sushis)
        {
            if (sushis != null)
            {
                foreach (var sushi in sushis)
                {
                    var sushiToAdd = new Sushi { Id = sushi.Id };
                    _context.Sushis.Attach(sushiToAdd);
                    combo.Sushis.Add(sushiToAdd);
                }
            }
        }*/

        // GET: Combos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Combo == null)
            {
                return NotFound();
            }

            var combo = await _context.Combo.FindAsync(id);
            if (combo == null)
            {
                return NotFound();
            }
            return View(combo);
        }

        // POST: Combos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Name,Count,Price")] Combo combo)
        {
            if (id != combo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(combo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ComboExists(combo.Id))
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
            return View(combo);
        }

        // GET: Combos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Combo == null)
            {
                return NotFound();
            }

            var combo = await _context.Combo
                .FirstOrDefaultAsync(m => m.Id == id);
            if (combo == null)
            {
                return NotFound();
            }

            return View(combo);
        }

        // POST: Combos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Combo == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Combo'  is null.");
            }
            var combo = await _context.Combo.FindAsync(id);
            if (combo != null)
            {
                _context.Combo.Remove(combo);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ComboExists(int id)
        {
          return _context.Combo.Any(e => e.Id == id);
        }
    }
}
