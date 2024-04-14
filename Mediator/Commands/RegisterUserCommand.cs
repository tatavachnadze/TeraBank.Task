using Bank.Service.Interfaces.Services;
using Domain.Entities;
using MediatR;

namespace Mediator.Commands
{
    public record RegisterUserCommand(string UserName, string Password) : IRequest<User>;

    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, User>
    {
        private readonly IUserService _userService;
        public RegisterUserCommandHandler(IUserService userService)
        {
            _userService = userService;
        }
        public async Task<User> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            var user = new User { UserName = request.UserName, Password = request.Password };           

            _userService.CreateUser(user);
            return await _userService.GetUser(user.Id);
        }
    }
}
