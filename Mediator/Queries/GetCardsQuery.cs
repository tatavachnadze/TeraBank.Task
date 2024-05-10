using Bank.Service.Interfaces.Services;
using Domain.Entities;
using MediatR;

namespace Mediator.Queries
{
    public record GetCardsQuery() : IRequest<IQueryable<Card>>;

    public class GetCardsQueryHandler : IRequestHandler<GetCardsQuery, IEnumerable<Card>>
    {
        private readonly ICardService _cardService;

        public GetCardsQueryHandler(ICardService cardService)
        {
            _cardService = cardService;

        }
        public async Task<IEnumerable<Card>> Handle(GetCardsQuery request, CancellationToken cancellationToken)
        {
            return await _cardService.GetCards();
            //await _customerService.SaveAsync(cancellationToken);
        }
    }
}
