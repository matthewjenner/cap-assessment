using Microsoft.EntityFrameworkCore;
using CustomerManagementService.Models;

/*
 * ** Note **
 * I am using EF Core to create a new DB using migrations, if we are using an existing
 * DB this will probably not what you want to use, but for ease of showing what is
 * possible, this is the route I would use. Otherwise, things would be a lot more
 * dependent on the environment you use, which is missing the point of this I feel.
 */
namespace CustomerManagementService.Data;
/// <summary>
/// Represents the database context for the Customer Management Service.
/// </summary>
public class CustomerContext(DbContextOptions<CustomerContext> options) : DbContext(options)
{
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<SalesEmployee> SalesEmployees { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<SalesCache> SalesCaches { get; set; }

    /// <summary>
    /// Configures the schema needed for the context.
    /// </summary>
    /// <param name="modelBuilder">The builder used to construct the model for the context.</param>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // SalesEmployee
        modelBuilder.Entity<SalesEmployee>()
            .HasKey(e => e.EmployeeId);

        modelBuilder.Entity<SalesEmployee>()
            .HasOne(e => e.Manager)
            .WithMany()
            .HasForeignKey(e => e.ManagerId);

        // Order
        modelBuilder.Entity<Order>()
            .HasKey(o => o.OrderId);

        modelBuilder.Entity<Order>()
            .HasOne(o => o.Product)
            .WithMany()
            .HasForeignKey(o => o.ProductId);

        modelBuilder.Entity<Order>()
            .HasOne(o => o.Customer)
            .WithMany()
            .HasForeignKey(o => o.CustomerId);

        modelBuilder.Entity<Order>()
            .HasOne(o => o.SalesEmployee)
            .WithMany()
            .HasForeignKey(o => o.EmployeeId);

        // SalesCache
        modelBuilder.Entity<SalesCache>()
            .HasKey(sc => new { sc.Category, sc.Year });

        // Product
        modelBuilder.Entity<Product>()
            .HasKey(p => p.ProductId);

        // Customer
        modelBuilder.Entity<Customer>()
            .HasKey(c => c.CustomerId);
    }
}