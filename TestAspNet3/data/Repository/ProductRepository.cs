using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestAspNet3.data.interfaces;
using TestAspNet3.data.models;

namespace TestAspNet3.data.Repository
{
    public class ProductRepository : IProducts
    {
        private readonly DB db;

        public ProductRepository(DB db) => this.db = db;

        public IEnumerable<Product> products => db.product.Include(c => c.category);

        public IEnumerable<Product> productsFavorite { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public Product productById(int productId)
        {
            throw new NotImplementedException();
        }
    }
}
