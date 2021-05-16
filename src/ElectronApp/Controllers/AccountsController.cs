using Microsoft.AspNetCore.Mvc;
using MoneyManager.Application.Accounts.Commands.CreateAccount;
using MoneyManager.Application.Accounts.Queries;
using System.Threading.Tasks;

namespace ElectronApp.Controllers
{
    public class AccountsController : ApiControllerBase
    {
        public AccountsController()
        {
        }

        [HttpGet]
        public async Task<ActionResult<AccountsVm>> Get()
        {
            return await Mediator.Send(new GetAccountsQuery());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AccountDto>> GetById(long id)
        {
            return await Mediator.Send(new GetAccountByIdQuery
            {
                Id = id
            });
        }

        [HttpPost]
        public async Task<ActionResult<long>> Create(CreateAccountCommand command)
        {
            return await Mediator.Send(command);
        }
    }
}
