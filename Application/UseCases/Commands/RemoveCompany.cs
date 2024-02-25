using Domain;
using Domain.Entities;
using MediatR;

namespace Application.UseCases.Commands
{
    public class RemoveCompany
    {
        public class Command : IRequest<Result<Unit>>
        {
            public required string Uid { get; set; }
        }

        public class Handler(IGeneriqueRepository<Company> company) : IRequestHandler<Command, Result<Unit>>
        {
            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                var target = await company.GetByIdAsync(request.Uid);

                if (target == null) return null;

                var isSuccess = await company.DeleteAsync(target);

                if (!isSuccess) return Result<Unit>.Failure("Failed to delete the Company");

                return Result<Unit>.Success(Unit.Value);
            }
        }
    }
}
