using GraphQL.DataLoader;
using GraphQL.Types;
using TreewInc.Application.GraphQL.Abstractions.Services;
using TreewInc.Core.Domain.Entities;

namespace TreewInc.Application.GraphQL.GraphTypes.QueryTypes;

public sealed class ProductQueryType : ObjectGraphType<Product>
{
	public ProductQueryType(IProductService service, IDataLoaderContextAccessor accessor)
	{
		Field(p => p.Id);
		Field(p => p.Name);
		Field(p => p.Description);
		Field(p => p.Price);
		Field(p => p.Stock);
		Field<ListGraphType<SaleQueryType>, IEnumerable<Sale>>()
			.Name("sales")
			.ResolveAsync(context => 
				accessor.Context.GetOrAddCollectionBatchLoader<int, Sale>("GetSalesByProductIds", service.GetSalesByProductIdsAsync)
					.LoadAsync(context.Source.Id));
	}
}
