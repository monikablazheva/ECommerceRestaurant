using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserManagementMVCExample.Data;
using UserManagementMVCExample.Models;
using UserManagementMVCExample.Models.ViewModels;

namespace UserManagementMVCExample.Controllers
{
    public class ProductsMenuController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProductsMenuController(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var sushis = await _context.Sushis.ToListAsync();
            var combos = await _context.Combos.ToListAsync();
            var desserts = await _context.Desserts.ToListAsync();
            var beverages = await _context.Beverages.ToListAsync();
            var productsMenuViewModel = new ProductsMenuViewModel
            {
                Sushis = sushis,
                Combos = combos,
                Desserts = desserts,
                Beverages = beverages
            };
            return View(productsMenuViewModel);
        }
    }
}
