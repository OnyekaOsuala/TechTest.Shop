using System.Collections.Generic;
using System.Linq;
using TechTest.Shop.Models;

namespace TechTest.Shop.Repository
{
    public class ProductRepository : IRepository<Product>
    {
        private readonly List<Product> products;

        /// <summary>
        /// Initialise products since we dont have a real data source
        /// </summary>
        public ProductRepository()
        {
            products = new List<Product> { new Product { Name = "Apple", Price = 0.60M }, new Product { Name = "Orange", Price = 0.25M } };
        }

        public Product GetByName(string name)
        {
            return products.FirstOrDefault(product => product.Name == name);
        }
    }
}
