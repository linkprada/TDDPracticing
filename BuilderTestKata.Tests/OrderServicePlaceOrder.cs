using BuilderTestKata.Exceptions;
using BuilderTestKata.Services;
using BuilderTestKata.Tests.TestBuilders;
using Xunit;

namespace BuilderTestKata.Tests
{
    public class OrderServicePlaceOrder
    {
        private readonly OrderService _orderService = new ();

        private readonly OrderBuilder _orderBuilder = new ();
        private readonly CustomerBuilder _customerBuilder = new ();
        private readonly AddressBuilder _addressBuilder = new ();

        [Fact]
        public void ThrowsExceptionGivenOrderWithExistingId()
        {
            var order = _orderBuilder
                            .WithId(123)
                            .Build();

            Assert.Throws<InvalidOrderException>(() => _orderService.PlaceOrder(order));
        }

        [Fact]
        public void PlaceOrder_OrderAmountNegative_ThrowsExcepion()
        {
            var order = _orderBuilder
                            .WithTotalAmount(-12)
                            .Build();

            Assert.Throws<InvalidOrderException>(() => _orderService.PlaceOrder(order));
        }

        [Fact]
        public void PlaceOrder_OrderWithNullCustomer_ThrowsException()
        {
            var order = _orderBuilder
                            .WithCustomer(null)
                            .Build();

            Assert.Throws<InvalidOrderException>(() => _orderService.PlaceOrder(order));
        }

        [Fact]
        public void PlaceOrder_CustomerIDNegative_ThrowsException()
        {
            var customer = _customerBuilder
                                .WithTestValues()
                                .WithId(-2)
                                .Build();

            var order = _orderBuilder
                            .WithCustomer(customer)
                            .Build();

            Assert.Throws<InvalidCustomerException>(() => _orderService.PlaceOrder(order));
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void PlaceOrder_CustomerWithoutFirstAndLastName_ThrowsException(string inputName)
        {
            var customer = _customerBuilder
                                .WithTestValues()
                                .WithFirstName(inputName)
                                .WithLastName(inputName)
                                .Build();

            var order = _orderBuilder
                            .WithCustomer(customer)
                            .Build();

            Assert.Throws<InvalidCustomerException>(() => _orderService.PlaceOrder(order));
        }

        [Fact]
        public void PlaceOrder_CustomerCreditRatingLessThan200_ThrowsException()
        {
            var customer = _customerBuilder
                                .WithTestValues()
                                .WithCreditRating(166)
                                .Build();

            var order = _orderBuilder
                            .WithCustomer(customer)
                            .Build();

            Assert.Throws<InsufficientCreditException>(() => _orderService.PlaceOrder(order));
        }

        [Fact]
        public void PlaceOrder_CustomerTotalPurchaseNegative_ThrowsException()
        {
            var customer = _customerBuilder
                                .WithTestValues()
                                .WithTotalPurchase(-10m)
                                .Build();

            var order = _orderBuilder
                            .WithCustomer(customer)
                            .Build();

            Assert.Throws<InvalidCustomerException>(() => _orderService.PlaceOrder(order));
        }

        [Fact]
        public void PlaceOrder_CustomerWithoutAdresse_ThrowsException()
        {
            var customer = _customerBuilder
                                .WithTestValues()
                                .WithAddress(null)
                                .Build();

            var order = _orderBuilder
                            .WithCustomer(customer)
                            .Build();

            Assert.Throws<InvalidCustomerException>(() => _orderService.PlaceOrder(order));
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void PlaceOrder_AddressWithoutStreet1_ThrowsException(string inputStreet)
        {
            var address = _addressBuilder
                                .WithTestValues()
                                .WithAdresse(inputStreet)
                                .Build();

            var customer = _customerBuilder
                                .WithTestValues()
                                .WithAddress(address)
                                .Build();

            var order = _orderBuilder
                            .WithCustomer(customer)
                            .Build();

            Assert.Throws<InvalidAddressException>(() => _orderService.PlaceOrder(order));
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void PlaceOrder_AddressWithoutCity_ThrowsException(string inputCity)
        {
            var address = _addressBuilder
                                .WithTestValues()
                                .WithCity(inputCity)
                                .Build();

            var customer = _customerBuilder
                                .WithTestValues()
                                .WithAddress(address)
                                .Build();

            var order = _orderBuilder
                            .WithCustomer(customer)
                            .Build();

            Assert.Throws<InvalidAddressException>(() => _orderService.PlaceOrder(order));
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void PlaceOrder_AddressWithoutState_ThrowsException(string inputState)
        {
            var address = _addressBuilder
                                .WithTestValues()
                                .WithState(inputState)
                                .Build();

            var customer = _customerBuilder
                                .WithTestValues()
                                .WithAddress(address)
                                .Build();

            var order = _orderBuilder
                            .WithCustomer(customer)
                            .Build();

            Assert.Throws<InvalidAddressException>(() => _orderService.PlaceOrder(order));
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void PlaceOrder_AddressWithoutPostalCode_ThrowsException(string inputPostalCode)
        {
            var address = _addressBuilder
                                .WithTestValues()
                                .WithPostalCode(inputPostalCode)
                                .Build();

            var customer = _customerBuilder
                                .WithTestValues()
                                .WithAddress(address)
                                .Build();

            var order = _orderBuilder
                            .WithCustomer(customer)
                            .Build();

            Assert.Throws<InvalidAddressException>(() => _orderService.PlaceOrder(order));
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void PlaceOrder_AddressWithoutCountry_ThrowsException(string inputCountry)
        {
            var address = _addressBuilder
                                .WithTestValues()
                                .WithCountry(inputCountry)
                                .Build();

            var customer = _customerBuilder
                                .WithTestValues()
                                .WithAddress(address)
                                .Build();

            var order = _orderBuilder
                            .WithCustomer(customer)
                            .Build();

            Assert.Throws<InvalidAddressException>(() => _orderService.PlaceOrder(order));
        }

        [Theory]
        [InlineData(9000, 900)]
        [InlineData(6000, 700)]
        public void PlaceOrder_CustomerTotalPurchaseGreaterThan5000AndCreditRatingGreaterThan500_IsExpeditedTrue(decimal inputTotalPurchase, int inputCreditRating)
        {
            var customer = _customerBuilder
                                .WithTestValues()
                                .WithTotalPurchase(inputTotalPurchase)
                                .WithCreditRating(inputCreditRating)
                                .Build();

            var order = _orderBuilder
                            .WithTestValues()
                            .WithCustomer(customer)
                            .Build();

            _orderService.PlaceOrder(order);

            Assert.True(order.IsExpedited);
        }

        [Fact]
        public void PlaceOrder_AddOrderToCustomer_OrderHistoryUpdated()
        {
            var customer = _customerBuilder
                                .WithTestValues()
                                .Build();

            var order = _orderBuilder
                            .WithTestValues()
                            .WithCustomer(customer)
                            .Build();

            _orderService.PlaceOrder(order);

            Assert.Contains(order, customer.OrderHistory);
        }

        [Fact]
        public void PlaceOrder_AddOrderToCustomer_UpdateCustomerTotalPurchase()
        {
            var customer = _customerBuilder
                                .WithTestValues()
                                .WithTotalPurchase(7)
                                .Build();

            var order = _orderBuilder
                            .WithTestValues()
                            .WithCustomer(customer)
                            .Build();

            _orderService.PlaceOrder(order);

            Assert.Equal(8, order.Customer.TotalPurchases);
        }
    }
}
