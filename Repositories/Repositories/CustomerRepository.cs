using Domain.Abstractions;
using Domain.Entities;
using Infrastructure;
using Infrastructure.Repositories;


namespace Infrastructure.Repositories
{
    internal sealed class CustomerRepository : RepositoryBase<Customer>, ICustomerRepository
    {
        internal CustomerRepository(BankDbContext context) : base(context)
        {

        }
    }
}
