using GraphQL.DataLoader;
using GraphQL.Types;
using GraphQL;
using TreewInc.Application.GraphQL.Abstractions.Services;
using TreewInc.Core.Domain.Entities;

namespace TreewInc.Application.GraphQL.GraphTypes.QueryTypes;

public sealed class SaleQueryType : ObjectGraphType<Sale>
{
	public SaleQueryType(ISaleService service, IDataLoaderContextAccessor accessor)
	{
		Field(s => s.Id);
		Field(s => s.Date);
		Field(s => s.Quantity);
		Field(s => s.TotalPrice);
		Field<ClientQueryType, Client>("client")
			.ResolveAsync(context => 
				accessor.Context.GetOrAddBatchLoader<int, Client>("GetClientsById", service.GetClientsByIdAsync)
					.LoadAsync(context.Source.ClientId));
		Field<ProductQueryType, Product>("product")
			.ResolveAsync(context => 
				accessor.Context.GetOrAddBatchLoader<int, Product>("GetProductsById", service.GetProductsByIdAsync)
					.LoadAsync(context.Source.ProductId));
	}
}
