﻿using Braintree;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using UserManagementMVCExample.Data;
using UserManagementMVCExample.Enums;
using UserManagementMVCExample.Interfaces;
using UserManagementMVCExample.Models;
using UserManagementMVCExample.Services;

namespace UserManagementMVCExample.Controllers
{
    [Authorize(Roles = "SuperAdmin, Admin, Basic, Moderator")]
    public class OrderController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly CartService shoppingCart;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private IBrainTree _brainTree { get; set; }

        public OrderController(ApplicationDbContext context, CartService shoppingCart, UserManager<ApplicationUser> userManager, IBrainTree brainTree, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            this.shoppingCart = shoppingCart;
            this._userManager = userManager;
            _brainTree = brainTree;
            _httpContextAccessor = httpContextAccessor;
        }
        public ApplicationUser GetCustomer()
        {
            ClaimsPrincipal currentUser = this.User;
            var currentUserId = currentUser.FindFirst(ClaimTypes.NameIdentifier).Value;
            var user = _userManager.Users.Include(u => u.CompletedOrders).FirstOrDefault(u => u.Id == currentUserId);
            return user;
        }

        public async Task<IActionResult> Index()
        {
            var user = GetCustomer();
            return View(await _context.Orders.Include(o => o.Customer).Include(o=>o.OrdersItems).ThenInclude(i=>i.Product)
                        .Where(o => o.Customer == user).ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Orders == null)
            {
                return NotFound();
            }
            var order = await _context.Orders.Include(o => o.Customer).Include(o => o.OrdersItems).ThenInclude(i => i.Product).FirstOrDefaultAsync(o => o.Id == id);
            if (order == null)
            {
                return NotFound();
            }
            return View(order);
        }

        public IActionResult Payment()
        {
            var gateway = _brainTree.GetGateway();
            var clientToken = gateway.ClientToken.Generate();

            ViewBag.ClientToken = clientToken;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Payment(IFormCollection formCollection, 
                            [Bind("Id,DeliveryAdress,DeliveryTime")] Order order)
        {
            if (ModelState.IsValid)
            {
                order.Customer = this.GetCustomer();
                order.Date = DateTime.Now;

                _context.Orders.Add(order);
                await _context.SaveChangesAsync();

                var total = shoppingCart.GetTotal();
                string nonceFromTheClient = formCollection["payment_method_nonce"];
                var request = new TransactionRequest
                {
                    Amount = total,
                    PaymentMethodNonce = nonceFromTheClient,
                    OrderId = order.Id.ToString(),
                    Options = new TransactionOptionsRequest
                    {
                        SubmitForSettlement = true
                    }
                };

                var gateway = _brainTree.GetGateway();
                Result<Transaction> result = gateway.Transaction.Sale(request);

                if (result.Target.ProcessorResponseText == "Approved")
                {
                    order.IsPaid = true;
                    order.OrderStatus = OrdersStatus.Confirmed;

                    shoppingCart.CreateOrder(order);

                    _context.Update(order);
                    await _context.SaveChangesAsync();

                    return RedirectToAction("Details", new { id = order.Id });
                }
                else
                {
                    order.OrderStatus = OrdersStatus.Cancelled;
                    TempData["Unsuccessful"] = "Transaction was unsuccessful. Please try again";
                    return RedirectToAction("Payment", new { orderId = order.Id });
                }
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> DeleteOrder(int orderId)
        {
            if (_context.Orders == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Order'  is null.");
            }
            var order = await _context.Orders.FindAsync(orderId);
            if (order != null)
            {
                _context.Orders.Remove(order);
            }

            await _context.SaveChangesAsync();
            return Json(new { DeleteId = orderId });
        }
    }
}
