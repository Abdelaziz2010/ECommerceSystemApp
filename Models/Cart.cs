
namespace ECommerceSystemApp.Models
{
    public class Cart
    {
        public List<CartItem> Items { get; set; } = new List<CartItem>();

        public void Add(Product product, int quantity)
        {
            if (product == null)
                throw new ArgumentNullException("Product cannot be null");
            
            if (quantity <= 0 || quantity > product.Quantity)
                throw new ArgumentException("Invalid quantity");
            
            Items.Add(new CartItem(product, quantity));
        }

        public bool IsEmpty()
        {
            return !Items.Any();
        }
    }
}
