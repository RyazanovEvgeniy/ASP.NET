using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestAspNet3.data.interfaces;
using TestAspNet3.data.models;
using TestAspNet3.Views.models;

namespace TestAspNet3.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrders orders;
        private readonly Cart cart;

        public OrderController(IOrders orders, Cart cart)
        {
            this.orders = orders;
            this.cart = cart;
        }

        public IActionResult CheckOut() => View();

        [HttpPost]
        public IActionResult CheckOut(Order order)
        {
            cart.cartItems = cart.getCartItems();

            if (cart.cartItems.Count == 0)
                ModelState.AddModelError("", "Корзина пуста");

            if (ModelState.IsValid)
            {
                orders.CreateOrder(order);
                return RedirectToAction("Complete");
            }

            return View();
        }

        public IActionResult Complete()
        {
            ViewBag.Message = "Заказ успешно обработан";
            return View();
        }
    }
}
