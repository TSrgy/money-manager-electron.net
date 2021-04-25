using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MoneyManager.Application.Common.Interfaces;

namespace MoneyManager.Application.Accounts.Queries
{
    public class GetAccountsQuery : IRequest<AccountsVm>
    {
    }

    public class GetAccountsQueryHandler : IRequestHandler<GetAccountsQuery, AccountsVm>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetAccountsQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<AccountsVm> Handle(GetAccountsQuery request, CancellationToken cancellationToken)
        {
            return new AccountsVm
            {
                Accounts = await _context.Accounts
                    .AsNoTracking()
                    .ProjectTo<AccountDto>(_mapper.ConfigurationProvider)
                    .OrderBy(x => x.Id)
                    .ToListAsync(cancellationToken)
            };
        }
    }
}
