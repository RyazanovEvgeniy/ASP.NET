using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestAspNet3.data.models;

namespace TestAspNet3.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Product> favProducts { get; set; }
    }
}
