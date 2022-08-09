﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Simple_Shop.Data.Models
{
    public class CartItem
    {
        public int Id { get; set; }
        public Product product { get; set; }
        public int Price { get; set; }
        public string ShopCartId { get; set; }

    }
}
