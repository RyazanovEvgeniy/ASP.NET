using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestAspNet3.data.models;

namespace TestAspNet3.data
{
    public class DbObjects
    {
        public static void Initial(DB db)
        {
            if (!db.category.Any())
                db.category.AddRange(Categories.Select(c => c.Value));

            if (!db.product.Any())
            {
                db.product.AddRange(
                    new Product
                    {
                        name = "Tesla",
                        img = "/img/tesla.jpg",
                        price = 45000,
                        available = true,
                        isFavorite = true,
                        category = Categories["Электромобили"]
                    },
                    new Product
                    {
                        name = "Bmw",
                        img = "/img/bmw.jpg",
                        price = 35000,
                        available = false,
                        isFavorite = true,
                        category = Categories["Классические автомобили"]
                    },
                    new Product
                    {
                        name = "Nissan",
                        img = "/img/nissan.jpg",
                        price = 35000,
                        available = false,
                        isFavorite = false,
                        category = Categories["Классические автомобили"]
                    },
                    new Product
                    {
                        name = "Mercedes",
                        img = "/img/mercedes.jpg",
                        price = 15000,
                        available = true,
                        isFavorite = false,
                        category = Categories["Классические автомобили"]
                    }
                );
            }

            db.SaveChanges();
        }

        private static Dictionary<string, Category> category;

        public static Dictionary<string, Category> Categories
        {
            get
            {
                if (category == null)
                {
                    var list = new Category[]
                    {
                        new Category { name = "Электромобили", description = "Современный вид транспорта" },
                        new Category { name = "Классические автомобили", description = "Машины с двигателем внутреннего сгорания" }
                    };

                    category = new Dictionary<string, Category>();
                    foreach (var item in list)
                        category.Add(item.name, item);
                }

                return category;
            }
        }
    }

}
