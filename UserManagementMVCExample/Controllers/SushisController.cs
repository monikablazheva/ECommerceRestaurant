using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using UserManagementMVCExample.Data;
using UserManagementMVCExample.Enums;
using UserManagementMVCExample.Models;

namespace UserManagementMVCExample.Controllers
{
    [Authorize(Roles = "SuperAdmin, Admin")]
    public class SushisController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SushisController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Sushis
        public async Task<IActionResult> Index()
        {
              return View(await _context.Sushis.ToListAsync());
        }

        // GET: Sushis/Details/5
        public async Task<IActionResult> Details(int? id) //Read GET
        {
            if (id == null || _context.Sushis == null)
            {
                return NotFound();
            }

            var sushi = await _context.Sushis.FirstOrDefaultAsync(m => m.Id == id);
            if (sushi == null)
            {
                return NotFound();
            }

            return View(sushi);
        }

        // GET: Sushis/Create
        public IActionResult Create() //Create Page
        {
            return View();
        }

        // POST: Sushis/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,Count,Type,Price")] Sushi sushi) //Create POST
        {
            if (ModelState.IsValid)
            {
                _context.Add(sushi);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(sushi);
        }

        // GET: Sushis/Edit/5
        public async Task<IActionResult> Edit(int? id) //Edit page
        {
            if (id == null || _context.Sushis == null)
            {
                return NotFound();
            }

            var sushi = await _context.Sushis.FindAsync(id);
            if (sushi == null)
            {
                return NotFound();
            }
            return View(sushi);
        }

        // POST: Sushis/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,Count,Type,Price")] Sushi sushi) //Edit POST
        {
            if (id != sushi.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sushi);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SushiExists(sushi.Id))
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
            return View(sushi);
        }

        // GET: Sushis/Delete/5
        public async Task<IActionResult> Delete(int? id) //Delete Page
        {
            if (id == null || _context.Sushis == null)
            {
                return NotFound();
            }

            var sushi = await _context.Sushis
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sushi == null)
            {
                return NotFound();
            }

            return View(sushi);
        }

        // POST: Sushis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id) //Delete POST
        {
            if (_context.Sushis == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Sushis'  is null.");
            }
            var sushi = await _context.Sushis.FindAsync(id);
            if (sushi != null)
            {
                _context.Sushis.Remove(sushi);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SushiExists(int id)
        {
          return _context.Sushis.Any(e => e.Id == id);
        }
    }
}
