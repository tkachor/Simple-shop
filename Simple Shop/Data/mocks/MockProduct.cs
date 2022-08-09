using Simple_Shop.Data.Interfaces;
using Simple_Shop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Simple_Shop.Data.mocks
{
    public class MockProduct : IAllProduct
    {
        private IProductCategory categoryProduct = new MockCategory();
        public IEnumerable<Product> Product
        {
            get
            {
                return new List<Product>
                {
                    new Product{ 
                        Name = "Панель для інструментів PF10",
                        ShortDesc = "Перфорированная панель для хранения ручного инструмента — это интересное решение для упорядочивания разного вида инструмента ", 
                        LongDesc = "Перфорированная панель для хранения ручного инструмента — это интересное решение для упорядочивания разного вида инструмента в одном месте. Стена мастерской - это основной способ организации рабочего места. Вы сможете не тратить время на поиски нужных приборов. И наконец-то Вы не будете спотыкаться через ящик с инструментами лежащий на полу.", 
                        Img= "/img/pf10.jpg", 
                        Price = 980 ,
                        IsFavorite = true  , 
                        Avaible = true , 
                        Category =categoryProduct.AllCategory.First() },

                    new Product{
                        Name = "Панель для інструментів PF20",
                        ShortDesc = "Перфорированная панель для хранения ручного инструмента — это интересное решение для упорядочивания разного вида инструмента ",
                        LongDesc = "Перфорированная панель для хранения ручного инструмента — это интересное решение для упорядочивания разного вида инструмента в одном месте. Стена мастерской - это основной способ организации рабочего места. Вы сможете не тратить время на поиски нужных приборов. И наконец-то Вы не будете спотыкаться через ящик с инструментами лежащий на полу.",
                        Img= "/img/pf20.jpg",
                        Price = 980 ,
                        IsFavorite = true  ,
                        Avaible = true ,
                        Category = categoryProduct.AllCategory.First() }
                };

            } 
         }
        public IEnumerable<Product> GetFavProducts { get; set; }

        public Product GetObjectProduct(int productId)
        {
            throw new NotImplementedException();
        }
    }
}
