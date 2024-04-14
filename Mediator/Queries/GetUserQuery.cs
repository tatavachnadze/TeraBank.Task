using Bank.Service.Interfaces.Services;
using Domain.Entities;
using MediatR;

namespace Mediator.Queries
{
    public record GetUserQuery(int Id) : IRequest<User>;

    public class GetUserQueryHandler : IRequestHandler<GetUserQuery, User>
    {
        private readonly IUserService _userService;

        public GetUserQueryHandler(IUserService userService)
        {
            _userService = userService;

        }
        public async Task<User> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            return await _userService.GetUser(request.Id);
            //await _userService.SaveAsync(cancellationToken);
        }
    }
}
