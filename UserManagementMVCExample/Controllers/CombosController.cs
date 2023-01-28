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
using UserManagementMVCExample.Models.ViewModels;

namespace UserManagementMVCExample.Controllers
{
    [Authorize(Roles = "SuperAdmin, Admin")]
    public class CombosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CombosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Combos
        public async Task<IActionResult> Index(int? id, int? sushiID)
        {
            var viewModel = new ComboIndexDataViewModel();
            viewModel.Combos = await _context.Combos
                  .Include(c => c.SushiAssignments)
                    .ThenInclude(c => c.Sushi)
                  .OrderBy(c => c.Name)
                  .ToListAsync();

            if (id != null)
            {
                ViewData["ComboID"] = id.Value;
                Combo combo = viewModel.Combos.Where(
                    c => c.Id == id.Value).Single();
                viewModel.Sushis = combo.SushiAssignments.Select(s => s.Sushi);
            }

            if (sushiID != null)
            {
                ViewData["SuhsiID"] = sushiID.Value;
                var selectedSushis = viewModel.Sushis.Where(x => x.Id == sushiID).Single();
            }

            return View(viewModel);
        }

        // GET: Combos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Combos == null)
            {
                return NotFound();
            }

            var combo = await _context.Combos
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
            var combo = new Combo();
            combo.SushiAssignments = new List<SushiAssignmentViewModel>();
            PopulateAssignedSushiData(combo);
            return View();
        }

        // POST: Combos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,Count,Price")] Combo combo, string[] selectedSushis)
        {
            try
            {
                if (selectedSushis != null)
                {
                    combo.SushiAssignments = new List<SushiAssignmentViewModel>();
                    foreach (var sushi in selectedSushis)
                    {
                        var sushiToAdd = new SushiAssignmentViewModel { ComboID = combo.Id, SushiID = int.Parse(sushi) };
                        combo.SushiAssignments.Add(sushiToAdd);
                    }
                }
                if (ModelState.IsValid)
                {
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

            PopulateAssignedSushiData(combo);
            return View(combo);
        }

        // GET: Combos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Combos == null)
            {
                return NotFound();
            }

            var combo = await _context.Combos.Include(c => c.SushiAssignments).ThenInclude(c => c.Sushi).AsNoTracking().FirstOrDefaultAsync(m => m.Id == id);
            if (combo == null)
            {
                return NotFound();
            }
            PopulateAssignedSushiData(combo);
            return View(combo);
        }

        // POST: Combos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,Count,Price,ImageURL")] Combo combo, string[] selectedSushis)
        {
            if (id != combo.Id)
            {
                return NotFound();
            }

            var comboToUpdate = await _context.Combos.Include(c => c.SushiAssignments).ThenInclude(c => c.Sushi).FirstOrDefaultAsync(m => m.Id == id);
            if (await TryUpdateModelAsync<Combo>(
                comboToUpdate,
                "",
                c => c.Name, c => c.Count, c => c.Price, c => c.ImageURL))
            {
                UpdateComboSushis(selectedSushis, comboToUpdate);
                try
                {
                    var data = _context.Combos.AsNoTracking().Where(x => x.Id == comboToUpdate.Id).FirstOrDefault();
                    byte[] ImagePath = data.ImageURL;
                    data = null;

                    if (Request.Form.Files.Count > 0)
                    {
                        IFormFile file = Request.Form.Files.FirstOrDefault();
                        using (var dataStream = new MemoryStream())
                        {
                            await file.CopyToAsync(dataStream);
                            comboToUpdate.ImageURL = dataStream.ToArray();
                        }
                    }
                    else
                    {
                        comboToUpdate.ImageURL = ImagePath;
                    }
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateException /* ex */)
                {
                    //Log the error (uncomment ex variable name and write a log.)
                    ModelState.AddModelError("", "Unable to save changes. " +
                        "Try again, and if the problem persists, " +
                        "see your system administrator.");
                }
                return RedirectToAction(nameof(Index));
            }
            UpdateComboSushis(selectedSushis, comboToUpdate);
            PopulateAssignedSushiData(comboToUpdate);
            return View(comboToUpdate);
        }
        private void PopulateAssignedSushiData(Combo combo)
        {
            var allSushis = _context.Sushis;
            var comboSushis = new HashSet<int>(combo.SushiAssignments.Select(s => s.SushiID));
            var viewModel = new List<AssignedSushiDataViewModel>();
            foreach (var sushi in allSushis)
            {
                viewModel.Add(new AssignedSushiDataViewModel
                {
                    SushiID = sushi.Id,
                    Name = sushi.Name,
                    Assigned = comboSushis.Contains(sushi.Id)
                });
            }
            ViewData["Sushis"] = viewModel;
        }
        private void UpdateComboSushis(string[] selectedSushis, Combo comboToUpdate)
        {
            if (selectedSushis == null)
            {
                comboToUpdate.SushiAssignments = new List<SushiAssignmentViewModel>();
                return;
            }

            var selectedSushisHS = new HashSet<string>(selectedSushis);
            var comboSushis = new HashSet<int>
                (comboToUpdate.SushiAssignments.Select(s => s.Sushi.Id));
            foreach (var sushi in _context.Sushis)
            {
                if (selectedSushisHS.Contains(sushi.Id.ToString()))
                {
                    if (!comboSushis.Contains(sushi.Id))
                    {
                        comboToUpdate.SushiAssignments.Add(new SushiAssignmentViewModel { ComboID = comboToUpdate.Id, SushiID = sushi.Id });
                    }
                }
                else
                {

                    if (comboSushis.Contains(sushi.Id))
                    {
                        SushiAssignmentViewModel sushiToRemove = comboToUpdate.SushiAssignments.FirstOrDefault(c => c.SushiID == sushi.Id);
                        _context.Remove(sushiToRemove);
                    }
                }
            }
        }

        // GET: Combos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Combos == null)
            {
                return NotFound();
            }

            var combo = await _context.Combos
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
            if (_context.Combos == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Combo'  is null.");
            }
            Combo combo = await _context.Combos.Include(c => c.SushiAssignments).SingleAsync(c => c.Id == id);
            if (combo != null)
            {
                _context.Combos.Remove(combo);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ComboExists(int id)
        {
            return _context.Combos.Any(e => e.Id == id);
        }
    }
}
