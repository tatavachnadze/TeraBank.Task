using Infrastructure.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Service.Interfaces.Services
{
    public interface IAccountService
    {
        Task<Account> GetAccount(int id);
        Task<IQueryable<Account>> GetAccounts();
        void CreateAccount(Account account);
        void UpdateAccount(Account account);
        void SuspendAccount(int accountId);
        void ResumeAccount(int accountId);
        void DeleteAccount(int accountId);
    }
}
