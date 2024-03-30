using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    internal sealed class AccountRepository : RepositoryBase<Account>, IAccountRepository
    {
        internal AccountRepository(BankDbContext context) : base(context)
        {

        }
    }
}
