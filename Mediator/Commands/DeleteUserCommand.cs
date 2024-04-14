using Bank.Service.Interfaces.Services;
using MediatR;

namespace Mediator.Commands
{
    public record DeleteUserCommand(int Id) : IRequest;

    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand>
    {
        private readonly IUserService _userService;
        public DeleteUserCommandHandler(IUserService userService)
        {
            _userService = userService;
        }
        public async Task Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            await Task.Run(() => { _userService.DeleteUser(request.Id); }, cancellationToken);
        }
    }
}
