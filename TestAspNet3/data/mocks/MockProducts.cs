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
        private readonly ICategory categories = new MockCategory();

        public IEnumerable<Product> products 
        {
            get
            {
                return new List<Product>
                {
                    new Product 
                    { 
                        name = "Tesla", 
                        price = 45000, 
                        available = true, 
                        isFavorite = true, 
                        category = categories.AllCategories.First()
                    },
                    new Product
                    {
                        name = "Ford",
                        price = 35000,
                        available = false,
                        isFavorite = true,
                        category = categories.AllCategories.Last()
                    },
                    new Product
                    {
                        name = "Nissan",
                        price = 35000,
                        available = false,
                        isFavorite = false,
                        category = categories.AllCategories.Last()
                    },
                    new Product
                    {
                        name = "Kia",
                        price = 15000,
                        available = true,
                        isFavorite = false,
                        category = categories.AllCategories.Last()
                    },
                };
            }
            set
            {

            }
        }
        public IEnumerable<Product> productsFavorite { get; set; }

        public Product productById(int productId)
        {
            throw new NotImplementedException();
        }
    }
}
