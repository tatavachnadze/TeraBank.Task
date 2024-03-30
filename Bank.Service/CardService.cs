using Bank.Service.Interfaces.Repositories;
using Bank.Service.Interfaces.Services;
using Infrastructure.DTO;

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
            Card card = _unitOfWork.CreditCardRepository.Get(cardId);
            if (card != null)
            {
                return Task.FromResult(card);
            }
            else
            {
                throw new InvalidDataException("The cardId couldn't not be found in within the data.");
            }
        }

        public Task<IQueryable<Card>> GetCards()
        {
            var cards = _unitOfWork.CreditCardRepository.Set();
            if (cards != null)
            {
                return Task.FromResult(cards);
            }
            else
            {
                throw new InvalidDataException("The cardId couldn't not be found in within the data.");
            }
        }

        public void CreateCard(Card card)
        {
            if (card == null) throw new ArgumentNullException(nameof(card));
            _unitOfWork.CreditCardRepository.Insert(card);
            _unitOfWork.SaveChanges();
        }

        public void UpdateCard(Card card)
        {
            if (card == null) throw new ArgumentNullException(nameof(card));
            _unitOfWork.CreditCardRepository.Update(card);
            _unitOfWork.SaveChanges();
        }

        public void DeleteCard(int cardId)
        {
            Card card = _unitOfWork.CreditCardRepository.Get(cardId) ?? throw new ArgumentNullException($"The {cardId} does not exist.");
            card.IsActive = false;
            _unitOfWork.CreditCardRepository.Update(card);
            _unitOfWork.SaveChanges();
        }


    }
}
