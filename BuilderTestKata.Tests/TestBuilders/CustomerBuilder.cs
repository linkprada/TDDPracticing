
using BuilderTestKata.Model;
using System;

namespace BuilderTestKata.Tests.TestBuilders
{
    public class CustomerBuilder
    {
        private int _id;
        public const int TEST_CUSTOMER_ID = 123;
        private string _firstName;
        private string _lastName;
        private int _creditRating;
        private decimal _totalPurchase;
        private Address _homeAddress;

        public CustomerBuilder WithId(int id)
        {
            _id = id;
            return this;
        }

        public CustomerBuilder WithFirstName(string firstName)
        {
            _firstName = firstName;
            return this;
        }

        public CustomerBuilder WithLastName(string lastName)
        {
            _lastName = lastName;
            return this;
        }

        public CustomerBuilder WithCreditRating(int creditRating)
        {
            _creditRating = creditRating;
            return this;
        }

        public CustomerBuilder WithTotalPurchase(decimal totalPurchase)
        {
            _totalPurchase = totalPurchase;
            return this;
        }

        public CustomerBuilder WithAddress(Address homeAddress)
        {
            _homeAddress = homeAddress;
            return this;
        }

        public Customer Build()
        {
            return new Customer(_id) 
            {
                FirstName = _firstName,
                LastName = _lastName,
                CreditRating = _creditRating,
                TotalPurchases = _totalPurchase,
                HomeAddress = _homeAddress,
            };
        }

        public CustomerBuilder WithTestValues()
        {
            _id = TEST_CUSTOMER_ID;
            _firstName = "John";
            _lastName = "Doe";
            _creditRating = 365;
            _totalPurchase = 19m;
            _homeAddress = new AddressBuilder().WithTestValues().Build();
            return this;
        }
    }
}
