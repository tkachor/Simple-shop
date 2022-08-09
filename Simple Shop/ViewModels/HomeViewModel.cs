using Simple_Shop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Simple_Shop.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Product> favProduct { get; set; }
    }
}
