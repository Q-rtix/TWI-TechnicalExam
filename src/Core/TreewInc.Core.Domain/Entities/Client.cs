using TreewInc.Core.Domain.Models;

namespace TreewInc.Core.Domain.Entities;

public class Client : Entity
{
	public Client(Name name, string email, PhoneNumber phone)
	{
		Name = name;
		Email = email;
		Phone = phone;
	}

	public Name Name { get; private set; }
	public string Email { get; private set; }
	public PhoneNumber Phone { get; private set; }
}
