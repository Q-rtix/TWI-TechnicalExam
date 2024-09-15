using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TreewInc.Core.Domain.Entities;

namespace TreewInc.Core.Persistence.Configurations;

public class SaleEntityTypeConfiguration : IEntityTypeConfiguration<Sale>
{

	public void Configure(EntityTypeBuilder<Sale> builder)
	{
		builder.HasKey(e => e.Id);
		
		builder.ToTable("Sales");

		builder.Property(e => e.ClientId)
			.IsRequired();
		builder.Property(e => e.ProductId);
		builder.Property(e => e.Date);
		builder.Property(e => e.TotalPrice)
			.HasColumnType("decimal(18, 2)");
	}
}
