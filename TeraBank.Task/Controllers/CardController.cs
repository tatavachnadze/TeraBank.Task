using Infrastructure.DTO;
using Mediator.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace TeraBank.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CardController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<CardController> _logger;

        public CardController(IMediator mediator, ILogger<CardController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetCard(int id)
        {
            var card = await _mediator.Send(new GetCardQuery(id));
            return Ok(card);
        }

        [HttpGet]
        public async Task<IActionResult> GetCards()
        {
            var cards = await _mediator.Send(new GetCardsQuery());

            return Ok(cards);
        }

        [HttpPost]
        public Task CreateCard(CardModel accountModel)
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
