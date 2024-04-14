using Domain.Abstractions;
using Domain.Entities;
using Infrastructure;
using Infrastructure.Repositories;

namespace Infrastructure.Repositories
{
    internal sealed class UserRepository : RepositoryBase<User>, IUserRepository
    {
        internal UserRepository(BankDbContext context) : base(context)
        {

        }
    }
}
