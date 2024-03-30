using Bank.Service.Interfaces.Repositories;
using Infrastructure.DTO;
using Infrastructure.Repositories;

namespace Repositories
{
    internal sealed class TransactionRepository : RepositoryBase<Transaction>, ITransactionRepository
    {
        internal TransactionRepository(BankDbContext dbContext) : base(dbContext)
        {
                
        }
    }
}
