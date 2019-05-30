using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Modern.API.Gateway.Data;
using Modern.Models;

namespace Modern.API.Gateway
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateWebHostBuilder(args).Build();

            using (IServiceScope scope = host.Services.CreateScope())
            {
                ApplicationDbContext context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

                var manufacturerDbEntry = context.Manufacturers.Add(
                  new Manufacturer
                  {
                      Name = "Mercedes",
                  }
                );

                context.SaveChanges();

                context.Cars.AddRange(
                  new Car
                  {
                      ManufacturerId = manufacturerDbEntry.Entity.Id,
                      Name = "A-Class Sedan",
                      Created = new DateTime(2018, 10, 25)
                  },
                  new Car
                  {
                      ManufacturerId = manufacturerDbEntry.Entity.Id,
                      Name = "S-Class",
                      Created = new DateTime(1975, 3, 1)
                  }
                );

                context.SaveChanges();
            }

            host.Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
