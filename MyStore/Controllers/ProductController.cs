using Microsoft.AspNetCore.Mvc;
using MyStore.Data;
using MyStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyStore.Controllers
{
    public class ProductController : Controller
    {
        private readonly ApplicationDbContext _db;

        public ProductController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Product> objList = _db.Products;

            foreach (var obj in objList)
            {
                obj.Category = _db.Categories.FirstOrDefault(x => x.Id == obj.Category.Id);
            }

            return View(objList);
        }

        // GET - CREATE
        public IActionResult Create()
        {
            return View();
        }

        // POST - CREATE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Product obj)
        {
            _db.Products.Add(obj);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }

        // GET - EDIT
        public IActionResult Edit(int? id)
        {
            if (id is null || id == 0)
            {
                return NotFound();
            }

            var obj = _db.Products.Find(id);

            if (obj is null)
            {
                return NotFound();
            }

            return View(obj);
        }

        // POST - EDIT
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(Product obj)
        {
            _db.Products.Update(obj);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }

        // GET - DELETE
        public IActionResult Delete(int? id)
        {
            if (id is null || id == 0)
            {
                return NotFound();
            }

            var obj = _db.Products.Find(id);

            if (obj is null)
            {
                return NotFound();
            }

            return View(obj);
        }

        // POST - DELETE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Product obj)
        {
            _db.Products.Remove(obj);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
