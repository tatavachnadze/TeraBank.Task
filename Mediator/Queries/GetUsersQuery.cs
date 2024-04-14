using Bank.Service.Interfaces.Services;
using Domain.Entities;
using MediatR;

namespace Mediator.Queries
{
    public record GetUsersQuery() : IRequest<IQueryable<User>>;

    public class GetUsersQueryHandler : IRequestHandler<GetUsersQuery, IQueryable<User>>
    {
        private readonly IUserService _userService;

        public GetUsersQueryHandler(IUserService userService)
        {
            _userService = userService;

        }
        public async Task<IQueryable<User>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
        {
            return await _userService.GetUsers();
            //await _userService.SaveAsync(cancellationToken);
        }
    }
}
