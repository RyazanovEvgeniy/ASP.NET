using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestAspNet3.data.interfaces;
using TestAspNet3.data.models;

namespace TestAspNet3.data.Repository
{
    public class CategoryRepository : ICategories
    {
        private readonly DB db;

        public CategoryRepository(DB db) => this.db = db;

        public IEnumerable<Category> AllCategories => db.category;
    }
}
