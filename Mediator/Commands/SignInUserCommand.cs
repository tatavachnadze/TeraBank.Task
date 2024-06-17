using Bank.Service.Dto;
using MediatR;
using Bank.Service.Abstraction.Services;
using Bank.Service.Interfaces.Services;

namespace Mediator.Commands
{
    public record SignInUserCommand(string Email, string Password) : IRequest<UserDto?>;

    public class SignInUserCommandHandler : IRequestHandler<SignInUserCommand, UserDto?>
    {
        private readonly IUserService _userService;
        private readonly ITokenService _tokenService;

        public SignInUserCommandHandler(IUserService userService, ITokenService tokenService)
        {
            _userService = userService;
            _tokenService = tokenService;
        }

        public async Task<UserDto> Handle(SignInUserCommand request, CancellationToken cancellationToken)
        {
            if (request.Email == null) throw new ArgumentNullException(nameof(request.Email));
            if (request.Password == null) throw new ArgumentNullException(nameof(request.Password));
            var user = await _userService.Login(request.Email, request.Password);
            return new UserDto
            {
                Email = user.Email,
                Token = _tokenService.CreateToken(user)
            };


            //if (idpUser is { UserName: not null } && await _userManager.CheckPasswordAsync(idpUser, request.Password))
            //{
            //    return await _tokenService.GenerateJwtToken(idpUser);
            //}

            //return null;
        }
    }
}
