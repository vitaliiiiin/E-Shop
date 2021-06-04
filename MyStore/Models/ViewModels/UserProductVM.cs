using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyStore.Models.ViewModels
{
    public class UserProductVM
    {
        public ApplicationUser ApplicationUser { get; set; }
        public IList<Product> ProductList { get; set; } = new List<Product>();
    }
}