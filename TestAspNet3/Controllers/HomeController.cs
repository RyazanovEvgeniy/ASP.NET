using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestAspNet3.data.interfaces;
using TestAspNet3.ViewModels;
using TestAspNet3.Views.Shared;

namespace TestAspNet3.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProducts products;

        public HomeController(IProducts productRepository) => this.products = productRepository;

        public ViewResult Index()
        {
            var homeProducts = new HomeViewModel { 
                favProducts = products.productsFavorite
            };

            return View(homeProducts);
        }
    }
}
