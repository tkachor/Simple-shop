using Microsoft.AspNetCore.Mvc;
using Simple_Shop.Data.Interfaces;
using Simple_Shop.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Simple_Shop.Controllers
{
    public class HomeController : Controller
    {
        private readonly IAllProduct _prodRep;
        

        public HomeController(IAllProduct prodRep)
        {
            _prodRep = prodRep;            
        }

        public ViewResult Index()
        {
            var homeProduct = new HomeViewModel
            {
                favProduct = _prodRep.GetFavProducts
            };
            return View(homeProduct);
        }
    }
}
