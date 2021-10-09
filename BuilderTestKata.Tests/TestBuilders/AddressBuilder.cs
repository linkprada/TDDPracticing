using BuilderTestKata.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderTestKata.Tests.TestBuilders
{
    public class AddressBuilder
    {
        private string _street1;
        private string _city;
        private string _state;
        private string _postalCode;
        private string _country;

        public AddressBuilder WithAdresse(string street)
        {
            _street1 = street;
            return this;
        }

        public AddressBuilder WithCity(string city)
        {
            _city = city;
            return this;
        }

        public AddressBuilder WithState(string state)
        {
            _state = state;
            return this;
        }

        public AddressBuilder WithPostalCode(string postalCode)
        {
            _postalCode = postalCode;
            return this;
        }

        public AddressBuilder WithCountry(string country)
        {
            _country = country;
            return this;
        }

        public Address Build()
        {
            return new Address
            {
                Street1 = _street1,
                City = _city,
                State = _state,
                PostalCode = _postalCode,
                Country = _country,
            };
        }

        public AddressBuilder WithTestValues()
        {
            _street1 = "Street Test";
            _city = "City Test";
            _state = "State Test";
            _postalCode = "000001";
            _country = "Country Test";
            return this;
        }
    }
}
