using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyStore.Data;
using MyStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyStore.Controllers
{
    [Authorize(Roles = WebConstants.AdminRole)]
    public class ManufacturerController : Controller
    {
        private readonly ApplicationDbContext _db;

        public ManufacturerController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Manufacturer> manufacturerList = _db.Manufacturers;

            return View(manufacturerList);
        }

        // GET - CREATE
        public IActionResult Create()
        {
            return View();
        }

        // POST - CREATE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Manufacturer obj)
        {
            _db.Manufacturers.Add(obj);
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

            var obj = _db.Manufacturers.Find(id);

            if (obj is null)
            {
                return NotFound();
            }

            return View(obj);
        }

        // POST - EDIT
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Manufacturer obj)
        {
            _db.Manufacturers.Update(obj);
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

            var obj = _db.Manufacturers.Find(id);

            if (obj is null)
            {
                return NotFound();
            }

            return View(obj);
        }

        // POST - DELETE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Manufacturer obj)
        {
            _db.Manufacturers.Remove(obj);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
