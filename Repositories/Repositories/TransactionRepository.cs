using Domain.Abstractions;
using Domain.Entities;
using Infrastructure;
using Infrastructure.Repositories;

namespace Infrastructure.Repositories
{
    internal sealed class TransactionRepository : RepositoryBase<Transaction>, ITransactionRepository
    {
        internal TransactionRepository(BankDbContext dbContext) : base(dbContext)
        {
                
        }
    }
}
