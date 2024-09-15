namespace TreewInc.Core.Domain.Entities;

public class Product : Entity
{
	[Obsolete("Parameterless constructors are for EF use only")]
	public Product() => Sales = new HashSet<Sale>();
	
	public Product(string name, string description, decimal price, int stock, ICollection<Sale>? sales = null)
	{
		Name = name;
		Description = description;
		Price = price;
		Stock = stock;
		Sales = sales ?? new HashSet<Sale>();
	}

	public string Name { get; private set; }
	public string Description { get; private set; }
	public decimal Price { get; private set; }
	public int Stock { get; private set; }

	public ICollection<Sale>? Sales { get; private set; }

	public void Update(string name, string? description, decimal price, int stock, ICollection<Sale>? sales = null)
	{
		Name = name;
		Description = description ?? string.Empty;
		Price = price;
		Stock = stock;
		Sales = sales ?? new HashSet<Sale>();
	}

	public void Sell(int quantity)
	{
		if (quantity > Stock)
			throw new InvalidOperationException("Product stock is not enough");
		Stock -= quantity;
	}
}
