using Bank.Service;
using Bank.Service.Interfaces.Services;
using Infrastructure.DTO;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
