using Domain.Entities;

namespace Bank.Service.Interfaces.Services
{
    public interface ICustomerService
    {
        Task<Customer> GetCustomer(int customerId);
        Task<IEnumerable<Customer>> GetCustomers();
        void AddCustomer(Customer customer);
        void UpdateCustomer(Customer customer);
        void DeleteCustomer(int customerId);

    }
}
