using Bank.Service.Interfaces.Services;
using Infrastructure.DTO;
using Mediator.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
        public Task RegisterUser(UserModel model)
        {
            User user = new()
            {
                UserName = model.UserName,
                Password = model.Password
            };
            _userService.CreateUser(user);
            return Task.CompletedTask;
        }

        [HttpPut]
        public Task UpdateUser(User user)
        {
            if (user == null) throw new ArgumentNullException(nameof(user));
            _mediator.UpdateUser(user);
            return Task.CompletedTask;
        }

        [HttpPut]
        public Task ResetPassword(User user, string newPassword)
        {
            if (string.IsNullOrEmpty(newPassword)) throw new ArgumentNullException(nameof(newPassword));
            _mediator.ResetPassword(user.Id, newPassword);
            return Task.CompletedTask;
        }

        [HttpDelete("{id:int}")]
        public Task DeleteUser(int id)
        {
            _mediator.DeleteUser(id);
            return Task.CompletedTask;
        }
    }
}
