using Bank.Service.Interfaces.Services;
using Infrastructure.DTO;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
