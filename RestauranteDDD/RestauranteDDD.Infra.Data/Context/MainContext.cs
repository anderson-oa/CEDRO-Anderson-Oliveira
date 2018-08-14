using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using RestauranteDDD.Domain.Entities;
using RestauranteDDD.Infra.Data.Mappings;
using System.IO;

namespace RestauranteDDD.Infra.Data.Context
{
    public class MainContext : DbContext
    {        
        public DbSet<Prato> Pratos { get; set; }

        public DbSet<Restaurante> Restaurantes { get; set; }        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PratoMap());
            modelBuilder.ApplyConfiguration(new RestauranteMap());

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            optionsBuilder.UseSqlServer(config.GetConnectionString("DefaultConnection"));
        }
    }
}