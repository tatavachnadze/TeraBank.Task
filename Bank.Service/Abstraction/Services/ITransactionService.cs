using Domain.Entities;

namespace Bank.Service.Interfaces.Services
{
    public interface ITransactionService
    {
        Task<Transaction> GetTransaction(int id);
        Task<IEnumerable<Transaction>> GetTransactions();
        void CreateTransaction(Transaction transaction);
        void UpdateTransaction(Transaction transaction);
        void DeleteTransaction(int id);
    }
}
