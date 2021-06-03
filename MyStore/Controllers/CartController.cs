using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
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
    public class CartController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IEmailSender _emailSender;

        [BindProperty]
        public UserProductVM UserProductVM { get; set; }
        public CartController(ApplicationDbContext db, IWebHostEnvironment webHostEnvironment, IEmailSender emailSender)
        {
            _db = db;
            _webHostEnvironment = webHostEnvironment;
            _emailSender = emailSender;
        }
        
        // GET
        public IActionResult Index()
        {
            var shoppingCartList = new List<ShoppingCart>();

            if (HttpContext.Session.Get<IEnumerable<ShoppingCart>>(WebConstants.SessionCart) != null
                && HttpContext.Session.Get<IEnumerable<ShoppingCart>>(WebConstants.SessionCart).Count() > 0)
            {
                // session exists
                shoppingCartList = HttpContext.Session.Get<List<ShoppingCart>>(WebConstants.SessionCart);
            }

            var prodInCart = shoppingCartList.Select(i => i.ProductId).ToList();
            var prodList = _db.Products.Where(i => prodInCart.Contains(i.Id));

            return View(prodList);
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

            var shoppingCartList = new List<ShoppingCart>();

            if (HttpContext.Session.Get<IEnumerable<ShoppingCart>>(WebConstants.SessionCart) != null
                && HttpContext.Session.Get<IEnumerable<ShoppingCart>>(WebConstants.SessionCart).Count() > 0)
            {
                // session exists
                shoppingCartList = HttpContext.Session.Get<List<ShoppingCart>>(WebConstants.SessionCart);
            }

            var prodInCart = shoppingCartList.Select(i => i.ProductId).ToList();
            var prodList = _db.Products.Where(i => prodInCart.Contains(i.Id));

            UserProductVM = new UserProductVM
            {
                ApplicationUser = _db.ApplicationUsers.FirstOrDefault(i => i.Id == userId),
                ProductList = prodList.ToList()
            };

            return View(UserProductVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Summary")]
        public async Task<IActionResult> SummaryPost(UserProductVM userProductVM)
        {
            var pathToAdminLetter = _webHostEnvironment.WebRootPath + "/templates/newOrderToAdmin.html";

            var adminLetterSubject = "New Inquiry";
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

            await _emailSender.SendEmailAsync(UserProductVM.ApplicationUser.Email, customerLetterSubject, customerMessageBody);

            return RedirectToAction(nameof(OrderConfirmation));
        }

        public IActionResult OrderConfirmation()
        {
            HttpContext.Session.Clear();

            return View();
        }

        public IActionResult RemoveFromCart(int id)
        {
            var shoppingCartList = new List<ShoppingCart>();

            if (HttpContext.Session.Get<IEnumerable<ShoppingCart>>(WebConstants.SessionCart) != null
               && HttpContext.Session.Get<IEnumerable<ShoppingCart>>(WebConstants.SessionCart).Count() > 0)
            {
                // session exists
                shoppingCartList = HttpContext.Session.Get<List<ShoppingCart>>(WebConstants.SessionCart);
            }

            shoppingCartList.Remove(shoppingCartList.FirstOrDefault(i => i.ProductId == id));
            HttpContext.Session.Set(WebConstants.SessionCart, shoppingCartList);

            return RedirectToAction(nameof(Index));
        }
    }
}
