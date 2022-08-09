using Simple_Shop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Simple_Shop.Data.Interfaces
{
    public interface IAllProduct
    {
        IEnumerable<Product> Product { get; }
        IEnumerable<Product> GetFavProducts { get;  }
        Product GetObjectProduct(int productId);
    }

}
