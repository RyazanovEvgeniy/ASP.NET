using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestAspNet3.data.interfaces;

namespace TestAspNet3.data.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProducts products;
        private readonly ICategories categories;
         
        public ProductsController(IProducts products, ICategories categories)
        {
            this.products = products;
            this.categories = categories;
        }

        public ViewResult ProductsView()
        {
            return View(products.products);
        }
    }
}
