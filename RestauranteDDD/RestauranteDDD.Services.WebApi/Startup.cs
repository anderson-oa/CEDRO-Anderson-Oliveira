using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using RestauranteDDD.Infra.CrossCutting.IoC;
using Swashbuckle.AspNetCore.Swagger;

namespace RestauranteDDD.Services.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            RegisterServices(services);

            //services.AddCors(options => options.AddPolicy("AllowSpecificOrigin", builder => builder.WithOrigins("https://localhost:44383")));

            services.AddCors(options =>
            {
                options.AddPolicy("AllowAll", builder =>
                {
                    builder.AllowAnyOrigin()
                           .AllowAnyMethod()
                           .AllowAnyHeader()
                           .AllowCredentials();
                });
            });

            services.AddMvc()
                    .SetCompatibilityVersion(CompatibilityVersion.Version_2_1)
                    .AddMvcOptions(options =>
                    {
                        options.Filters.Add(new ProducesAttribute("application/json"));
                    })
                    .AddJsonOptions(options =>
                    {
                        options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                        options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
                    });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info
                {
                    Version = "v1",                    
                    Title = "Web API, Restaurante - Anderson Oliveira",
                    Description = "A avaliação prática é a construção de um sistema simples de restaurante.",
                    TermsOfService = "None",
                    Contact = new Contact
                    {
                        Name = "Anderson Oliveira",
                        Email = "andderson147@hotmail.com",
                    }
                });                
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c => {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Web API, Restaurante - Anderson Oliveira");
                c.RoutePrefix = string.Empty;
            });
            //app.UseCors("AllowSpecificOrigin");
            app.UseCors("AllowAll");
            app.UseHttpsRedirection();
            app.UseMvc();
        }

        private void RegisterServices(IServiceCollection services)
        {
            NativeInjectorBootStrapper.RegisterServices(services);
        }
    }
}