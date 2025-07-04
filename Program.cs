using ECommerceSystemApp.Models;
using ECommerceSystemApp.Services;

namespace ECommerceSystemApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("CASE 1: All is good");

            var customer1 = new Customer("Aziz", 1000);
            var cart1 = new Cart();
            var cheese1 = new ExpirableShippableProduct("Cheese", 100, 5, 0.2, DateTime.Now.AddDays(5));
            var biscuits1 = new ExpirableShippableProduct("Biscuits", 150, 2, 0.7, DateTime.Now.AddDays(3));
            var scratchCard1 = new Product("ScratchCard", 50, 10);
            var shippingService1 = new ShippingService();
            var checkoutService1 = new CheckoutService(shippingService1);

            cart1.Add(cheese1, 2);
            cart1.Add(biscuits1, 1);
            cart1.Add(scratchCard1, 1);

            checkoutService1.Checkout(customer1, cart1);


            Console.WriteLine("\n=========================================================\n");

            Console.WriteLine("\nCASE 2: Product is expired");

            try
            {
                var customer2 = new Customer("Aziz", 1000);
                var cart2 = new Cart();
                var expiredCheese = new ExpirableShippableProduct("Cheese", 100, 5, 0.2, DateTime.Now.AddDays(-1)); // Expired!
                var biscuits2 = new ExpirableShippableProduct("Biscuits", 150, 2, 0.7, DateTime.Now.AddDays(3));
                var shippingService2 = new ShippingService();
                var checkoutService2 = new CheckoutService(shippingService2);

                cart2.Add(expiredCheese, 1);
                cart2.Add(biscuits2, 1);

                checkoutService2.Checkout(customer2, cart2);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error: {ex.Message}");
            }


            Console.WriteLine("\n=========================================================\n");

            Console.WriteLine("\nCASE 3: Product out of stock");

            try
            {
                var customer3 = new Customer("Aziz", 1000);
                var cart3 = new Cart();
                var tv = new ShippableProduct("TV", 8000, 1, 3);
                var scratchCard3 = new Product("ScratchCard", 50, 2);
                var shippingService3 = new ShippingService();
                var checkoutService3 = new CheckoutService(shippingService3);

                cart3.Add(tv, 2); // ❌ Only 1 in stock, trying to buy 2

                checkoutService3.Checkout(customer3, cart3);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error: {ex.Message}");
            }



            Console.WriteLine("\n=========================================================\n");

            Console.WriteLine("\nCASE 4: Customer balance insufficient");

            try
            {
                var customer4 = new Customer("Aziz", 100); // ❌ Not enough
                var cart4 = new Cart();
                var cheese4 = new ExpirableShippableProduct("Cheese", 100, 5, 0.2, DateTime.Now.AddDays(5));
                var biscuits4 = new ExpirableShippableProduct("Biscuits", 150, 2, 0.7, DateTime.Now.AddDays(3));
                var shippingService4 = new ShippingService();
                var checkoutService4 = new CheckoutService(shippingService4);

                cart4.Add(cheese4, 2);     // 200
                cart4.Add(biscuits4, 1);   // 150 → subtotal = 350
                                           // + shipping = 30 → total = 380

                checkoutService4.Checkout(customer4, cart4); // ❌ Only has 100
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error: {ex.Message}");
            }
        }
    }
}
