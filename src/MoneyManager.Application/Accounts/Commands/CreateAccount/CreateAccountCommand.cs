using MediatR;
using MoneyManager.Application.Common.Interfaces;
using MoneyManager.Domain.Entities;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MoneyManager.Application.Accounts.Commands.CreateAccount
{
    public class CreateAccountCommand : IRequest<long>
    {
        public string Name { get; set; }

        public AccountType AccountType { get; set; }

        public decimal InitialBalance { get; set; }

        public string Notes { get; set; }

        public long CurrencyId { get; set; }
    }

    public class CreateAccountCommandHandler : IRequestHandler<CreateAccountCommand, long>
    {
        private readonly IApplicationDbContext _context;

        public CreateAccountCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<long> Handle(CreateAccountCommand request, CancellationToken cancellationToken)
        {
            var currency = _context.Currencies.Single(x => x.Id == request.CurrencyId);

            var entity = new Account(request.Name, request.AccountType, request.InitialBalance, currency);

            _context.Accounts.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }

}
