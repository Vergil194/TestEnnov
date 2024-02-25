using Application.Gateways;
using AutoMapper;
using Domain;
using Domain.Entities;
using MediatR;

namespace Application.UseCases.Queries
{
    public class GetCompanyByUid
    {
        public class Query : IRequest<Result<Company>?>
        {
            public required string Uid { get; set; }
        }

        public class Handler : IRequestHandler<Query, Result<Company>?>
        {
            private readonly IZefixApiPublicServices _apiService;
            private readonly IGeneriqueRepository<Company> _repository;
            private readonly IMapper _mapper;

            public Handler(IZefixApiPublicServices apiService, IGeneriqueRepository<Company> repository, IMapper mapper)
            {
                _apiService = apiService;
                _repository = repository;
                _mapper = mapper;
            }
            public async Task<Result<Company>?> Handle(Query request, CancellationToken cancellationToken)
            {
                var response = await _apiService.GetCompanyByUid(request.Uid);

                if (response == null || !response.Any()) return null;

                var newCompany = _mapper.Map<Company>(response.First());

                var isSuccess =await _repository.AddAsync(newCompany);

                return isSuccess? Result<Company>.Success(newCompany): Result<Company>.Failure("Failed saving company data.");

            }
        }
    }

    
}
