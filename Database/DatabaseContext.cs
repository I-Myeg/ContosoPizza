using ContosoPizza.Models;
using Microsoft.EntityFrameworkCore;

namespace ContosoPizza.Database;

public class DatabaseContext : DbContext
{
    public DbSet<Pizza> Pizzas { get; set; }
    public DbSet<PizzaPlace> PizzaPlaces { get; set; }

    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
    {
    }

    protected void Key(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Pizza>()
            .HasOne(p => p.PizzaPlace)
            .WithMany(pp => pp.Pizzas)
            .HasForeignKey(p => p.PizzaPlaceId);
    }
}