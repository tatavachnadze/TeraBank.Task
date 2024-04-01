using Bank.Service.Interfaces.Services;
using Infrastructure.DTO;
using MediatR;

namespace Mediator.Queries
{
    public record GetCardQuery(int Id) : IRequest<Card>;

    public class GetCardQueryHandler : IRequestHandler<GetCardQuery, Card>
    {
        private readonly ICardService _cardService;

        public GetCardQueryHandler(ICardService cardService)
        {
            _cardService = cardService;

        }
        public async Task<Card> Handle(GetCardQuery request, CancellationToken cancellationToken)
        {
            return await _cardService.GetCard(request.Id);
            //await _customerService.SaveAsync(cancellationToken);
        }
    }
}
