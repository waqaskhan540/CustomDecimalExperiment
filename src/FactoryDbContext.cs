using Microsoft.EntityFrameworkCore;

namespace WebApi;

public class FactoryDbContext : DbContext
{
    public DbSet<ProductionHistory> ProductionHistory { get; set; }
    public FactoryDbContext(DbContextOptions<FactoryDbContext> options):base(options)
    {
        
    }

    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        configurationBuilder
            .Properties<StrictlyRoundedDecimal>()
            .HaveConversion<StrictlyRoundedDecimalToDecimalConverter>();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ProductionHistory>()
            .Property(x => x.TotalProduction)
            .HasConversion(
                v => (decimal)v,
                v => v);
        
        modelBuilder.Entity<ProductionHistory>()
            .Property(x => x.Price)
            .HasConversion(
                v => (decimal)v,
                v => v);
        
        modelBuilder.Entity<ProductionHistory>()
            .HasData(new[]
            {
                new ProductionHistory(34.555555555m, 0.1243333455m),
                new ProductionHistory(12.32654655m, 98.34343434m),
                new ProductionHistory(72.87947584m,49.495678404m),
                new ProductionHistory(72.879434384m,49.495678404m),
                new ProductionHistory(72.87947584m,49.495678404m),
                new ProductionHistory(72.873434584m,49.4956734344m),
                new ProductionHistory(72.87947584m,49.4956734344m),
                new ProductionHistory(72.8794347584m,49.495678403344m),
            });
    }
}


public class ProductionHistory
{
    public ProductionHistory(StrictlyRoundedDecimal totalProduction, StrictlyRoundedDecimal price)
    {
        Id = Guid.NewGuid();
        TotalProduction = totalProduction;
        Price = price;
    }

    public ProductionHistory()
    {
        
    }
    public Guid Id { get; set; }
    public StrictlyRoundedDecimal TotalProduction { get; set; }
    public StrictlyRoundedDecimal Price { get; set; }
}