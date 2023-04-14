using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using UserManagementMVCExample.Data;
using UserManagementMVCExample.Models;
using UserManagementMVCExample.Models.ViewModels;

namespace UserManagementMVCExample.Controllers
{
    [Authorize(Roles = "SuperAdmin, Admin, Moderator, Basic")]
    public class FavouritesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;


        public FavouritesController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            this._context = context;
            this._userManager = userManager;
        }

        [TempData]
        public bool IsFav { get; set; }

        public async Task<IActionResult> Index()
        {
            ClaimsPrincipal currentUser = this.User;
            var currentUserId = currentUser.FindFirst(ClaimTypes.NameIdentifier).Value;
            var user = await _userManager.Users.Include(u => u.FavouriteProducts).FirstOrDefaultAsync(u => u.Id == currentUserId);


            var favouriteProducts = user.FavouriteProducts.ToList();
            return View(favouriteProducts);
        }

        [HttpPost]
        public async Task<IActionResult> AddRemoveFavourite(int id)
        {

            ClaimsPrincipal currentUser = this.User;
            var currentUserId = currentUser.FindFirst(ClaimTypes.NameIdentifier).Value;
            var user = await _userManager.Users.Include(u => u.FavouriteProducts).FirstOrDefaultAsync(u => u.Id == currentUserId);


            Product favouriteProduct = user.FavouriteProducts.FirstOrDefault(p => p.Id == id);
            if(favouriteProduct == null)
            {
                favouriteProduct = await _context.Products.FindAsync(id);
                if (favouriteProduct != null)
                {
                    user.FavouriteProducts.Add(favouriteProduct);
                    await _userManager.UpdateAsync(user);
                    IsFav = true;
                }
            }
            else
            {
                user.FavouriteProducts.Remove(favouriteProduct);
                await _userManager.UpdateAsync(user);

                IsFav = false;
            }


            return Json(new { success = IsFav });
        }
    }
}
