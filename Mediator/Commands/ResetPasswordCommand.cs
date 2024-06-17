using Bank.Service.Interfaces.Services;
using Domain.Entities;
using MediatR;

namespace Mediator.Commands
{
    //public record ResetPasswordCommand(int Id, string newPassword) : IRequest;

    //public class ResetPasswordCommandHandler : IRequestHandler<ResetPasswordCommand>
    //{
    //    private readonly IUserService _userService;
    //    public ResetPasswordCommandHandler(IUserService userService)
    //    {
    //        _userService = userService;
    //    }
    //    public async Task Handle(ResetPasswordCommand request, CancellationToken cancellationToken)
    //    {
    //        var user = new User { Password = request.newPassword };
    //        await Task.Run(() => { _userService.ResetPassword(request.Id, request.newPassword); }, cancellationToken);
    //    }
    //}
}
