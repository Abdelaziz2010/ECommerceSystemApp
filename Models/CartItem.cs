
namespace ECommerceSystemApp.Models
{
    public class CartItem
    {
        public CartItem(Product product, int quantity)
        {
            Product = product;
            Quantity = quantity;
        }

        public Product Product { get; }
        public int Quantity { get; }
    }
}
