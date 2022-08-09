using Simple_Shop.Data.Interfaces;
using Simple_Shop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Simple_Shop.Data.mocks
{
    public class MockCategory : IProductCategory
    {
        public IEnumerable<Category> AllCategory 
        {
            get
            {
                return new List<Category>
                {                    
                    new Category {CategoryName = "Перфопанелі", Description = "Перфопанелі для інструментів"},
                    new Category {CategoryName = "Комплектуючі", Description = "Комплектуючі до перфопанелей"}
                };
            }
        }       
    }
}
