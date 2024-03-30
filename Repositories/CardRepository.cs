using Bank.Service.Interfaces.Repositories;
using Infrastructure.DTO;
using Infrastructure.Repositories;


namespace Repositories
{
    internal sealed class CardRepository : RepositoryBase<Card>, ICardRepository
    {
        internal CardRepository(BankDbContext context) : base(context)
        {

        }
    }
}
