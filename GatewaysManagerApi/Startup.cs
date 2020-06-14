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
        }

        private static void RegisterBusinessLogicServices(IServiceCollection services)
        {
            services.AddTransient<IPeripheralService, PeripheralService>(); 
            services.AddTransient<IGatewayService, GatewayService>(); 
        }

        private static void RegisterRepositories(IServiceCollection services)
        {
            services.AddTransient<IPeripheralRepository, PeripheralRepository>(); 
            services.AddTransient<IGatewayRepository, GatewayRepository>(); 
        }

        private static void RegisterFactories(IServiceCollection services)
        {
            services.AddTransient<IPeripheralFactory, PeripheralFactory>();
            services.AddTransient<IGatewayFactory, GatewayFactory>();
            services.AddTransient<IStatusCodeResultFactory, StatusCodeResultFactory>();
        }

        private static void RegisterDataMappers(IServiceCollection services)
        {
            services.AddTransient<IPeripheralDataMapper, PeripheralDataMapper>();
        }
    }
}
