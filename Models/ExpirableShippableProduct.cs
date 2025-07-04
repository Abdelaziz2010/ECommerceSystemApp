
namespace ECommerceSystemApp.Models
{
    public class ExpirableShippableProduct : ShippableProduct
    {
        public DateTime ExpirationDate { get; set; }
        public ExpirableShippableProduct(string name, decimal price, int quantity, double weight, DateTime expirationDate)
            : base(name, price, quantity, weight)
        {
            if (expirationDate < DateTime.Now)
                throw new ArgumentException("Expiration date cannot be in the past");

            ExpirationDate = expirationDate;
        }
        public override bool IsExpired()
        {
            return DateTime.Now > ExpirationDate;
        }
    }
}
