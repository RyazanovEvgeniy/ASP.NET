using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestAspNet3.data.models;

namespace TestAspNet3.data.interfaces
{
    public interface IProducts
    {
        IEnumerable<Product> products { get; }
        IEnumerable<Product> productsFavorite { get; set; }
        Product productById(int productId);
    }
}
