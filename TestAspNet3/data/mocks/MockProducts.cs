using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestAspNet3.data.interfaces;
using TestAspNet3.data.models;

namespace TestAspNet3.data.mocks
{
    public class MockProducts : IProducts
    {
        private readonly ICategories categories = new MockCategories();

        public IEnumerable<Product> products 
        {
            get
            {
                return new List<Product>
                {
                    new Product 
                    {
                        name = "Tesla", 
                        img = "/img/tesla.jpg",
                        price = 45000, 
                        available = true, 
                        isFavorite = true, 
                        category = categories.AllCategories.First()
                    },
                    new Product
                    {
                        name = "Bmw",
                        img = "/img/bmw.jpg",
                        price = 35000,
                        available = false,
                        isFavorite = true,
                        category = categories.AllCategories.Last()
                    },
                    new Product
                    {
                        name = "Nissan",
                        img = "/img/nissan.jpg",
                        price = 35000,
                        available = false,
                        isFavorite = false,
                        category = categories.AllCategories.Last()
                    },
                    new Product
                    {
                        name = "Mercedes",
                        img = "/img/mercedes.jpg",
                        price = 15000,
                        available = true,
                        isFavorite = false,
                        category = categories.AllCategories.Last()
                    },
                };
            }
        }
        public IEnumerable<Product> productsFavorite { get; set; }

        public Product productById(int productId)
        {
            throw new NotImplementedException();
        }
    }
}
