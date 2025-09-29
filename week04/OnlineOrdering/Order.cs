using System;
using System.Collections.Generic;

namespace OnlineOrdering
{
    public class Order
    {
        private readonly Customer _customer;
        private readonly List<Product> _products = new();

        public Order(Customer customer)
        {
            _customer = customer;
        }

        public void AddProduct(Product product) => _products.Add(product);

        public decimal GetTotalPrice()
        {
            decimal subtotal = 0m;
            foreach (var p in _products)
            {
                subtotal += p.TotalCost();
            }

            decimal shipping = _customer.IsInUSA() ? 5m : 35m;
            return subtotal + shipping;
        }

        public string GetPackingLabel()
        {
            var lines = new List<string> { "PACKING LABEL" };
            foreach (var p in _products)
            {
                lines.Add($" - {p.PackingLine()}");
            }
            return string.Join("\n", lines);
        }

        public string GetShippingLabel()
        {
            return $"SHIPPING LABEL\n{_customer.GetName()}\n{_customer.GetShippingAddress()}";
        }
    }
}
