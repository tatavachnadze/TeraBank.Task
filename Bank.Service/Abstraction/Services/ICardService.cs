using Domain.Entities;

namespace Bank.Service.Interfaces.Services
{
    public interface ICardService
    {
        Task<Card> GetCard(int id);
        Task<IEnumerable<Card>> GetCards();
        void CreateCard(Card card);
        void UpdateCard(Card card);
        void DeleteCard(int cardId);
    }
}
