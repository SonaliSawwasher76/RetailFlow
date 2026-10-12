using Microsoft.EntityFrameworkCore;
using RetailFlow.Models;
namespace RetailFlow.Data;
public class RetailFlowDbContext : DbContext
{
    public RetailFlowDbContext(DbContextOptions<RetailFlowDbContext> options) : base(options) { }
    public DbSet<Product> Products => Set<Product>();
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Product>().Property(p => p.UnitPrice).HasPrecision(18, 2);
    }
}
