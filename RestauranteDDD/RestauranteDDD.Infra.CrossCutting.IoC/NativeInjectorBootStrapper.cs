using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RestauranteDDD.Domain.Interfaces;
using RestauranteDDD.Domain.Interfaces.Repositories;
using RestauranteDDD.Domain.Interfaces.Services;
using RestauranteDDD.Domain.Serivces;
using RestauranteDDD.Infra.Data.Context;
using RestauranteDDD.Infra.Data.Repositories;

namespace RestauranteDDD.Infra.CrossCutting.IoC
{
    public class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // Init
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<MainContext>();
            //services.AddDbContext<MainContext>(options => options.UseSqlServer(connectionString));

            // Domain
            services.AddScoped<IPratoService, PratoService>();
            services.AddScoped<IRestauranteService, RestauranteService>();

            // Data
            services.AddScoped<IPratoRepository, PratoRepository>();
            services.AddScoped<IRestauranteRepository, RestauranteRepository>();            
        }
    }
}