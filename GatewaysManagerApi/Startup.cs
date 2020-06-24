using GatewaysManager.DatabaseContext;
using GatewaysManager.Factories;
using GatewaysManager.Factories.Interfaces;
using GatewaysManager.Mappers;
using GatewaysManager.Mappers.Interfaces;
using GatewaysManager.Repositories;
using GatewaysManager.Repositories.Interfaces;
using GatewaysManager.Services;
using GatewaysManager.Services.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace GatewaysManager
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Gateways Manager", Version = "v1" });
            });

            //This is for Docker sql container image
            //var server = Configuration["DBServer"] ?? "localhost";
            //var port = Configuration["DBPort"] ?? "1433";
            //var user = Configuration["DBUser"] ?? "SA";
            //var password = Configuration["DBPassword"] ?? "Pa55w0rd2020";
            //var database = Configuration["Database"] ?? "GatewaysManager";

            //services.AddDbContext<GatewaysManagerContext>(options =>
            //    options.UseSqlServer($"Server={server},{port}; Initial Catalog={database}; User ID={user}; Password={password}")
            //);

            //This is for localhost development
            services.AddDbContext<GatewaysManagerContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            RegisterBusinessLogicServices(services);
            RegisterDataMappers(services);
            RegisterRepositories(services);
            RegisterFactories(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Gateways Manager");
            });
            PrepDB.PrepPopulation(app);
        }

        private static void RegisterBusinessLogicServices(IServiceCollection services)
        {
            services.AddSingleton<IPeripheralService, PeripheralService>(); 
            services.AddSingleton<IGatewayService, GatewayService>(); 
        }

        private static void RegisterRepositories(IServiceCollection services)
        {
            services.AddScoped<IPeripheralRepository, PeripheralRepository>(); 
            services.AddScoped<IGatewayRepository, GatewayRepository>(); 
        }

        private static void RegisterFactories(IServiceCollection services)
        {
            services.AddSingleton<IPeripheralFactory, PeripheralFactory>();
            services.AddSingleton<IGatewayFactory, GatewayFactory>();
            services.AddSingleton<IStatusCodeResultFactory, StatusCodeResultFactory>();
        }

        private static void RegisterDataMappers(IServiceCollection services)
        {
            services.AddSingleton<IPeripheralDataMapper, PeripheralDataMapper>();
        }
    }
}
