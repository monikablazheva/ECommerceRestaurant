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
    public class SushiMenuController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SushiMenuController(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var sushis = await _context.Sushis.ToListAsync();
            var sushiMenuViewModel = new List<SushiMenuViewModel>();
            foreach (Sushi sushi in sushis)
            {
                var thisViewModel = new SushiMenuViewModel();
                thisViewModel.SushiID = sushi.Id;
                thisViewModel.Name = sushi.Name;
                thisViewModel.Price = sushi.Price;
                //thisViewModel.Roles = await GetUserRoles(user);
                //userRolesViewModel.Add(thisViewModel);
            }
            return View(sushiMenuViewModel);
        }
    }
}
