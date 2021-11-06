using System.Collections.Generic;
using System.Linq;
using TechTest.Shop.Models;
using TechTest.Shop.Repository;

namespace TechTest.Shop
{
    public class ShoppingCart : IShoppingCart
    {
        private List<CartItem> cartItems;
        private ProductRepository repository;

        public ShoppingCart(ProductRepository repository)
        {
            this.repository = repository;
            this.cartItems = new List<CartItem>();
        }

        /// <summary>
        /// We need to add the scanned items to cart before we can checkout
        /// Brief says use a list of strings as input, so I've implemented the add to cart using that
        /// </summary>
        /// <param name="items"></param>
        public void AddToCart(List<string> items)
        {
            foreach (var item in items)
            {
                CartItem cartItem = this.cartItems.FirstOrDefault(x => x.Product.Name == item);

                if (cartItem != null)
                {
                    cartItem.Quantity++;
                }
                else
                {
                    var product = repository.GetByName(item);
                    if (product != null)
                    {
                        this.cartItems.Add(new CartItem { Product = product, Quantity = 1 });
                    }
                }
            }
        }

        public string Checkout()
        {
            var cartItems = GetItems();
            decimal totalValue = GetTotalPrice(cartItems);

            return $"{totalValue:C}";
        }

        public decimal GetTotalPrice(ICollection<CartItem> cartItems)
        {
            decimal total = 0;

            if(cartItems != null)
            {
                total = cartItems.Sum(x => x.Product.Price * x.Quantity);
            }

            return total;
        }

        /// <summary>
        /// Gets all the items added to the shopping cart
        /// </summary>
        /// <returns></returns>
        public ICollection<CartItem> GetItems()
        {
            return this.cartItems;
        }
    }
}
