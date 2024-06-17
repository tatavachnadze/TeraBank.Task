using Bank.Service;
using Bank.Service.Abstraction.Services;
using Bank.Service.Dto;
using Bank.Service.Interfaces.Services;
using MediatR;

namespace Mediator.Commands
{
    public record SignUpUserCommand(string Email, string Password) : IRequest<UserDto?>;

    public class SignUpUserCommandHandler : IRequestHandler<SignUpUserCommand, UserDto?>
    {
        private readonly IUserService _userService;
        private readonly ITokenService _tokenService;

        public SignUpUserCommandHandler(IUserService userService, ITokenService tokenService)
        {
            _userService = userService;
            _tokenService = tokenService;
        }

        public async Task<UserDto?> Handle(SignUpUserCommand request, CancellationToken cancellationToken)
        {

            var registerDto = new RegisterDto { Email = request.Email, Password = request.Password };
            var user = await _userService.RegisterUser(registerDto);
            if (user.Email == registerDto.Email)
            {
                return new UserDto
                {
                    Email = user.Email,
                    Token = _tokenService.CreateToken(user)
                };
            }
            throw new InvalidDataException("Email is already registered");            
        }
    }
}
