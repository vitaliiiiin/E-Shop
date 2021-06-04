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
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IEmailSender _emailSender;

        public ShoppingCartController(ApplicationDbContext db, IWebHostEnvironment webHostEnvironment, IEmailSender emailSender)
        {
            _db = db;
            _webHostEnvironment = webHostEnvironment;
            _emailSender = emailSender;
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

            var productList =
                _db.ShoppingCart.Include(i => i.Product)
                .Where(i => i.UserId == userId)
                .Select(i => i.Product).ToList();

            UserProductVM userProductVM = new UserProductVM
            {
                ApplicationUser = _db.ApplicationUsers.FirstOrDefault(i => i.Id == userId),
                ProductList = productList
            };

            return View(userProductVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Summary")]
        public async Task<IActionResult> SummaryPost(UserProductVM userProductVM)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            foreach (var product in userProductVM.ProductList)
            {
                // Add Order To History
                _db.OrderHistory.Add(new OrderHistory
                {
                    UserId = userId,
                    ProductId = product.Id,
                    OrderDateTime = DateTime.Now
                });

                // Romove Products from Cart
                _db.ShoppingCart.Remove(_db.ShoppingCart.Single(i => i.UserId == userId && i.ProductId == product.Id));
            }
            _db.SaveChanges();

            // Send Order Info To Admin's Email
            var pathToAdminLetter = _webHostEnvironment.WebRootPath + "/templates/newOrderToAdmin.html";

            var adminLetterSubject = "New Order";
            string adminLetterHtmlBody = string.Empty;
            using (StreamReader sr = System.IO.File.OpenText(pathToAdminLetter))
            {
                adminLetterHtmlBody = sr.ReadToEnd();
            }
            //Name: {0}
            //Email: {1}
            //Phone: {2}
            //Products: {3}

            var productListSB = new StringBuilder();
            foreach (var prod in userProductVM.ProductList)
            {
                productListSB.Append($" - { prod.Name} <span style='font-size:14px;'> (ID: {prod.Id})</span><br />");
            }

            string adminMessageBody = string.Format(adminLetterHtmlBody,
                userProductVM.ApplicationUser.FullName,
                userProductVM.ApplicationUser.Email,
                userProductVM.ApplicationUser.PhoneNumber,
                productListSB.ToString());

            await _emailSender.SendEmailAsync(WebConstants.EmailAdmin, adminLetterSubject, adminMessageBody);

            // Send Order Info To Customer's Email
            var pathToCustomerLetter = _webHostEnvironment.WebRootPath + "/templates/orderInfoToCustomer.html";

            var customerLetterSubject = "Order Details";
            string customerLetterHtmlBody = string.Empty;
            using (StreamReader sr = System.IO.File.OpenText(pathToCustomerLetter))
            {
                adminLetterHtmlBody = sr.ReadToEnd();
            }
            //Name: {0}
            //Phone: {1}
            //Products: {2}

            string customerMessageBody = string.Format(adminLetterHtmlBody,
                userProductVM.ApplicationUser.FullName,
                userProductVM.ApplicationUser.PhoneNumber,
                productListSB.ToString());

            await _emailSender.SendEmailAsync(userProductVM.ApplicationUser.Email, customerLetterSubject, customerMessageBody);

            return RedirectToAction(nameof(OrderConfirmation));
        }

        public IActionResult OrderConfirmation()
        {
            return View();
        }
    }
}
