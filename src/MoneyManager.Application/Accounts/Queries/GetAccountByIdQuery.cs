using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MoneyManager.Application.Common.Interfaces;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MoneyManager.Application.Accounts.Queries
{
    public class GetAccountByIdQuery : IRequest<AccountDto>
    {
        public long Id { get; set; }
    }

    public class GetAccountByIdQueryHandler : IRequestHandler<GetAccountByIdQuery, AccountDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetAccountByIdQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<AccountDto> Handle(GetAccountByIdQuery request, CancellationToken cancellationToken)
        {
            return await _context.Accounts
                    .AsNoTracking()
                    .Where(x => x.Id == request.Id)
                    .ProjectTo<AccountDto>(_mapper.ConfigurationProvider)
                    .SingleOrDefaultAsync(cancellationToken);
        }
    }
}
