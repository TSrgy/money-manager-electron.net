using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MoneyManager.Application.Common.Interfaces;
using MoneyManager.Domain.Entities;

namespace MoneyManager.Application.Assets.Commands.CreateAsset
{
    public class CreateAssetCommand : IRequest<long>
    {
        public string Name { get; set; }

        public DateTime Date { get; set; }

        public decimal Value { get; set; }

        public string Notes { get; set; }

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
                    Name = request.Name,
                    StartDate = request.Date,
                    Value = request.Value,
                    Notes = request.Notes
                };

                _context.Assets.Add(entity);

                await _context.SaveChangesAsync(cancellationToken);

                return entity.Id;
            }
        }
    }
}
