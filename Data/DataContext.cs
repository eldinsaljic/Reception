using Hotel.Server.Models;
using Microsoft.EntityFrameworkCore;

namespace Hotel.Server.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Category> Categories { get; set; }
    public DbSet<Reservation> Reservation { get; set; }
    public DbSet<Room> Room { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Category>().HasData(
            new Category
            {
                CategoryID = 1,
                Name = "Garsonjera",
                Description = "Jednokrevetna garsonjera"
            },
            new Category
            {
                CategoryID = 2,
                Name = "Jednosoban",
                Description = "Dvokrevetan stan"
            },
            new Category
            {
                CategoryID = 3,
                Name = "Dvosoban",
                Description = "Cetvorokrevetan"
            }
        );

        modelBuilder.Entity<Room>().HasData(
            new Room
            {
                ID = 1,
                Name = "Fehrat",
                Description = "Dva dana",
                Price = 20m,
                CategoryID = 1
            });
    }
}