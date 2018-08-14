using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RestauranteDDD.Domain.Entities;

namespace RestauranteDDD.Infra.Data.Mappings
{
    public class RestauranteMap : IEntityTypeConfiguration<Restaurante>
    {
        public void Configure(EntityTypeBuilder<Restaurante> builder)
        {
            builder.HasKey(r => r.RestauranteId);

            builder.Property(r => r.RestauranteId)
                   .ValueGeneratedOnAdd();

            builder.Property(r => r.Nome)
                   .HasMaxLength(200)
                   .IsRequired();
        }
    }
}