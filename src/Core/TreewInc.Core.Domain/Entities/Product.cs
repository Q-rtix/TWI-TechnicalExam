using TreewInc.Core.Domain.Models;

namespace TreewInc.Core.Domain.Entities;

public sealed class Product : Entity
{
	public Product(string name, string description, decimal price, int stock)
	{
		Name = name;
		Description = description;
		Price = price;
		Stock = stock;
	}

	public string Name { get; private set; }
	public string Description { get; private set; }
	public decimal Price { get; private set; }
	public int Stock { get; private set; }

	public void Update(string name, string? description, decimal price, int stock)
	{
		Name = name;
		Description = description ?? string.Empty;
		Price = price;
		Stock = stock;
	}
}
