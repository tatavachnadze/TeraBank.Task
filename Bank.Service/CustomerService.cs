using Bank.Service.Interfaces.Repositories;
using Bank.Service.Interfaces.Services;
using Infrastructure.DTO;

namespace Bank.Service
{
    public sealed class CustomerService : ICustomerService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CustomerService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public Task<Customer> GetCustomer(int customerId)
        {
            Customer customer = _unitOfWork.CustomerRepository.Get(customerId);
            if (customer != null)
            {
                return Task.FromResult(customer);
            }
            else
            {
                throw new InvalidDataException("CustomerId could not be found within data.");
            }
        }

        public Task<IQueryable<Customer>> GetCustomers()
        {
            var customers = _unitOfWork.CustomerRepository.Set();
            if (customers != null)
            {
                return Task.FromResult(customers);
            }
            else
            {
                throw new InvalidDataException("Customers could not be found within data.");
            }
        }

        public void AddCustomer(Customer customer)
        {
            if (customer == null) throw new ArgumentNullException("The customer needs to be provided.");
            _unitOfWork.CustomerRepository.Insert(customer);
            _unitOfWork.SaveChanges();
        }

        public void UpdateCustomer(Customer customer)
        {
            if (customer == null) throw new ArgumentNullException("The customer needs to be provided.");
            _unitOfWork.CustomerRepository.Update(customer);
            _unitOfWork.SaveChanges();
        }

        public void DeleteCustomer(int customerId)
        {
            Customer customer = _unitOfWork.CustomerRepository.Get(customerId) ?? throw new InvalidDataException("CustomerId could not be found within data.");
            customer.IsActive = false;
            _unitOfWork.CustomerRepository.Update(customer);
            _unitOfWork.SaveChanges();
        }


    }
}
