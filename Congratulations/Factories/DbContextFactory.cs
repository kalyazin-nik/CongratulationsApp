using Congratulations.Database;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Congratulations.Factories;

internal class DbContextFactory : IDesignTimeDbContextFactory<DataContext>
{
    private static DbContextOptions<DataContext> _options = null!;
    private static DataContext _dataContext = null!;

    internal static DbContextOptions<DataContext> Options => _options ?? GetOptions();
    internal static DataContext DataContext => _dataContext ?? CreateDataContext();

    private static DbContextOptions<DataContext> GetOptions()
    {
        var builder = new ConfigurationBuilder();
        builder.SetBasePath(Directory.GetCurrentDirectory());
        builder.AddJsonFile("appsettings.json");
        var config = builder.Build();
        var connectionString = config.GetConnectionString("PostgresConnection");
        var optionsBuilder = new DbContextOptionsBuilder<DataContext>();

        return _options = optionsBuilder.UseNpgsql(connectionString).Options;
    }

    public DataContext CreateDbContext(string[] args)
    {
        return CreateDataContext();
    }

    internal static DataContext CreateDataContext()
    {
        return _dataContext = new DataContext(Options);
    }
}
