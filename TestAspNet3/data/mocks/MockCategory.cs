using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestAspNet3.data.interfaces;
using TestAspNet3.data.models;

namespace TestAspNet3.data.mocks
{
    public class MockCategory : ICategory
    {
        public IEnumerable<Category> AllCategories
        {
            get
            {
                return new List<Category>
                {
                    new Category { name = "Электромобили", description = "Современный вид транспорта" },
                    new Category { name = "Классические автомобили", description = "Машины с двигателем внутреннего сгорания" }
                };
            }
        }
    }
}
