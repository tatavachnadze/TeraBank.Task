using Bank.Service.Interfaces.Services;
using Infrastructure.DTO;
using Mediator.Commands;
using Mediator.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TeraBank.API.Models;

namespace TeraBank.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<UserController> _logger;

        public UserController(IMediator mediator, ILogger<UserController> logger)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetUser(int id)
        {
            var user = await _mediator.Send(new GetUserQuery(id));
         
            return Ok(user);
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _mediator.Send(new GetUsersQuery());
            return Ok(users);
        }

        [HttpPost]
        public async Task<IActionResult> RegisterUser(UserModel model)
        {
            var user = await _mediator.Send(new RegisterUserCommand(model.UserName, model.Password));
            return Ok(user);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateUser(UserModel model)
        {
            var user = await _mediator.Send(new UpdateUserCommand(model.UserName));
            return Ok(user);
        }

        [HttpPut]
        public async Task<IActionResult> ResetPassword(User user, string newPassword)
        {
            if (string.IsNullOrEmpty(newPassword)) throw new ArgumentNullException(nameof(newPassword));
            await _mediator.Send(new ResetPasswordCommand(user.Id, newPassword));
            return Ok();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            await _mediator.Send(new DeleteUserCommand(id));
            return Ok();
        }
    }
}
