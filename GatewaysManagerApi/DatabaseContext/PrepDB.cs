using GatewaysManager.Models.Database;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace GatewaysManager.DatabaseContext
{
    public static class PrepDB
    {
        public static void PrepPopulation(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                SeedData(serviceScope.ServiceProvider.GetService<GatewaysManagerContext>());
            }
        }

        public static void SeedData(GatewaysManagerContext context)
        {
            System.Console.WriteLine("Applying Migrations...");
            context.Database.Migrate();
            var gatewayId = new Guid("11223344-5566-7788-99AA-BBCCDDEEFF00");

            if (!context.Gateways.Any())
            {
                System.Console.WriteLine("Adding gateways - seeding...");
                context.Gateways.AddRange(
                    new Gateway() { Id = gatewayId, SerialNumber = "9000", Name = "Mainframe", IPv4 = "255.255.255" },
                    new Gateway() { SerialNumber = "5000", Name = "MainframeBackup", IPv4 = "255.255.255" }
                );
            }
            else
            {
                System.Console.WriteLine("Already have gateway data - not seeding");
            }

            if (!context.Peripherals.Any())
            {
                System.Console.WriteLine("Adding peripherals - seeding...");
                context.Peripherals.AddRange(
                    new Peripheral() { UID = 1, Vendor = "Siemens1", DateCreated = DateTime.Now.ToString(), GatewayId = gatewayId },    
                    new Peripheral() { UID = 1, Vendor = "Siemens2", DateCreated = DateTime.Now.ToString(), GatewayId = gatewayId },    
                    new Peripheral() { UID = 1, Vendor = "Siemens3", DateCreated = DateTime.Now.ToString(), GatewayId = gatewayId },    
                    new Peripheral() { UID = 1, Vendor = "Siemens4", DateCreated = DateTime.Now.ToString(), GatewayId = gatewayId },    
                    new Peripheral() { UID = 1, Vendor = "Siemens5", DateCreated = DateTime.Now.ToString(), GatewayId = gatewayId },    
                    new Peripheral() { UID = 1, Vendor = "Siemens6", DateCreated = DateTime.Now.ToString(), GatewayId = gatewayId },    
                    new Peripheral() { UID = 1, Vendor = "Siemens7", DateCreated = DateTime.Now.ToString(), GatewayId = gatewayId },    
                    new Peripheral() { UID = 1, Vendor = "Siemens8", DateCreated = DateTime.Now.ToString(), GatewayId = gatewayId },    
                    new Peripheral() { UID = 1, Vendor = "Siemens9", DateCreated = DateTime.Now.ToString(), GatewayId = gatewayId },    
                    new Peripheral() { UID = 1, Vendor = "Siemens10", DateCreated = DateTime.Now.ToString(), GatewayId = gatewayId }
                );
            }
            else
            {
                System.Console.WriteLine("Already have peripherals data - not seeding");
            }
            context.SaveChanges();
        }
    }
}
