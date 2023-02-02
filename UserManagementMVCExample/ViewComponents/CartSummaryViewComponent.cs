using Microsoft.AspNetCore.Mvc;
using UserManagementMVCExample.Services;

namespace UserManagementMVCExample.ViewComponents
{
    public class CartSummaryViewComponent : ViewComponent
    {
        private readonly CartService shoppingCart;

        public CartSummaryViewComponent(CartService shoppingCart)
        {
            this.shoppingCart = shoppingCart;
        }

        public IViewComponentResult Invoke()
        {
            ViewData["CartCount"] = shoppingCart.GetCount();

            return View();
        }
    }
}
