using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyStore.Models.ViewModels
{
    public class ProductVM
    {
        public ProductVM()
        {
            Product = new Product();
        }
        public Product Product { get; set; }
        public IEnumerable<SelectListItem> DropDownCategories { get; set; }
        public IEnumerable<SelectListItem> DropDownManufacturers { get; set; }
    }
}