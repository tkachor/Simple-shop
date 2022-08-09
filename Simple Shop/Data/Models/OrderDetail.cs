﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Simple_Shop.Data.Models
{
    public class OrderDetail
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public uint Price { get; set; }
        public virtual Product Product { get; set; }
        public virtual Order Orde { get; set; }
        
    }
}
