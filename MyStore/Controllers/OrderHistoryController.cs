using MyStore.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyStore.Data;
using MyStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MyStore.Controllers
{
    [Authorize]
    public class OrderHistoryController : Controller
    {
        private readonly ApplicationDbContext _db;

        public OrderHistoryController(ApplicationDbContext db)
        {
            _db = db;
        }

        // GET
        public IActionResult Index()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var orderHistoryVM = new OrderHistoryVM
            {
                ApplicationUser = _db.ApplicationUsers.FirstOrDefault(i => i.Id == userId)
            };
            
            orderHistoryVM.ProductDateTimePairList = _db.OrderHistory
                .Include(i => i.Product)
                .Where(i => i.UserId == userId)
                .Select(i => new KeyValuePair<Product, DateTime>(i.Product, i.OrderDateTime)).ToList()
                .OrderBy(i => i.Value).ToList();

            return View(orderHistoryVM);
        }
    }
}
