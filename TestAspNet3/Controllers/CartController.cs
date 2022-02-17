using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestAspNet3.data.interfaces;
using TestAspNet3.data.Repository;
using TestAspNet3.ViewModels;
using TestAspNet3.Views.Shared;

namespace TestAspNet3.Controllers
{
    public class CartController : Controller
    {
        private readonly IProducts products;
        private readonly Cart cart;

        public CartController(IProducts productRepository, Cart cart)
        {
            this.products = productRepository;
            this.cart = cart;
        }

        public ViewResult Index()
        {
            var items = cart.getCartItems();
            cart.cartItems = items;

            var obj = new CartViewModel { cart = cart };

            return View(obj);
        }

        public RedirectToActionResult addToCart(int id)
        {
            var item = products.products.FirstOrDefault(i => i.id == id);

            if (item != null)
                cart.addToCart(item);

            return RedirectToAction("Index");
        }
    }
}
