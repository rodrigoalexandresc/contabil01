using Fluxo.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

var configuration = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json")
    .Build();

var connectionString = configuration.GetConnectionString("FluxoDbConnection");

var serviceProvider = new ServiceCollection()
    .AddDbContext<FluxoDbContext>(options =>
        options.UseNpgsql(connectionString))
    .BuildServiceProvider();

using var scope = serviceProvider.CreateScope();
var dbContext = scope.ServiceProvider.GetRequiredService<FluxoDbContext>();
Console.WriteLine("Applying migrations...");
dbContext.Database.Migrate();
Console.WriteLine("Migrations applied successfully!");