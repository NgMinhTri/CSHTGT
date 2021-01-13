using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CSHTGT.Data.Context
{
    public class CSHTGTDbContextFactory : IDesignTimeDbContextFactory<CSHTGTDbContext>
    {
        public CSHTGTDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = "Server=.;Database=CSHTGT;Trusted_Connection=True;";//configuration.GetConnectionString("CSHTGTDb");

            var optionsBuilder = new DbContextOptionsBuilder<CSHTGTDbContext>();
            optionsBuilder.UseSqlServer(connectionString);
            return new CSHTGTDbContext(optionsBuilder.Options);


        }


    }
}
