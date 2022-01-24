using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestAspNet3.data.models;

namespace TestAspNet3.data.interfaces
{
    interface ICategory
    {
        IEnumerable<Category> AllCategories { get; }
    }
}
