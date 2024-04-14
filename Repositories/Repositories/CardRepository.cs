using Domain.Abstractions;
using Domain.Entities;
using Infrastructure;
using Infrastructure.Repositories;


namespace Infrastructure.Repositories
{
    internal sealed class CardRepository : RepositoryBase<Card>, ICardRepository
    {
        internal CardRepository(BankDbContext context) : base(context)
        {

        }
    }
}
