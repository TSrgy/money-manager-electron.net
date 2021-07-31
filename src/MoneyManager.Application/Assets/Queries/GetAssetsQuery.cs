using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MoneyManager.Application.Common.Interfaces;

namespace MoneyManager.Application.Assets.Queries
{
    public class GetAssetsQuery : IRequest<AssetsVm>
    {
        public class GetAssetsQueryHandler : IRequestHandler<GetAssetsQuery, AssetsVm>
        {
            private readonly IApplicationDbContext _context;
            private readonly IMapper _mapper;

            public GetAssetsQueryHandler(IApplicationDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<AssetsVm> Handle(GetAssetsQuery request, CancellationToken cancellationToken)
            {
                var vm = new AssetsVm();

                vm.Assets = await _context.Assets
                    .ProjectTo<AssetDto>(_mapper.ConfigurationProvider)
                    .OrderBy(t => t.Name)
                    .ToListAsync(cancellationToken);

                return vm;
            }
        }
    }
}
