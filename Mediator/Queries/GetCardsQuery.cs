using Bank.Service.Interfaces.Services;
using Infrastructure.DTO;
using MediatR;

namespace Mediator.Queries
{
    public record GetCardsQuery() : IRequest<IQueryable<Card>>;

    public class GetCardsQueryHandler : IRequestHandler<GetCardsQuery, IQueryable<Card>>
    {
        private readonly ICardService _cardService;

        public GetCardsQueryHandler(ICardService cardService)
        {
            _cardService = cardService;

        }
        public async Task<IQueryable<Card>> Handle(GetCardsQuery request, CancellationToken cancellationToken)
        {
            return await _cardService.GetCards();
            //await _customerService.SaveAsync(cancellationToken);
        }
    }
}
