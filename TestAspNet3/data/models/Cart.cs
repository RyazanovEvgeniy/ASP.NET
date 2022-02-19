using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestAspNet3.data;
using TestAspNet3.data.models;

namespace TestAspNet3.Views.models
{
    public class Cart
    {
        private readonly DB db;
        public Cart(DB db) => this.db = db;

        public string id { get; set; }
        public List<CartItem>  cartItems { get; set; }
         
        public static Cart GetCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            string cartId = session.GetString("cartId") ?? Guid.NewGuid().ToString();
            session.SetString("cartId", cartId);

            var context = services.GetRequiredService<DB>();

            return new Cart(context) { id = cartId };
        }

        public void addToCart(Product product)
        {
            db.cartItem.Add(new CartItem
            {
                itemCartId = id,
                product = product,
                price = product.price
            }) ;

            db.SaveChanges();
        }

        public List<CartItem> getCartItems()
        {
            return db.cartItem.Where(c => c.itemCartId == id).Include(s => s.product).ToList();
        }
    }
}
