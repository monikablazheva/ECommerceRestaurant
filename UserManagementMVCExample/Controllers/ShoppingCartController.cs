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

        public ShoppingCartController(ApplicationDbContext context, CartService shoppingCart)
        {
            this._context = context;
            this.shoppingCart = shoppingCart;
        }

        [Authorize(Roles = "SuperAdmin, Admin, Basic, Moderator")]
        public ActionResult Index()
        {
            var cart = shoppingCart;

            ShoppingCartViewModel viewModel = new ShoppingCartViewModel
            {
                CartItems = cart.GetCartItems(),
                CartTotal = cart.GetTotalToString()
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

        [Authorize(Roles = "SuperAdmin, Admin, Basic, Moderator")]
        [HttpPost]
        public ActionResult RemoveFromCart(int cartItemId)
        {
            var cart = shoppingCart;
            var productName = _context.CartItems.Include(p => p.Product)
                .FirstOrDefault(p => p.Id == cartItemId).Product.Name;

            cart.RemoveFromCart(cartItemId);

            var results = new ShoppingCartRemoveViewModel
            {
                Message = WebUtility.HtmlEncode(productName) +
                    " has been removed from your shopping cart.",
                CartTotal = cart.GetTotalToString(),
                CartCount = cart.GetCount(),
                DeleteId = cartItemId
            };
            return Json(results);
        }

        [Authorize(Roles = "SuperAdmin, Admin, Basic, Moderator")]
        [HttpPost]
        public ActionResult IncreaseCartItemCount(int cartItemId)
        {
            var cart = shoppingCart;
            int itemCount = cart.IncreaseByOneCartItemCount(cartItemId);
            var results = new ShoppingCartUpdateItemCountViewModel
            {
                ItemCount = itemCount,
                CartTotal = cart.GetTotalToString(),
                CartCount = cart.GetCount()
            };
            return Json(results);
        }

        [Authorize(Roles = "SuperAdmin, Admin, Basic, Moderator")]
        [HttpPost]
        public ActionResult DecreaseCartItemCount(int cartItemId)
        {
            var cart = shoppingCart;
            int itemCount = cart.DecreaseByOneCartItemCount(cartItemId);
            var results = new ShoppingCartUpdateItemCountViewModel
            {
                ItemCount = itemCount,
                CartTotal = cart.GetTotalToString(),
                CartCount = cart.GetCount()
            };
            return Json(results);
        }
    }
}

