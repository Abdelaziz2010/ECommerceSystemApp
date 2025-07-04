
using ECommerceSystemApp.Interfaces;
using ECommerceSystemApp.Models;

namespace ECommerceSystemApp.Services
{
    public class ShippingService
    {
        public  void ShipItems(List<IShippable> items)
        {
            if (items == null || items.Count == 0)
                return;

            Console.WriteLine("** Shipment notice **");

            var grouped = items
                .GroupBy(p => new { Name = p.GetName(), Weight = p.GetWeight() });


            double totalWeight = 0;

            foreach (var group in grouped)
            {
                string name = group.Key.Name;
                int count = group.Count();
                double weightEach = group.Key.Weight;
                double totalItemWeight = count * weightEach;


                Console.WriteLine($"{count}x {name,-12} {totalItemWeight * 1000:0}g");


                totalWeight += totalItemWeight;
            }

            Console.WriteLine($"Total package weight {totalWeight:F1}kg");
            Console.WriteLine();
        }
    }
}
