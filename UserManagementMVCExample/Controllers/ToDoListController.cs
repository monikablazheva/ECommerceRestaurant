using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using UserManagementMVCExample.Data;
using UserManagementMVCExample.Enums;
using UserManagementMVCExample.Models;

namespace UserManagementMVCExample.Controllers
{
    [Authorize(Roles = "SuperAdmin, Admin, Moderator")]
    public class ToDoListController : Controller
    {
        private readonly ApplicationDbContext _context;
        public ToDoListController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Orders.Include(o => o.Customer).Include(o => o.OrdersItems).ThenInclude(i => i.Product).ToListAsync());
        }

        public async Task<IActionResult> UpdateStatus(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var orderFromDb = await _context.Orders.FirstOrDefaultAsync(o => o.Id == id);
            if(orderFromDb == null)
            {
                return NotFound();
            }

            orderFromDb.OrderStatus = Enums.OrdersStatus.Shipped;
            _context.Update(orderFromDb);
            await _context.SaveChangesAsync();
            return Json(new { updatedStatusId = id });
        }
    }
}
