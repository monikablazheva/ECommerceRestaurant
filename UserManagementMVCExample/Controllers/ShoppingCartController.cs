using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;
using UserManagementMVCExample.Data;
using UserManagementMVCExample.Enums;
using UserManagementMVCExample.Models;
using UserManagementMVCExample.Models.ViewModels;
using UserManagementMVCExample.Services;

namespace UserManagementMVCExample.Controllers
{

    public class ShoppingCartController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly CartService shoppingCart;
        private readonly UserManager<ApplicationUser> _userManager;

        public ShoppingCartController(ApplicationDbContext context, CartService shoppingCart, UserManager<ApplicationUser> userManager)
        {
            this._context = context;
            this.shoppingCart = shoppingCart;
            this._userManager = userManager;
        }
        [Authorize(Roles = "SuperAdmin, Admin, Basic, Moderator")]
        public async Task<ActionResult> Index()
        {
            ClaimsPrincipal currentUser = this.User;
            var currentUserId = currentUser.FindFirst(ClaimTypes.NameIdentifier).Value;
            var user = await _userManager.FindByIdAsync(currentUserId);
            
            var cart = shoppingCart;

            ShoppingCartViewModel viewModel = new ShoppingCartViewModel
            {
                CartItems = cart.GetCartItems(),
                CartTotal = cart.GetTotal(),
                User = user
            };
            return View(viewModel);
        }
        public async Task<IActionResult> AddToCart(int? id)
        {
            if (id == null || _context.Products == null)
            {
                return NotFound();
            }

            var product = await _context.Products.FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            // Add it to the shopping cart
            var cart = shoppingCart;

            cart.AddToCart(product);
            // Go back to the main store page for more shopping
            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        public ActionResult RemoveFromCart(int id)
        {
            var cart = shoppingCart;

            // Get the name of the product to display confirmation
            var productName = _context.CartItems.Include(p => p.Product)
                .FirstOrDefault(p => p.Id == id).Product.Name;

            // Remove from cart
            int itemCount = cart.RemoveFromCart(id);

            // Display the confirmation message
            var results = new ShoppingCartRemoveViewModel
            {
                Message = WebUtility.HtmlEncode(productName) +
                    " has been removed from your shopping cart.",
                CartTotal = cart.GetTotal(),
                CartCount = cart.GetCount(),
                ItemCount = itemCount,
                DeleteId = id
            };
            return Json(results);
        }
    }
}
