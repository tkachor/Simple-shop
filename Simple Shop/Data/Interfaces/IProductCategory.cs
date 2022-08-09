using Simple_Shop.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Threading.Tasks;

namespace Simple_Shop.Data.Interfaces
{
    public interface IProductCategory
    {
        IEnumerable<Category> AllCategory { get; }
    }
}
