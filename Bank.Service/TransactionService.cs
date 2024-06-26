﻿using Bank.Service.Interfaces.Services;
using Domain.Abstractions;
using Domain.Entities;

namespace Bank.Service
{
    public sealed class TransactionService : ITransactionService
    {
        private readonly IUnitOfWork _unitOfWork;

        public TransactionService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<Transaction> GetTransaction(int id)
        {
            Transaction transaction = _unitOfWork.TransactionRepository.Get(id);
            if (transaction != null)
            {
                return Task.FromResult(transaction);
            }
            else
            {
                throw new InvalidDataException("The TransactionId couldn't not be found in within the data.");
            }
        }

        public Task<IEnumerable<Transaction>> GetTransactions()
        {
            var transactions = _unitOfWork.TransactionRepository.Set() as IEnumerable<Transaction>;
            if (transactions != null)
            {
                return Task.FromResult(transactions);
            }
            else
            {
                throw new InvalidDataException("Transactions couldn't not be found in within the data.");
            }
        }

        public void CreateTransaction(Transaction transaction)
        {
            if (transaction == null) throw new ArgumentNullException(nameof(transaction));
            _unitOfWork.TransactionRepository.Insert(transaction);
            _unitOfWork.SaveChanges();
        }

        public void UpdateTransaction(Transaction transaction)
        {
            if (transaction == null) throw new ArgumentNullException(nameof(transaction));
            _unitOfWork.TransactionRepository.Update(transaction);
            _unitOfWork.SaveChanges();
        }

        public void DeleteTransaction(int id)
        {
            Transaction transaction = _unitOfWork.TransactionRepository.Get(id) ?? throw new ArgumentNullException($"The {id} does not exist.");
            transaction.IsDeleted = true;
            _unitOfWork.TransactionRepository.Update(transaction);
            _unitOfWork.SaveChanges();
        }
    }
}
