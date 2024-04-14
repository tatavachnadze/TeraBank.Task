using Mediator.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CardController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CardController(IMediator mediator)
        {
            _mediator = mediator;
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

        //[HttpPost]
        //    public Task CreateCard(CardModel model)
        //    {
        //        Account account = new()
        //        {
        //            Amount = accountModel.Amount,
        //            IBAN = accountModel.IBAN,
        //        };
        //        _accountService.CreateAccount(account);
        //        return Task.CompletedTask;
        //    }

        //    [HttpPut]
        //    public Task UpdateCard(CardModel model)
        //    {
        //        if (account == null) throw new ArgumentNullException(nameof(account));
        //        _accountService.UpdateAccount(account);
        //        return Task.CompletedTask;
        //    }

        //    [HttpPut("{id:int}")]
        //    public Task SuspendCard(int id)
        //    {
        //        _accountService.SuspendAccount(id);
        //        return Task.CompletedTask;
        //    }

        //    [HttpPut("{id:int}")]
        //    public Task ResumeCard(int id)
        //    {
        //        _accountService.ResumeAccount(id);
        //        return Task.CompletedTask;
        //    }

        //    [HttpDelete("{id:int}")]
        //    public Task DeleteCard(int id)
        //    {
        //        _accountService.DeleteAccount(id);
        //        return Task.CompletedTask;
        //    }
        
    }
}
