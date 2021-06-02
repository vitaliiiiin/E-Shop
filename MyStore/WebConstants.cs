﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyStore
{
    public static class WebConstants
    {
        public static string ImagePath { get; } = @"\images\product\";
        public static string SessionCart { get; } = "ShoppingCartSession";

        public static string AdminRole { get; } = "Admin";
        public static string CustomerRole { get; } = "Customer";
    }
}
