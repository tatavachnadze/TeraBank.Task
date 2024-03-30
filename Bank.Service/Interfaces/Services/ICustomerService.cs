using Infrastructure.DTO;

namespace Bank.Service.Interfaces.Services
{
    public interface ICustomerService
    {
        Task<Customer> GetCustomer(int customerId);
        Task<IQueryable<Customer>> GetCustomers();
        void AddCustomer(Customer customer);
        void UpdateCustomer(Customer customer);
        void DeleteCustomer(int customerId);

    }
}
