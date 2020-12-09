using MediatR;
using MoneyManager.Application.Common.Interfaces;
using MoneyManager.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MoneyManager.Application.Assets.Commands.CreateAsset
{
    public class CreateAssetCommand : IRequest<long>
    {
        public string Name { get; set; }
        public class CreateAssetCommandHandler : IRequestHandler<CreateAssetCommand, long>
        {
            private readonly IApplicationDbContext _context;
            public CreateAssetCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<long> Handle(CreateAssetCommand request, CancellationToken cancellationToken)
            {
                var entity = new Asset
                {
                    Name = request.Name
                };

                _context.Assets.Add(entity);

                await _context.SaveChangesAsync(cancellationToken);

                return entity.Id;
            }
        }
    }
}
