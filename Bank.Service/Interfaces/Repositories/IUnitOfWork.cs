
namespace Bank.Service.Interfaces.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        IAccountRepository AccountRepository { get; }
        ICustomerRepository CustomerRepository { get; }
        ICardRepository CardRepository { get; }
        ITransactionRepository TransactionRepository { get; }  
        int SaveChanges();
        void BeginTransaction();
        void CommitTransaction();
        void RollBack();
    }
}
