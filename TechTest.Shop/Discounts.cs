using System.Linq;
using TechTest.Shop.Models;

namespace TechTest.Shop
{
    public static class Discounts
    {
        public static decimal Checkout(this IShoppingCart cart, bool applyDiscount)
        {
            var cartItems = cart.GetItems();
            decimal total = 0;

            if (cartItems != null)
            {
                if(applyDiscount)
                {
                    total = cartItems.Where(x=> x.Product.Name == "Apple").Sum(x => x.Product.Price * GetTwoForOneQuantity(x.Quantity));
                    total += cartItems.Where(x => x.Product.Name == "Orange").Sum(x => x.Product.Price * GetThreeForTwoQuantity(x.Quantity));
                }
                else
                {
                    total = cartItems.Sum(x => x.Product.Price * x.Quantity);
                }
            }

            return total;
        }

        /// <summary>
        /// Calculates the quantity for two for one discount
        /// </summary>
        /// <returns></returns>
        private static int GetTwoForOneQuantity(int quantity)
        {
            int quantityBilled;
            
            const int discount = 2;
            
            if (quantity % discount == 0)
            {
                quantityBilled = quantity / discount;
            }
            else
            {
                quantityBilled = (quantity - 1) / discount + 1;
            }

            return quantityBilled;
        }

        /// <summary>
        /// Calculates 3 for the price of 2 
        /// </summary>
        /// <param name="quantity"></param>
        /// <returns></returns>
        private static int GetThreeForTwoQuantity(int quantity)
        {
            int quantityBilled = 0;
            const int discount = 3;

            for (int i = 1; i <= quantity; i++)
            {
                int remainder = i % 3;
                if (remainder == 0)
                {
                    quantityBilled += 2;
                }
            }

            return quantityBilled += quantity % discount;
        }
    }
}
