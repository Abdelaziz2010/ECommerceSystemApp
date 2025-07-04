
namespace ECommerceSystemApp.Models
{
    public class Customer
    {
        public Customer(string name, decimal balance)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Customer name cannot be null or empty");

            if (balance < 0)
                throw new ArgumentException("Balance cannot be negative");

            Name = name;
            Balance = balance;
        }

        public string Name { get; set; }
        public decimal Balance { get; set; }
    }
}
