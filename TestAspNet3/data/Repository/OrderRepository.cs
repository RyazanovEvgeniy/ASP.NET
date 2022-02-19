using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestAspNet3.data.interfaces;
using TestAspNet3.data.models;
using TestAspNet3.Views.models;

namespace TestAspNet3.data.Repository
{
    public class OrderRepository : IOrders
    {
        private readonly DB db;
        private readonly Cart cart;
        public OrderRepository(DB db, Cart cart)
        {
            this.db = db;
            this.cart = cart;
        }

        public void CreateOrder(Order order)
        {
            order.dateTime = DateTime.Now;
            db.order.Add(order);

            db.SaveChanges();

            var items = cart.cartItems;

            foreach (var el in items)
            {
                var orderDetail = new OrderDetail()
                {
                    orderId = order.id,
                    price = el.product.price,
                    productId = el.id
                };

                db.orderDetail.Add(orderDetail);
            }

            db.SaveChanges();
        }
    }
}
