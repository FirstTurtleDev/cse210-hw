using System;

namespace OnlineOrdering
{
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
            var c = _country.Trim().ToLowerInvariant();
            return c == "usa" || c == "united states" || c == "united states of america" || c == "us";
        }

        public string Format()
        {
            return $"{_street}\n{_city}, {_stateOrProvince}\n{_country}";
        }
    }
}
