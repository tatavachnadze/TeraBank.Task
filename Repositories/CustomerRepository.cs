using Bank.Service.Interfaces.Repositories;
using Infrastructure.DTO;
using Infrastructure.Repositories;


namespace Repositories
{
    internal sealed class CustomerRepository : RepositoryBase<Customer>, ICustomerRepository
    {
        internal CustomerRepository(BankDbContext context) : base(context)
        {

        }
    }
}
