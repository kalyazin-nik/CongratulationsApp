using Congratulations.Entities;
using Congratulations.Entities.Settings.Builders;
using Microsoft.EntityFrameworkCore;

namespace Congratulations.Database;

public class DataContext(DbContextOptions<DataContext> options) : DbContext(options)
{
    public DbSet<Employee> Employees { get; set; } = null!;
    public DbSet<Address> Addresses { get; set; } = null!;
    public DbSet<Phone> Phones { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        EntityBuilder<Employee>.ChangeEntity(modelBuilder);
        EntityBuilder<Address>.ChangeEntity(modelBuilder);
        EntityBuilder<Phone>.ChangeEntity(modelBuilder);
    }
}
