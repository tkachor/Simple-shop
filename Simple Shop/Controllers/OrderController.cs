using Microsoft.AspNetCore.Mvc;
using Simple_Shop.Data;
using Simple_Shop.Data.Interfaces;
using Simple_Shop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Simple_Shop.Controllers
{
    public class OrderController : Controller
    {
        private readonly IAllOrders allOrders;
        private readonly ShopCart shopCart;
        public OrderController(IAllOrders allOrders, ShopCart shopCart)
        {
            this.allOrders = allOrders;
            this.shopCart = shopCart;
        }

        public IActionResult Checkout()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Checkout(Order order)
        {
            shopCart.listShopItem = shopCart.getShopItem();
            if (shopCart.listShopItem.Count == 0)
            {
                ModelState.AddModelError("", "Корзина пуста, потрібно дбавити товари");
            }

            if (ModelState.IsValid)
            {
                allOrders.createOrder(order);
                return RedirectToAction("Complete");
            }
            return View(order);
        }

        public IActionResult Complete()
        {
            ViewBag.Message = "Замовлення успішно відправлено. Найближчим часом вами зателефонє наш менеджер";
            return View();
        }
    }
}
