using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyStore.Data;
using MyStore.Models;
using MyStore.Models.ViewModels;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MyStore.Controllers
{
    [Authorize(Roles = WebConstants.AdminRole)]
    public class ProductController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ProductController(ApplicationDbContext db, IWebHostEnvironment webHostEnvironment)
        {
            _db = db;
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        {
            IEnumerable<Product> productList = _db.Products.Include(i => i.Category).Include(i => i.Manufacturer);

            return View(productList);
        }

        // GET - UPSERT
        public IActionResult Upsert(int? id) // if id is not null, so an item is to edit
        {                                    // otherwise - to create
            ProductVM productVM = new ProductVM()
            {
                DropDownCategories = _db.Categories.Select(c =>
                new SelectListItem
                {
                    Text = c.Name,
                    Value = c.Id.ToString()
                }),
                DropDownManufacturers = _db.Manufacturers.Select(c =>
                new SelectListItem
                {
                    Text = c.Name,
                    Value = c.Id.ToString()
                })
            };

            if (id is null)
            {
                return View(productVM); // this is for create
            }

            productVM.Product = _db.Products.Find(id);

            if (productVM.Product is null)
            {
                return NotFound();
            }

            return View(productVM); // this is for edit
        }

        // POST - UPSERT
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(ProductVM productVM)
        {
            if (ModelState.IsValid)
            {
                var images = HttpContext.Request.Form.Files;
                string webRootPath = _webHostEnvironment.WebRootPath;

                if (productVM.Product.Id == 0) // create
                {
                    string uploadPath = webRootPath + WebConstants.ImagePath;
                    string imageName = Guid.NewGuid().ToString();
                    string imageExtention = Path.GetExtension(images[0].FileName);
                    string fullImageName = imageName + imageExtention;

                    using (var fileStream = new FileStream(Path.Combine(uploadPath, fullImageName), FileMode.Create))
                    {
                        images[0].CopyTo(fileStream);
                    }

                    productVM.Product.Image = fullImageName;

                    _db.Products.Add(productVM.Product);
                }
                else // update
                {
                    var objFromDb = _db.Products.AsNoTracking().FirstOrDefault(i => i.Id == productVM.Product.Id);

                    if (images.Count > 0) // if a new photo was added
                    {
                        string uploadPath = webRootPath + WebConstants.ImagePath;
                        string imageName = Guid.NewGuid().ToString();
                        string imageExtention = Path.GetExtension(images[0].FileName);
                        string fullImageName = imageName + imageExtention;

                        var oldImagePath = Path.Combine(uploadPath, objFromDb.Image);

                        if (System.IO.File.Exists(oldImagePath))
                        {
                            System.IO.File.Delete(oldImagePath);
                        }

                        using (var fileStream = new FileStream(Path.Combine(uploadPath, fullImageName), FileMode.Create))
                        {
                            images[0].CopyTo(fileStream);
                        }

                        productVM.Product.Image = fullImageName;
                    }
                    else
                    {
                        productVM.Product.Image = objFromDb.Image;
                    }

                    _db.Products.Update(productVM.Product);
                }

                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            productVM.DropDownCategories = _db.Categories.Select(c =>
                new SelectListItem
                {
                    Text = c.Name,
                    Value = c.Id.ToString()
                });
            productVM.DropDownManufacturers = _db.Manufacturers.Select(c =>
                new SelectListItem
                {
                    Text = c.Name,
                    Value = c.Id.ToString()
                });

            return View(productVM);
        }

        // GET - DELETE
        public IActionResult Delete(int? id)
        {
            if (id is null || id == 0)
            {
                return NotFound();
            }

            var product = _db.Products.Include(i => i.Category).Include(i => i.Manufacturer).FirstOrDefault(i => i.Id == id);

            if (product is null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST - DELETE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Product product)
        {
            var objFromDb = _db.Products.Find(product.Id);
            
            string webRootPath = _webHostEnvironment.WebRootPath;
            string uploadPath = webRootPath + WebConstants.ImagePath;

            var fullImagePath = Path.Combine(uploadPath, objFromDb.Image);

            if (System.IO.File.Exists(fullImagePath))
            {
                System.IO.File.Delete(fullImagePath);
            }

            _db.Products.Remove(objFromDb);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
