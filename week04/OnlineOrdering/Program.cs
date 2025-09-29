using System;
using System.Globalization;

namespace OnlineOrdering
{
    class Program
    {
        static string Money(decimal amount)
        {
            return amount.ToString("C", CultureInfo.GetCultureInfo("en-US"));
        }

        static void PrintOrder(Order order)
        {
            Console.WriteLine(order.GetPackingLabel());
            Console.WriteLine();
            Console.WriteLine(order.GetShippingLabel());
            Console.WriteLine();
            Console.WriteLine($"TOTAL: {Money(order.GetTotalPrice())}");
            Console.WriteLine(new string('-', 40));
        }

        static void Main()
        {
            // Customer 1 — USA (shipping = $5)
            var addr1 = new Address("123 Main St", "Rexburg", "ID", "USA");
            var cust1 = new Customer("Emily Carter", addr1);
            var order1 = new Order(cust1);
            order1.AddProduct(new Product("USB-C Cable", "CAB-001", 7.99m, 2));
            order1.AddProduct(new Product("Wireless Mouse", "MOU-210", 19.50m, 1));
            order1.AddProduct(new Product("Notebook", "STA-112", 2.25m, 3));

            // Customer 2 — International (shipping = $35)
            var addr2 = new Address("Av. Independencia 45", "Santo Domingo", "DN", "Dominican Republic");
            var cust2 = new Customer("Alejandro Vanderhorst", addr2);
            var order2 = new Order(cust2);
            order2.AddProduct(new Product("Mechanical Keyboard", "KEY-870", 59.99m, 1));
            order2.AddProduct(new Product("Mouse Pad XL", "PAD-300", 12.00m, 2));

            // Display both orders
            PrintOrder(order1);
            PrintOrder(order2);
        }
    }
}
