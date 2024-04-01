using Bank.Service.Interfaces.Services;
using Infrastructure.DTO;
using Mediator.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace TeraBank.Task.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<AccountController> _logger;

        public AccountController(IMediator mediator, ILogger<AccountController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetAccount(int id)
        {
            var account = await _mediator.Send(new GetAccountQuery(id));
            return Ok(account);
        }

        [HttpGet]
        public async Task<IActionResult> GetAccounts()
        {
            var accounts = await _mediator.Send(new GetCardsQuery());

            return Ok(accounts);
        }

        [HttpPost]
        public Task CreateAccount(AccountModel accountModel)
        {
            Account account = new()
            {
                Amount = accountModel.Amount,
                IBAN = accountModel.IBAN,
            };
            _accountService.CreateAccount(account);
            return Task.CompletedTask;
        }

        [HttpPut]
        public Task UpdateAccount(Account account)
        {
            if (account == null) throw new ArgumentNullException(nameof(account));
            _accountService.UpdateAccount(account);
            return Task.CompletedTask;
        }

        [HttpPut("{id:int}")]
        public Task SuspendAccount(int id)
        {
            _accountService.SuspendAccount(id);
            return Task.CompletedTask;
        }

        [HttpPut("{id:int}")]
        public Task ResumeAccount(int id)
        {
            _accountService.ResumeAccount(id);
            return Task.CompletedTask;
        }

        [HttpDelete("{id:int}")]
        public Task DeleteAccount(int id)
        {
            _accountService.DeleteAccount(id);
            return Task.CompletedTask;
        }
    }
}
