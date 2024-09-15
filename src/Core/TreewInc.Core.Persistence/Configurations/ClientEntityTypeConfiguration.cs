using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TreewInc.Core.Domain.Entities;
using TreewInc.Core.Domain.Models;

namespace TreewInc.Core.Persistence.Configurations;

public class ClientEntityTypeConfiguration : IEntityTypeConfiguration<Client>
{

	public void Configure(EntityTypeBuilder<Client> builder)
	{
		builder.HasKey(e => e.Id);

		builder.ToTable("Clients");

		builder.Property(e => e.Name)
			.UsePropertyAccessMode(PropertyAccessMode.Property)
			.HasConversion(type => NameToString(type), str => StringToName(str))
			.HasColumnName("FullName")
			.HasMaxLength(155);
		builder.Property(e => e.Email)
			.HasMaxLength(150)
			.IsUnicode(false);
		builder.Property(e => e.Phone)
			.UsePropertyAccessMode(PropertyAccessMode.Property)
			.HasConversion(type => PhoneToString(type), str => StringToPhoneNumber(str))
			.HasColumnName("PhoneNumber")
			.HasMaxLength(15);
		builder.HasMany(client => client.Sales)
			.WithOne(sale => sale.Client)
			.HasForeignKey(sale => sale.ClientId);
	}

	private static string NameToString(Name name)
		=> name.MiddleName is null
			? $"{name.FirstName} {name.LastName}"
			: $"{name.FirstName} {name.MiddleName} {name.LastName}";
	
	private static Name StringToName(string name) => name.Split(' ') switch
	{
		[var firstName, var lastName] => new Name(firstName, lastName),
		[var firstName, var middleName, var lastName] => new Name(firstName, lastName, middleName),
		_ => throw new ArgumentException("Unsupported name format.")
	};

	private static string PhoneToString(PhoneNumber phoneNumber)
		=> $"{phoneNumber.CountryCode} {phoneNumber.Number}";

	private static PhoneNumber StringToPhoneNumber(string phoneNumber)
		=> phoneNumber.Split(' ') switch
		{
			[var countryCode, var number] => new PhoneNumber(countryCode, number),
			_ => throw new ArgumentException("Unsupported phone number format.")
		};
}
