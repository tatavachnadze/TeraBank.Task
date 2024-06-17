using Bank.Service.Abstraction.Services;
using Mediator.Commands;
using Mediator.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TeraBank.API.Models;

namespace Presentation.Controllers
{
    [Authorize]
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

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _mediator.Send(new GetUsersQuery());
            return Ok(users);
        }

        [HttpPost("SignUp")]
        public async Task<IActionResult> SignUpUserAsync(SignUpModel model)
        {
            var user = await _mediator.Send(new SignUpUserCommand(model.Email, model.Password));
            return Ok(user);
        }
        [HttpPost("SignIn")]
        public async Task<IActionResult> SignInUserAsync(SignInModel model)
        {
            var user = await _mediator.Send(new SignInUserCommand(model.Email, model.Password));
            return Ok(user);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateUser(UserModel model)
        {
            var user = await _mediator.Send(new UpdateUserCommand(model.UserName));
            return Ok(user);
        }

        //[HttpPut("{id:int}/password")]
        //public async Task<IActionResult> ResetPassword(int Id, UserModel model)
        //{
        //    if (string.IsNullOrEmpty(model.Password)) throw new ArgumentNullException(nameof(model.Password));
        //    await _mediator.Send(new ResetPasswordCommand(Id, model.Password));
        //    return Ok();
        //}

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            await _mediator.Send(new DeleteUserCommand(id));
            return Ok();
        }
    }
}
