using System;
using System.Collections.Generic;
using TechTest.Shop;
using TechTest.Shop.Repository;

namespace TechTest.Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            //In a real world app ProductRepository should be injected using dependency injection
            ShoppingCart shoppingCart = new ShoppingCart(new ProductRepository());
            shoppingCart.AddToCart(new List<string> { "Apple", "Apple", "Orange", "Apple" });

            Console.WriteLine($"Total : {shoppingCart.Checkout()}");
            Console.ReadLine();
        }
    }
}
