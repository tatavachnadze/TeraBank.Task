using Mediator.Commands;
using Mediator.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using TeraBank.API.Models;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
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
        public async Task<IActionResult> RegisterUser([FromBody] UserModel model)
        {
            var user = await _mediator.Send(new RegisterUserCommand(model.UserName, model.Password));
            return Ok(user);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateUser([FromBody] UserModel model)
        {
            var user = await _mediator.Send(new UpdateUserCommand(model.UserName));
            return Ok(user);
        }

        [HttpPut("{id:int}/password")]
        public async Task<IActionResult> ResetPassword(int Id, [FromBody] UserModel model)
        {
            if (string.IsNullOrEmpty(model.Password)) throw new ArgumentNullException(nameof(model.Password));
            await _mediator.Send(new ResetPasswordCommand(Id, model.Password));
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
