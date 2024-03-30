using Bank.Service.Interfaces.Repositories;
using Infrastructure.DTO;


namespace Infrastructure.Repositories;

internal sealed class AccountRepository : RepositoryBase<Account>, IAccountRepository
{
    internal AccountRepository(BankDbContext context) : base(context)
    {

    }
}
