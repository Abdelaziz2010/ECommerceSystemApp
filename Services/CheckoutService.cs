
using ECommerceSystemApp.Interfaces;
using ECommerceSystemApp.Models;

namespace ECommerceSystemApp.Services
{
    public class CheckoutService
    {
        private const decimal ShippingFee = 30;   // Fixed shipping fee for all orders

        private readonly ShippingService _shippingService;
        
        public CheckoutService(ShippingService shippingService)
        {
            _shippingService = shippingService;
        }

        public void Checkout(Customer customer, Cart cart)
        {
            // Make sure the cart has products and the customer exists.
            if (cart.IsEmpty())
                throw new InvalidOperationException("Cart is empty");

            if (customer == null)
                throw new ArgumentNullException(nameof(customer));

            decimal subtotal = 0;
            
            var shippableItems = new List<IShippable>();

            // Check for expired or out of stock products
            foreach (var item in cart.Items)
            {
                var product = item.Product;

                if (product.IsExpired())
                    throw new InvalidOperationException($"{product.Name} is expired.");

                if (item.Quantity > product.Quantity)  
                    throw new InvalidOperationException($"{product.Name} is out of stock.");

                subtotal += product.Price * item.Quantity;
                
                product.Quantity -= item.Quantity; 

                if (product is IShippable shippable)
                    shippableItems.AddRange(Enumerable.Repeat(shippable, item.Quantity));
            }

            decimal total = subtotal + (shippableItems.Any() ? ShippingFee : 0);

            if (customer.Balance < total)
                throw new InvalidOperationException("Insufficient balance.");

            customer.Balance -= total;

            if (shippableItems.Any())
                _shippingService.ShipItems(shippableItems);

            Console.WriteLine("** Checkout receipt **");
            foreach (var item in cart.Items)
            {
                Console.WriteLine($"{item.Quantity}x {item.Product.Name,-10}{item.Product.Price * item.Quantity}");
            }

            Console.WriteLine("----------------------");
            Console.WriteLine($"Subtotal         {subtotal}");
            
            if (shippableItems.Any())
                Console.WriteLine($"Shipping         {ShippingFee}");
            Console.WriteLine($"Amount           {total}");
        }
    }
}
