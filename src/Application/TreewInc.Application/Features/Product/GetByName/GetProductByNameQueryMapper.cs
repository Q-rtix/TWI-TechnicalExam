using Riok.Mapperly.Abstractions;

namespace TreewInc.Application.Features.Product.GetByName;

[Mapper]
public static partial class GetProductByNameQueryMapper
{
	public static partial GetProductByNameQueryResponse MapToGetProductByNameQueryResponse(this Core.Domain.Entities.Product product);
}
