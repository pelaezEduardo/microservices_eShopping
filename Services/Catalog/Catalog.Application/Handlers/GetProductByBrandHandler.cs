using Catalog.Application.Mappers;
using Catalog.Application.Queries;
using Catalog.Application.Responses;
using Catalog.Core.Repositories;
using MediatR;

namespace Catalog.Application.Handlers;

public class GetProductByBrandHandler : IRequestHandler<GetProductByBrandQuery, IList<ProductDto>>
{
    private readonly IProductRepository _repository;

    public GetProductByBrandHandler(IProductRepository repository)
    {
        _repository = repository;
    }

    public async Task<IList<ProductDto>> Handle(GetProductByBrandQuery request, CancellationToken cancellationToken)
    {
        var product = await _repository.GetProductByBrand(request.brandName);
        var response = CatalogMapper.mapper.Map<IList<ProductDto>>(product);
        return response;
    }
}