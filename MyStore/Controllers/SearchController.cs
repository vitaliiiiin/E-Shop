using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyStore.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyStore.Controllers
{
    public class SearchController : Controller
    {
        private readonly ApplicationDbContext _db;

        public SearchController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index(string searching)
        {
            return View(_db.Products.Where(i => i.Name.Contains(searching) || searching == null)
                .Include(i => i.Category)
                .Include(i => i.Manufacturer).ToList());
        }
    }
}
