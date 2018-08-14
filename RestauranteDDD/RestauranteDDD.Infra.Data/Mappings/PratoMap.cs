using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RestauranteDDD.Domain.Entities;

namespace RestauranteDDD.Infra.Data.Mappings
{
    public class PratoMap : IEntityTypeConfiguration<Prato>
    {
        public void Configure(EntityTypeBuilder<Prato> builder)
        {
            builder.HasKey(p => p.PratoId);

            builder.Property(p => p.PratoId)
                   .ValueGeneratedOnAdd();

            builder.Property(p => p.Nome)
                   .HasMaxLength(200)
                   .IsRequired();

            builder.Property(p => p.Preco)
                .HasColumnType("money")
                .IsRequired();
        }
    }
}