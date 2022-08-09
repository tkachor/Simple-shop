using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Simple_Shop.Data.Models
{
    public class ShopCart
    {        

        private readonly AppDBContent appDBContent;

        public ShopCart(AppDBContent appDBContent)
        {
            this.appDBContent = appDBContent;
        }
        public string ShopCartId { get; set; }

        public List<CartItem> listShopItem { get; set; }

        public static ShopCart GetCart(IServiceProvider services)
        {
            ISession sesion = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            var context = services.GetService<AppDBContent>();
            string shopCartId = sesion.GetString("CartId") ?? Guid.NewGuid().ToString();
            sesion.SetString("CartId", shopCartId);
            return new ShopCart(context) { ShopCartId = shopCartId };
        }

        public void AddToCart(Product product)
        {
            appDBContent.CartItems.Add(new CartItem
            {
                ShopCartId = ShopCartId,
                product = product,
                Price = product.Price
            });
            appDBContent.SaveChanges();
        }

        public List<CartItem> getShopItem()
        {
            return appDBContent.CartItems.Where(p => p.ShopCartId == ShopCartId).Include(s => s.product).ToList();
        }
    }
}
