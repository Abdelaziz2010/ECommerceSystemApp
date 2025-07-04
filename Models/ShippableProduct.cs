

using ECommerceSystemApp.Interfaces;

namespace ECommerceSystemApp.Models
{
    public class ShippableProduct : Product, IShippable
    {
        public double Weight { get; }

        public ShippableProduct(string name, decimal price, int quantity, double weight)
            : base(name, price, quantity)
        {
            Weight = weight;
        }

        public double GetWeight()
        {
            return Weight;
        }

        public string GetName()
        {
            return Name;
        }
    }
}
