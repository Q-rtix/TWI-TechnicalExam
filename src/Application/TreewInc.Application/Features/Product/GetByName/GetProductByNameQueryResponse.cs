namespace TreewInc.Application.Features.Product.GetByName;

public record GetProductByNameQueryResponse(int Id, string Name, string Description, decimal Price, int Stock);
