namespace TreewInc.Core.Domain.Entities;

public class Sale : Entity
{
	public int ClientId { get; private set; }
	public Client Client { get; private set; }
	
	public int ProductId { get; private set; }
	public Product Product { get; private set; }
	public int Quantity { get; private set; }
	public DateTime Date { get; private set; }
	public decimal TotalPrice { get; private set; }

	[Obsolete("Parameterless constructors are for EF use only")]
	public Sale()
	{
		TotalPrice = 0;
	}

	public Sale(Client client, Product product, int quantity)
	{
		Client = client;
		ClientId = client.Id;
		Product = product;
		ProductId = product.Id;
		Quantity = quantity;
		Date = DateTime.UtcNow;
		TotalPrice = product.Price * quantity;
		Product.Sell(quantity);
	}
}
