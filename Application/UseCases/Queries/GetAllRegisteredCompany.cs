using Domain;
using Domain.Entities;
using MediatR;

namespace Application.UseCases.Queries
{
    public class GetAllRegisteredCompany
    {
        public class Query: IRequest<Result<List<Company>>> { }
        public class Handler(IGeneriqueRepository<Company> company) : IRequestHandler<Query, Result<List<Company>>>
        {
            public async Task<Result<List<Company>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var companies = await company.GetAllAsync();

                return Result<List<Company>>.Success(companies);
            }
        }
    }
}
