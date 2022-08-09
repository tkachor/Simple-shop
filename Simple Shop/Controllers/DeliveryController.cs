using Microsoft.AspNetCore.Mvc;
using Simple_Shop.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Simple_Shop.Controllers
{
    public class DeliveryController : Controller
    {
        public ViewResult Index()
        {
            var delivery = new DeliveryViewModels { };
            return View(delivery);
        }
    }
}
