using AspNetServer.Data.Classes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace AspNetServer.Data;

internal sealed class AppDbContext : DbContext
{
    public DbSet<SugarClass> Sugars { get; set; }
    public DbSet<FoodClass> Food { get; set; }
    public DbSet<InsulinClass> Insulin { get; set; }
    public DbSet<CatheterClass> Catheters { get; set; }
    public DbSet<DosesClass> Doses { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder) =>
        dbContextOptionsBuilder.UseSqlite("Data Source=./Data/AppDb.db");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var sugarsToSeed = new SugarClass[6];
        var foodToSeed = new FoodClass[6];
        var insulinToSeed = new InsulinClass[6];
        var cathetersToSeed = new CatheterClass[6];
        var dosesToSeed = new List<DosesClass>
        {
            new() { Id = 1, Dose = 1.1, StartTime = "00:00", EndTime = "05:29" },
            new() { Id = 2, Dose = 1.6, StartTime = "05:30", EndTime = "06:59" },
            new() { Id = 3, Dose = 1.7, StartTime = "07:00", EndTime = "11:29" },
            new() { Id = 4, Dose = 1.3, StartTime = "11:30", EndTime = "21:59" },
            new() { Id = 5, Dose = 1.4, StartTime = "22:00", EndTime = "23:59" },
        };

        for (var i = 1; i <= 6; i++)
        {
            sugarsToSeed[i - 1] = new SugarClass
            {
                Id = i,
                Sugar = double.Parse($"5,{i}"),
                InsulinIncreased = 0,
                Time = $"17:0{i - 1}",
            };

            foodToSeed[i - 1] = new FoodClass
            {
                Id = i,
                Time = $"17:0{i - 1}",
                BreadUnits = i + 2,
                Dose = 1.3,
                FoodName = "bread, coffee",
                InsulinPinned = 1.3 * (i + 2)
            };

            insulinToSeed[i - 1] = new InsulinClass
            {
                Id = i,
                Time = $"17:0{i - 1}",
            };

            cathetersToSeed[i - 1] = new CatheterClass
            {
                Id = i,
                Time = $"17:0{i - 1}",
            };
        }

        modelBuilder.Entity<SugarClass>().HasData(sugarsToSeed);
        modelBuilder.Entity<FoodClass>().HasData(foodToSeed);
        modelBuilder.Entity<InsulinClass>().HasData(insulinToSeed);
        modelBuilder.Entity<CatheterClass>().HasData(cathetersToSeed);
        modelBuilder.Entity<DosesClass>().HasData(dosesToSeed);
    }
}