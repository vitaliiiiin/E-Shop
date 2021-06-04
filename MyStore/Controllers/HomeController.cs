using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MyStore.Data;
using MyStore.Models;
using MyStore.Models.ViewModels;
using MyStore.Utility;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MyStore.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _db;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext db)
        {
            _logger = logger;
            _db = db;
        }

        public IActionResult Index()
        {
            HomeVM homeVM = new HomeVM
            {
                Products = _db.Products.Include(i => i.Category).Include(i => i.Manufacturer),
                Categories = _db.Categories
            };

            return View(homeVM);
        }

        // GET
        public IActionResult Details(int id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            // if userId is null so user is not logged in
            // it will says 'add to cart' in order to make
            // user register his account

            var detailsVM = new DetailsVM()
            {
                Product = _db.Products.Include(i => i.Category).Include(i => i.Manufacturer)
                .FirstOrDefault(i => i.Id == id),
                IsInCart = _db.ShoppingCart.Any(i => i.UserId == userId && i.ProductId == id)
            };

            return View(detailsVM);
        }

        // POST - add to shopping cart
        [Authorize]
        [HttpPost, ActionName("Details")]
        public IActionResult DetailsPost(int id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var productToAdd = _db.Products.FirstOrDefault(i => i.Id == id);

            var itemToAdd = new ShoppingCart
            {
                UserId = userId,
                ProductId = productToAdd.Id
            };

            if (!_db.ShoppingCart.Contains(itemToAdd))
            {
                _db.ShoppingCart.Add(itemToAdd);
                _db.SaveChanges();
            }

            return RedirectToAction(nameof(Index));
        }

        public IActionResult RemoveFromCart(int id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var productToRemove = _db.ShoppingCart.FirstOrDefault(i => i.UserId == userId && i.ProductId == id);

            if (productToRemove != null)
            {
                _db.ShoppingCart.Remove(productToRemove);
            }
            _db.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
