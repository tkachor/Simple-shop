using Microsoft.EntityFrameworkCore;
using Simple_Shop.Data.Interfaces;
using Simple_Shop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Simple_Shop.Data.Repository 
{
    public class ProductReposirory : IAllProduct
    {
        private readonly AppDBContent appDBContent;

        public ProductReposirory(AppDBContent appDBContent)
        {
            this.appDBContent = appDBContent;
        }
        public IEnumerable<Product> Product => appDBContent.Product.Include(p => p.Category);

        public IEnumerable<Product> GetFavProducts => appDBContent.Product.Where(p => p.IsFavorite).Include(p => p.Category);

        public Product GetObjectProduct(int productId) => appDBContent.Product.FirstOrDefault(p => p.Id == productId);
        
    }
}
