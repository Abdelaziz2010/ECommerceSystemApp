
namespace ECommerceSystemApp.Models
{
    public class Product
    {
        public Product(string name, decimal price, int quantity)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Product name cannot be null or empty");
            
            if (price < 0)
                throw new ArgumentException("Price cannot be negative");
            
            if (quantity < 0)
                throw new ArgumentException("Quantity cannot be negative");

            Name = name;
            Quantity = quantity;
            Price = price;
        }

        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }

        public virtual bool IsExpired()
        {
            return false;   // Default 
        }
    }
}
