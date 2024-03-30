﻿using Bank.Service.Interfaces.Repositories;
using Infrastructure.DTO;
using Infrastructure.Repositories;

namespace Repositories
{
    internal sealed class UserRepository : RepositoryBase<User>, IUserRepository
    {
        internal UserRepository(BankDbContext context) : base(context)
        {

        }
    }
}