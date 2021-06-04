using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyStore.Data;
using MyStore.Models;
using MyStore.Models.ViewModels;
using MyStore.Utility;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace MyStore.Controllers
{
    [Authorize]
    public class ShoppingCartController : Controller
    {
        private readonly ApplicationDbContext _db;

        public ShoppingCartController(ApplicationDbContext db)
        {
            _db = db;
        }

        // GET
        public IActionResult Index()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            IEnumerable<Product> productList = 
                _db.ShoppingCart.Include(i => i.Product)
                .Where(i => i.UserId == userId)
                .Select(i => i.Product);

            return View(productList);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName(nameof(Index))]
        public IActionResult IndexPost()
        {
            return RedirectToAction(nameof(Summary));
        }

        // GET
        public IActionResult Summary()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            IEnumerable<Product> productList =
                _db.ShoppingCart.Include(i => i.Product)
                .Where(i => i.UserId == userId)
                .Select(i => i.Product);

            return View(productList);

            //UserProductVM userProductVM = new UserProductVM
            //{
            //    ApplicationUser = _db.ApplicationUsers.FirstOrDefault(i => i.Id == userId),
            //    ProductList = productList.ToList()
            //};

            //return View(userProductVM);
        }
    }
}
