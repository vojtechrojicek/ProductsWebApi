using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductsWebApi.Data.Entities;

namespace ProductsWebApi.Data.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .IsRequired()
                .ValueGeneratedNever();

            builder.Property(x => x.Name)
                .IsRequired();

            builder.Property(x => x.ImgUri)
                .IsRequired();

            builder.Property(x => x.Price)
                .IsRequired()
                .HasColumnType("decimal(18,2)");
        }
    }
}
