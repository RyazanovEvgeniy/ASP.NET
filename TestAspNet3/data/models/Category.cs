using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestAspNet3.data.models
{
    public class Category
    {
        public int id { set; get; }
        public string name { set; get; }
        public string description { set; get; }
        public List<Product> products { set; get; }
    }
}
