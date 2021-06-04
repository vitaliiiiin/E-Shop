using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyStore.Models.ViewModels
{
    public class OrderHistoryVM
    {
        public ApplicationUser ApplicationUser { get; set; }

        public List<KeyValuePair<Product, DateTime>> ProductDateTimePairList { get; set; } = 
            new List<KeyValuePair<Product, DateTime>>();

    }
}
