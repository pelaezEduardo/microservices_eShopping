using AutoMapper;
using Catalog.Application.Queries;
using Catalog.Application.Responses;
using Catalog.Core.Repositories;
using MediatR;

namespace Catalog.Application.Handlers;

public class GetAllBrandsHandler : IRequestHandler<GetAllBrandsQuery, IList<BrandDto>>
{
    private readonly IBrandRepository _repository;
    private readonly IMapper _mapper;

    public GetAllBrandsHandler(IBrandRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    
    public async Task<IList<BrandDto>> Handle(GetAllBrandsQuery request, CancellationToken cancellationToken)
    {
        var brands = await _repository.GetAllBrands();
        var response = _mapper.Map<IList<BrandDto>>(brands);
        return response;
    }
}