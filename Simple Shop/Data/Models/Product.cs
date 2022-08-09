using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Simple_Shop.Data.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ShortDesc { get; set; }
        public string LongDesc { get; set; }
        public string Img { get; set; }
        public ushort Price { get; set; }
        public bool IsFavorite { get; set; }
        public bool Avaible { get; set; }
        public int CtegoryId { get; set; }
        public virtual Category Category { get; set; }      
      
    }
}
