using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace applestore.Data.EF {
    public class AppleDbContextFactory : IDesignTimeDbContextFactory<AppleDbContext> {
        public AppleDbContext CreateDbContext(string[] args) {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var optionsBuilder = new DbContextOptionsBuilder<AppleDbContext>();
            optionsBuilder.UseNpgsql(configuration.GetConnectionString("AppleStoreConnection"));

            return new AppleDbContext(optionsBuilder.Options);
        }
    }
}