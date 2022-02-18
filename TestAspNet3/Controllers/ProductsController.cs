using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestAspNet3.data.interfaces;
using TestAspNet3.data.models;
using TestAspNet3.ViewModels;

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

        [Route("Products/List")]
        [Route("Products/List/{category}")]
        public ViewResult List(string category)
        {
            ViewBag.Title = "ProductsView";
            ProductsListViewModel carsListViewModel = new ProductsListViewModel();

            if (string.IsNullOrEmpty(category))
            {
                carsListViewModel.products = products.products;
                carsListViewModel.currentCategory = "Автомобили";
            }
            else
            {
                if (string.Equals(category, "electro", StringComparison.OrdinalIgnoreCase))
                {
                    carsListViewModel.products = products.products
                        .Where(i => i.category.name.Equals("Электромобили"));
                    carsListViewModel.currentCategory = "Электромобили";
                }
                if (string.Equals(category, "fuel", StringComparison.OrdinalIgnoreCase))
                {
                    carsListViewModel.products = products.products
                        .Where(i => i.category.name.Equals("Классические автомобили"));
                    carsListViewModel.currentCategory = "Классические автомобили";
                }
            }

            return View(carsListViewModel);
        }
    }
}
