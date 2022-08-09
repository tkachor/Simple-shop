using Microsoft.AspNetCore.Mvc;
using Simple_Shop.Data.Interfaces;
using Simple_Shop.Data.Models;
using Simple_Shop.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Simple_Shop.Controllers
{
    public class ProductController : Controller
    {
        private readonly IAllProduct allProduct;
        private readonly IProductCategory productCategory;

        public ProductController(IAllProduct iallProduct, IProductCategory iproductCategory)
        {
            allProduct = iallProduct;
            productCategory = iproductCategory;
        }

        [Route("Product/List")]
        [Route("Product/List/{category}")]
        public ViewResult ListProduct(string category)
        {
            string _category = category;
            IEnumerable<Product> product = null;
            string currCategory = "";

            if (string.IsNullOrEmpty(category))
            {
                product = allProduct.Product.OrderBy(i => i.Id);
            }
            else
            {
                if(string.Equals("perfopanely", category, StringComparison.OrdinalIgnoreCase))
                {
                    product = allProduct.Product.Where(p => p.Category.CategoryName.Equals("Перфопанелі")).OrderBy(p => p.Id);
                    currCategory = "Перфопанелі";
                }
                else if (string.Equals("komplectuyuchi", category, StringComparison.OrdinalIgnoreCase))
                {
                    product = allProduct.Product.Where(p => p.Category.CategoryName.Equals("Комплектуючі")).OrderBy(p => p.Id);
                    currCategory = "Комплектуючі";
                }                         
            }

            var pruductObj = new ProdutListViewModel
            {
               AllProduct = product,
               ProductCategory = currCategory
            };

            ViewBag.Title = "Сторінка з товарами";                      
            return View(pruductObj);
        }
    }
}
