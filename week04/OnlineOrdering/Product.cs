using System;

namespace OnlineOrdering
{
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
}
