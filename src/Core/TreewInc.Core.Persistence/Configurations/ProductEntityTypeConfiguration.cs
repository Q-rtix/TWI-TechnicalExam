using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TreewInc.Core.Domain.Entities;

namespace TreewInc.Core.Persistence.Configurations;

public class ProductEntityTypeConfiguration : IEntityTypeConfiguration<Product>
{

	public void Configure(EntityTypeBuilder<Product> builder)
	{
		builder.HasKey(e => e.Id);
		
		builder.ToTable("Products");

		builder.Property(e => e.Name)
			.IsRequired()
			.HasMaxLength(150)
			.IsUnicode(false);
		builder.Property(e => e.Description)
			.HasMaxLength(512)
			.IsUnicode(false);
		builder.Property(e => e.Price)
			.IsRequired()
			.HasColumnType("decimal(18, 2)");
		builder.Property(e => e.Stock)
			.IsRequired();
		builder.HasMany(product => product.Sales)
			.WithOne(sale => sale.Product)
			.HasForeignKey(sale => sale.ProductId);
	}
}
