using Domain.Abstractions;
using Infrastructure.Repositories;

namespace Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BankDbContext _context;
        private readonly Lazy<IAccountRepository> _accountRepository;
        private readonly Lazy<ICustomerRepository> _customerRepository;
        private readonly Lazy<IUserRepository> _userRepository;
        private readonly Lazy<ICardRepository> _cardRepository;
        private readonly Lazy<ITransactionRepository> _transactionRepository;
       

        public UnitOfWork(BankDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _accountRepository = new Lazy<IAccountRepository>(() => new AccountRepository(context));
            _customerRepository = new Lazy<ICustomerRepository>(() => new CustomerRepository(context));
            _userRepository = new Lazy<IUserRepository>(() => new UserRepository(context));
            _cardRepository = new Lazy<ICardRepository>(() => new CardRepository(context));
            _transactionRepository = new Lazy<ITransactionRepository>(() => new TransactionRepository(context));
        }

        public IAccountRepository AccountRepository => _accountRepository.Value;
        public ICustomerRepository CustomerRepository => _customerRepository.Value;
        public IUserRepository UserRepository => _userRepository.Value;
        public ICardRepository CardRepository => _cardRepository.Value;
        public ITransactionRepository TransactionRepository => _transactionRepository.Value;
        public int SaveChanges() => _context.SaveChanges();
        public void BeginTransaction()
        {
            if (_context.Database.CurrentTransaction != null)
            {
                throw new InvalidOperationException("A Transaction is already in progress.");
            }

            _context.Database.BeginTransaction();
        }

        public void CommitTransaction()
        {
            try
            {
                _context.Database.CurrentTransaction?.Commit();
            }
            catch
            {
                _context.Database.CurrentTransaction?.Rollback();
                throw;
            }
            finally
            {
                _context.Database.CurrentTransaction?.Dispose();
            }
        }

        public void RollBack()
        {
            try
            {
                _context.Database.CurrentTransaction?.Rollback();
            }
            finally
            {
                _context.Database.CurrentTransaction?.Dispose();
            }
        }

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
