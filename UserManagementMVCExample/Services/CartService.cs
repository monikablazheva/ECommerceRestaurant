using System.Net.NetworkInformation;
using UserManagementMVCExample.Data;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using UserManagementMVCExample.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace UserManagementMVCExample.Services
{
    public class CartService
    {
        private readonly ApplicationDbContext _context;
        private readonly IHttpContextAccessor httpContextAccessor;
        string ShoppingCartId { get; set; }
        public const string CartSessionKey = "CartID";
        public CartService(ApplicationDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            this._context = context;
            this.httpContextAccessor = httpContextAccessor;


            this.ShoppingCartId = this.GetCartId();
        }
        
        public string GetCartId()
        {
            HttpContext context = this.httpContextAccessor.HttpContext;


            if (context.Session.GetString(CartSessionKey) == null)
            {
                if (!string.IsNullOrWhiteSpace(context.User?.Identity?.Name))
                {
                    context.Session.SetString(CartSessionKey, context.User.Identity.Name);
                }
                else
                {
                    // Generate a new random GUID using System.Guid class
                    Guid tempCartId = Guid.NewGuid();

                    // Send tempCartId back to client as a cookie
                    context.Session.SetString(CartSessionKey, tempCartId.ToString());
                }
            }

            return context.Session.GetString(CartSessionKey).ToString();
        }

        // When a user has logged in, transfer their shopping cart to be associated with their username
        public void MigrateCart(string userName)
        {
            this.ShoppingCartId = userName;
            var cartItems = _context.CartItems.Where(
                c => c.CartId == ShoppingCartId);

            foreach (CartItem item in cartItems)
            {
                item.CartId = userName;
            }
            _context.SaveChanges();
        }

        public void AddToCart(Product product)
        {
            var cartItem = _context.CartItems.Include(c =>c.Product).SingleOrDefault(c => c.CartId == ShoppingCartId && c.ProductId == product.Id);

            if (cartItem == null)
            {
                // Create a new cart item if no cart item exists
                cartItem = new CartItem
                {
                    Product = product,
                    ProductId = product.Id,
                    CartId = ShoppingCartId,
                    Count = 1,
                    DateCreated = DateTime.Now
                };
                _context.CartItems.Add(cartItem);
                _context.SaveChanges();
            }
            else
            {
                cartItem.Count++;
            }
            // Save changes
            _context.SaveChanges();
        }
        public void RemoveFromCart(int id)
        {
            // Get the cart
            var cartItem = _context.CartItems.Include(c=>c.Product).Single(
                c => c.CartId == ShoppingCartId
                && c.Id == id);

            if (cartItem != null)
            {
                _context.CartItems.Remove(cartItem);
                _context.SaveChanges();
            }
        }
        public int IncreaseByOneCartItemCount(int id)
        {
            // Get the cart
            var cartItem = _context.CartItems.Include(c => c.Product).Single(
                c => c.CartId == ShoppingCartId
                && c.Id == id);

            int itemCount = 0;
            if(cartItem !=null)
            {
                cartItem.Count++;
                itemCount = cartItem.Count;
                _context.CartItems.Update(cartItem);
                _context.SaveChanges();
            }
            return itemCount;
        }
        public int DecreaseByOneCartItemCount(int id)
        {
            // Get the cart
            var cartItem = _context.CartItems.Include(c => c.Product).Single(
                c => c.CartId == ShoppingCartId
                && c.Id == id);

            int itemCount = 0;
            if (cartItem != null)
            {
                cartItem.Count--;
                itemCount = cartItem.Count;
                _context.CartItems.Update(cartItem);
                _context.SaveChanges();
            }
            return itemCount;
        }
        public void EmptyCart()
        {
            var cartItems = _context.CartItems.Include(c => c.Product).Where(
                c => c.CartId == ShoppingCartId);

            foreach (var cartItem in cartItems)
            {
                _context.CartItems.Remove(cartItem);
            }
            // Save changes
            _context.SaveChanges();
        }
        public List<CartItem> GetCartItems()
        {
            return _context.CartItems.Include(c => c.Product).Where(c => c.CartId == ShoppingCartId).ToList();
        }
        public int GetCount()
        {
            var cartItems = _context.CartItems.Include(c => c.Product).Where(c => c.CartId == ShoppingCartId);
            int? count = 0;
            foreach (var cartItem in cartItems)
            {
                count += cartItem.Count;
            }
            // Return 0 if all entries are null
            return count ?? 0;
        }
        public decimal GetTotal()
        {
            var cartItems = _context.CartItems.Include(c => c.Product).Where(c => c.CartId == ShoppingCartId);
            decimal? total = 0;
            foreach (var cartItem in cartItems)
            {
                total += cartItem.SubTotal();
            }
            return total ?? decimal.Zero;
        }
        public string GetTotalToString()
        {
            decimal? total = this.GetTotal();
            string totalText = total.ToString() + " лв.";
            return totalText;
        }

        public void CreateOrder(Order order)
        {
            decimal orderTotal = 0;

            var cartItems = GetCartItems();

            foreach (var item in cartItems)
            {
                var orderItem = new OrdersItem
                {
                    Order = order,
                    Product = item.Product,
                    Count = item.Count,
                    Price = item.SubTotal()
                };
                orderTotal += item.SubTotal();

                _context.OrdersItems.Add(orderItem);

            }
            order.Total = orderTotal;

            _context.SaveChanges();

            EmptyCart();
        }
    }
}
