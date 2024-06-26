﻿using Bank.Service.Interfaces.Services;
using Domain.Abstractions;
using Domain.Entities;

namespace Bank.Service
{
    public sealed class CardService : ICardService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CardService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<Card> GetCard(int cardId)
        {
            Card card = _unitOfWork.CardRepository.Get(cardId);
            if (card != null)
            {
                return Task.FromResult(card);
            }
            else
            {
                throw new InvalidDataException("The cardId couldn't not be found in within the data.");
            }
        }

        public Task<IEnumerable<Card>> GetCards()
        {
            var cards = _unitOfWork.CardRepository.Set() as IEnumerable<Card>;
            if (cards != null)
            {
                return Task.FromResult(cards);
            }
            else
            {
                throw new InvalidDataException("Cards couldn't not be found in within the data.");
            }
        }

        public void CreateCard(Card card)
        {
            if (card == null) throw new ArgumentNullException(nameof(card));
            _unitOfWork.CardRepository.Insert(card);
            _unitOfWork.SaveChanges();
        }

        public void UpdateCard(Card card)
        {
            if (card == null) throw new ArgumentNullException(nameof(card));
            _unitOfWork.CardRepository.Update(card);
            _unitOfWork.SaveChanges();
        }

        public void DeleteCard(int cardId)
        {
            Card card = _unitOfWork.CardRepository.Get(cardId) ?? throw new ArgumentNullException($"The {cardId} does not exist.");
            card.IsActive = false;
            _unitOfWork.CardRepository.Update(card);
            _unitOfWork.SaveChanges();
        }
    }
}
