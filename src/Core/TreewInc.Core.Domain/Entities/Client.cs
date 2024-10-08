﻿using TreewInc.Core.Domain.Helpers;
using TreewInc.Core.Domain.Models;

namespace TreewInc.Core.Domain.Entities;

public class Client : Entity
{
	[Obsolete("Parameterless constructors are for EF use only")]
	public Client() => Sales = new HashSet<Sale>();
	
	public Client(Name name, string email, PhoneNumber phone, string password, ICollection<Sale>? sales = null)
	{
		Name = name;
		Email = email;
		Phone = phone;
		Sales = sales ?? new HashSet<Sale>();
		Password = PassHelper.HashPassword(password);
	}

	public Name Name { get; set; }
	public string Email { get; set; }
	public PhoneNumber Phone { get; set; }
	public string Password { get => Password; set => PassHelper.HashPassword(value); }

	public ICollection<Sale> Sales { get; private set; }

	public void Update(Name name, string email, PhoneNumber phone, ICollection<Sale>? sales = null)
	{
		Name = name;
		Email = email;
		Phone = phone;
		Sales = sales ?? new HashSet<Sale>();
	}
}
