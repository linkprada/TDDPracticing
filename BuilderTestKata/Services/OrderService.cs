using BuilderTestKata.Exceptions;
using BuilderTestKata.Model;

namespace BuilderTestKata.Services
{
    public class OrderService
    {
        public void PlaceOrder(Order order)
        {
            ValidateOrder(order);

            ExpediteOrder(order);

            AddOrderToCustomerHistory(order);
        }

        private void ValidateOrder(Order order)
        {
            if (order.Id != 0) throw new InvalidOrderException("Order ID must be 0.");

            if (order.TotalAmount < 0) throw new InvalidOrderException("Order Total Amount must be greater than 0.");
            
            if (order.Customer is null) throw new InvalidOrderException("Order must have a customer.");

            ValidateCustomer(order.Customer);
        }

        private void ValidateCustomer(Customer customer)
        {
            if (customer.Id < 0) throw new InvalidCustomerException("Customer ID must be greater than 0.");
            
            if (string.IsNullOrEmpty(customer.FirstName) && string.IsNullOrEmpty(customer.LastName)) throw new InvalidCustomerException("Customer must have first and last name.");
            
            if (customer.CreditRating < 200) throw new InsufficientCreditException("Customer credit rating must be greater than 200.");
            
            if (customer.TotalPurchases < 0) throw new InvalidCustomerException("Customer total purchase must be greater or equal to 0.");
            
            if (customer.HomeAddress is null) throw new InvalidCustomerException("Customer must have an adresse.");
            
            ValidateAddress(customer.HomeAddress);
        }

        private void ValidateAddress(Address homeAddress)
        {            
            if (string.IsNullOrEmpty(homeAddress.Street1)) throw new InvalidAddressException("Address must have a street.");
            
            if (string.IsNullOrEmpty(homeAddress.City)) throw new InvalidAddressException("Address must have a city.");
            
            if (string.IsNullOrEmpty(homeAddress.State)) throw new InvalidAddressException("Address must have a city.");
            
            if (string.IsNullOrEmpty(homeAddress.PostalCode)) throw new InvalidAddressException("Address must have a city.");
            
            if (string.IsNullOrEmpty(homeAddress.Country)) throw new InvalidAddressException("Address must have a city.");
        }

        private void ExpediteOrder(Order order)
        {
            order.IsExpedited = false;
            if (order.Customer.TotalPurchases > 5000 && order.Customer.CreditRating > 500)
            {
                order.IsExpedited = true;
            }
        }

        private void AddOrderToCustomerHistory(Order order)
        {
            order.Customer.OrderHistory.Add(order);

            order.Customer.TotalPurchases++;
        }
    }
}
