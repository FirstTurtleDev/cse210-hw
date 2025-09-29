using System;

namespace OnlineOrdering
{
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
}
