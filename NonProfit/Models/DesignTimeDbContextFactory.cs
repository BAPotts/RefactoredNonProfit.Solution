using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace NonProfit.Models
{
  public class NonProfitContextFactory : IDesignTimeDbContextFactory<NonProfitContext>
  {
    NonProfitContext IDesignTimeDbContextFactory<NonProfitContext>.CreateDbContext(string[] args)
    {
      IConfigurationRoot configuration = new ConfigurationBuilder()
      .SetBasePath(Directory.GetCurrentDirectory())
      .AddJsonFile("appsettings.json")
      .Build();

      var builder = new DbContextOptionsBuilder<NonProfitContext>();
      var connectionString = configuration.GetConnectionString("DefaultConnection");

      builder.UseMySql(connectionString);
      return new NonProfitContext(builder.Options);
    }
  }
}