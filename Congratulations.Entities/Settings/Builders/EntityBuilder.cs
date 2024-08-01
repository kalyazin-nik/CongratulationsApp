using Congratulations.Entities.Settings.Configurations;
using Congratulations.Entities.Settings.Models;
using Microsoft.EntityFrameworkCore;

namespace Congratulations.Entities.Settings.Builders;

public static class EntityBuilder<TEntity>
    where TEntity : BaseEntity
{
    private static Dictionary<string, Table> Tables => TableConfiguration.Tables;
    private static Dictionary<string, Column> Columns => ColumnConfiguration.Columns;

    public static void ChangeEntity(ModelBuilder modelBuilder)
    {
        ChangeTable(modelBuilder);
        ChangeColumns(modelBuilder);
    }

    private static void ChangeTable(ModelBuilder modelBuilder)
    {
        if (Tables.TryGetValue(nameof(TEntity), out var table))
        {
            modelBuilder.Entity<TEntity>().ToTable(table.Name, schema: table.Schema);

            if (table.Constraints is not null)
            {
                foreach (var constraint in table.Constraints)
                {
                    modelBuilder.Entity<TEntity>().ToTable(t => t.HasCheckConstraint(constraint.Name, constraint.Sql));
                }
            }
        }
    }

    private static void ChangeColumns(ModelBuilder modelBuilder)
    {
        foreach (var property in typeof(TEntity).GetProperties())
        {
            if (Columns.TryGetValue(property.Name, out var column))
            {
                if (column.IsIgnore)
                {
                    modelBuilder.Entity<TEntity>().Ignore(property.Name);
                    continue;
                }

                modelBuilder.Entity<TEntity>().Property(property.Name).HasColumnName(column.Name);

                if (column.Type is not null)
                {
                    modelBuilder.Entity<TEntity>().Property(property.Name).HasColumnType(column.Type); 
                }

                if (column.DefaultValueSql is not null)
                {
                    modelBuilder.Entity<TEntity>().Property(property.Name).HasDefaultValueSql(column.DefaultValueSql); 
                }

                if (column.IsValueGeneratedNever)
                {
                    modelBuilder.Entity<TEntity>().Property(property.Name).ValueGeneratedNever();
                    modelBuilder.Entity<TEntity>().HasKey(property.Name);
                    modelBuilder.Entity<TEntity>().HasIndex(property.Name);
                }
            }
        }
    }
}
