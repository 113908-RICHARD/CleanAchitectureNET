using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Configuration;
using Microsoft.Extensions.Configuration;

namespace Persistence.repositories
{
    public class LeaveManagementDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var builder = new DbContextOptionsBuilder<ApplicationDbContext> ();
            var connectionString = configuration.GetConnectionString("DBconnection");
            builder.UseNpgsql(connectionString);

            return new ApplicationDbContext(builder.Options);
                
          
                
        }
    }
}
