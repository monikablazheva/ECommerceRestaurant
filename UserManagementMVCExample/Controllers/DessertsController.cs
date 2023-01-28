using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using UserManagementMVCExample.Data;
using UserManagementMVCExample.Enums;
using UserManagementMVCExample.Models;

namespace UserManagementMVCExample.Controllers
{
    [Authorize(Roles = "SuperAdmin, Admin")]
    public class DessertsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DessertsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Desserts
        public async Task<IActionResult> Index()
        {
              return View(await _context.Desserts.ToListAsync());
        }

        // GET: Desserts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Desserts == null)
            {
                return NotFound();
            }

            var dessert = await _context.Desserts
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dessert == null)
            {
                return NotFound();
            }

            return View(dessert);
        }

        // GET: Desserts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Desserts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,Grams,Price")] Dessert dessert)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dessert);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dessert);
        }

        // GET: Desserts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Desserts == null)
            {
                return NotFound();
            }

            var dessert = await _context.Desserts.FindAsync(id);
            if (dessert == null)
            {
                return NotFound();
            }
            return View(dessert);
        }

        // POST: Desserts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,Grams,Price,ImageURL")] Dessert dessert)
        {
            if (id != dessert.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var data = _context.Desserts.AsNoTracking().Where(x => x.Id == dessert.Id).FirstOrDefault();
                    byte[] ImagePath = data.ImageURL;
                    data = null;

                    if (Request.Form.Files.Count > 0)
                    {
                        IFormFile file = Request.Form.Files.FirstOrDefault();
                        using (var dataStream = new MemoryStream())
                        {
                            await file.CopyToAsync(dataStream);
                            dessert.ImageURL = dataStream.ToArray();
                        }
                    }
                    else
                    {
                        dessert.ImageURL = ImagePath;
                    }
                    _context.Update(dessert);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DessertExists(dessert.Id))
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
            return View(dessert);
        }

        // GET: Desserts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Desserts == null)
            {
                return NotFound();
            }

            var dessert = await _context.Desserts
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dessert == null)
            {
                return NotFound();
            }

            return View(dessert);
        }

        // POST: Desserts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Desserts == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Dessert'  is null.");
            }
            var dessert = await _context.Desserts.FindAsync(id);
            if (dessert != null)
            {
                _context.Desserts.Remove(dessert);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DessertExists(int id)
        {
          return _context.Desserts.Any(e => e.Id == id);
        }
    }
}
