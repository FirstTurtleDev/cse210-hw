using System;
using System.Collections.Generic;
using System.Globalization;

namespace OnlineOrdering
{
    // ---------- Address ----------
    public class Address
    {
        private readonly string _street;
        private readonly string _city;
        private readonly string _stateOrProvince;
        private readonly string _country;

        public Address(string street, string city, string stateOrProvince, string country)
        {
            _street = street;
            _city = city;
            _stateOrProvince = stateOrProvince;
            _country = country;
        }

        public bool IsInUSA()
        {
            // Accept common spellings
            var c = _country.Trim().ToLowerInvariant();
            return c == "usa" || c == "united states" || c == "united states of america" || c == "us";
        }

        public string Format()
        {
            return $"{_street}\n{_city}, {_stateOrProvince}\n{_country}";
        }
    }

    // ---------- Customer ----------
    public class Customer
    {
        private readonly string _name;
        private readonly Address _address;

        public Customer(string name, Address address)
        {
            _name = name;
            _address = address;
        }

        public bool IsInUSA() => _address.IsInUSA();

        public string GetName() => _name;
        public string GetShippingAddress() => _address.Format();
    }

    // ---------- Product ----------
    public class Product
    {
        private readonly string _name;
        private readonly string _productId;
        private readonly decimal _pricePerUnit;
        private readonly int _quantity;

        public Product(string name, string productId, decimal pricePerUnit, int quantity)
        {
            _name = name;
            _productId = productId;
            _pricePerUnit = pricePerUnit;
            _quantity = quantity;
        }

        public string GetName() => _name;
        public string GetProductId() => _productId;

        public decimal TotalCost() => _pricePerUnit * _quantity;

        public string PackingLine()
        {
            return $"{_name} (ID: {_productId}) x{_quantity}";
        }
    }

    // ---------- Order ----------
    public class Order
    {
        private readonly Customer _customer;
        private readonly List<Product> _products = new();

        public Order(Customer customer)
        {
            _customer = customer;
        }

        public void AddProduct(Product p) => _products.Add(p);

        public decimal GetTotalPrice()
        {
            decimal subtotal = 0m;
            foreach (var p in _products) subtotal += p.TotalCost();

            decimal shipping = _customer.IsInUSA() ? 5m : 35m;
            return subtotal + shipping;
        }

        public string GetPackingLabel()
        {
            var lines = new List<string> { "PACKING LABEL" };
            foreach (var p in _products) lines.Add($" - {p.PackingLine()}");
            return string.Join("\n", lines);
        }

        public string GetShippingLabel()
        {
            return $"SHIPPING LABEL\n{_customer.GetName()}\n{_customer.GetShippingAddress()}";
        }
    }

    // ---------- Program ----------
    class Program
    {
        static string Money(decimal amount)
        {
            // US currency formatting
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
            // Customers
            var addr1 = new Address("123 Main St", "Rexburg", "ID", "USA");
            var cust1 = new Customer("Emily Carter", addr1);

            var addr2 = new Address("Av. Independencia 45", "Santo Domingo", "DN", "Dominican Republic");
            var cust2 = new Customer("Alejandro Vanderhorst", addr2);

            // Order 1 (USA => $5 shipping)
            var order1 = new Order(cust1);
            order1.AddProduct(new Product("USB-C Cable", "CAB-001", 7.99m, 2));
            order1.AddProduct(new Product("Wireless Mouse", "MOU-210", 19.50m, 1));
            order1.AddProduct(new Product("Notebook", "STA-112", 2.25m, 3));

            // Order 2 (International => $35 shipping)
            var order2 = new Order(cust2);
            order2.AddProduct(new Product("Mechanical Keyboard", "KEY-870", 59.99m, 1));
            order2.AddProduct(new Product("Mouse Pad XL", "PAD-300", 12.00m, 2));

            // Display both orders
            PrintOrder(order1);
            PrintOrder(order2);

            // If you run without debugging and want the window to stay:
            // Console.WriteLine("Press any key to exit...");
            // Console.ReadKey();
        }
    }
}
