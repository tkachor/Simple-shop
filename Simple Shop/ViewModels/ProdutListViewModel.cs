using Simple_Shop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Simple_Shop.ViewModels
{
    public class ProdutListViewModel
    {
        public IEnumerable<Product> AllProduct { get; set; }
        public string ProductCategory { get; set; }
        
    }
}
