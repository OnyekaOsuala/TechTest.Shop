using System.Collections.Generic;

namespace TechTest.Shop.Models
{
    public interface IShoppingCart
    {
        void AddToCart(List<string> items);

        ICollection<CartItem> GetItems();

        decimal GetTotalPrice(ICollection<CartItem> cartItems);

        string Checkout();
    }
}
