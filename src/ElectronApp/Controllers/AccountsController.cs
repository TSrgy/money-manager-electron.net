using Microsoft.AspNetCore.Mvc;
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
    }
}
