using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using UserManagementMVCExample.Data;
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
        /*public async Task<IActionResult> Index()
        {
            var cart = shoppingCart;
            return View(cart);

            // Set up our ViewModel
            var viewModel = new ShoppingCartViewModel
            {
                CartItems = cart.GetCartItems(),
                CartTotal = cart.GetTotal()
            };
            // Return the view
            return View(viewModel);
        }*/
    }
}
