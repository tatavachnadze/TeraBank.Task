using Bank.Service.Interfaces.Services;
using Domain.Entities;
using MediatR;

namespace Mediator.Commands
{
    public record UpdateUserCommand(string UserName) : IRequest<User>;

    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, User>
    {
        private readonly IUserService _userService;
        public UpdateUserCommandHandler(IUserService userService)
        {
            _userService = userService;
        }
        public async Task<User> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var user = new User { UserName = request.UserName};
            _userService.UpdateUser(user);
            return await _userService.GetUser(user.Id);
        }
    }
}
