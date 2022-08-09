using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Simple_Shop.Data.Interfaces;
using Simple_Shop.Data.Models;
using Simple_Shop.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Simple_Shop.Controllers
{
    public class ShopCartController : Controller
    {
        private readonly IAllProduct _prodRep;
        private readonly ShopCart _shopCart;
        

        public ShopCartController(IAllProduct prodRep, ShopCart shopCart)
        {
            _prodRep = prodRep;
            _shopCart = shopCart;
        }
        public ViewResult Index()
        {
            var item = _shopCart.getShopItem();
            _shopCart.listShopItem = item;

            var obj = new ShopProductViewModel
            {
                shopCart = _shopCart
            };

            return View(obj);
        }

        public RedirectToActionResult AddToCart(int id)
        {
            var item = _prodRep.Product.FirstOrDefault(i => i.Id == id);
            if (item != null)
            {
                _shopCart.AddToCart(item);
            }
            return RedirectToAction("Index");
                
        }

        
    }
}
