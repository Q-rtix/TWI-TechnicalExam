using TreewInc.Application.Abstractions.Messaging;

namespace TreewInc.Application.Features.Products.SearchBy;

public record SearchProductByNameQuery(string? Name, string? Description, decimal? MinPrice, decimal? MaxPrice, int? MinStock, int? MaxStock) 
	: IQuery<SearchProductByNameQueryResponse>;