using Domain.Abstractions;
using Domain.Entities;

namespace Infrastructure.Repositories;

internal sealed class AccountRepository : RepositoryBase<Account>, IAccountRepository
{
    internal AccountRepository(BankDbContext context) : base(context)
    {

    }
}
