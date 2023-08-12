#region

using Microsoft.EntityFrameworkCore;
using NPWalks.API.Models.Domain;

#endregion

namespace NPWalks.API.Data;

public class NPWalksDbContext : DbContext
{
    //constructor
    public NPWalksDbContext(DbContextOptions<NPWalksDbContext> dbContextOptions)
        : base(dbContextOptions) //pass dbContextOptions to the base class
    {
    }

    //DbSet : A property of the dbContext class that represents the collection of the entities in the database.
    public DbSet<Difficulty> Difficulties { get; set; }
    public DbSet<Region> Regions { get; set; }
    public DbSet<Walk> Walks { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        //Seed data for Difficulties
        //Easy, Medium, Hard

        var difficulties = new List<Difficulty>()
        {
            new Difficulty()
            {
                Id = Guid.Parse("c6324484-c5b4-49ae-8b5f-729bdd5ed166"),
                Name = "Easy",
            },
            new Difficulty()
            {
                Id = Guid.Parse("8072210a-403e-4f60-a006-5c0fee7d5ab0"),
                Name = "Medium",
            },
            new Difficulty()
            {
                Id = Guid.Parse("71a84ba7-1f6c-468e-b334-862fb89ca31e"),
                Name = "Hard",
            }
        };
        //seed difficulties to the database
        modelBuilder.Entity<Difficulty>().HasData(difficulties);

        //seed data for Regions
        var regions = new List<Region>()
        {
            new Region
            {
                Id = Guid.Parse("a9755b67-f022-4dc3-ad0d-03d7955fa75b"),
                Name = "Butwal",
                Code = "BTL",
                RegionImageUrl = "https://en.wikipedia.org/wiki/Butwal#/media/File:Butwal.jpg"
            },
            new Region
            {
                Id = Guid.Parse("14876ed1-621b-429f-8863-66cae8baeb15"),
                Name = "Shivapuri",
                Code = "KTM",
                RegionImageUrl =
                    "https://en.wikipedia.org/wiki/Shivapuri_Nagarjun_National_Park#/media/File:A_view_of_Shivapuri_national_park_from_Sundarijal.jpg"
            },
            new Region
            {
                Id = Guid.Parse("2c2b2bf6-7611-4c2a-b6ad-63afb28c0fd4"),
                Name = "Tamghas",
                Code = "TMGS",
                RegionImageUrl = "https://thegreathimalayas.files.wordpress.com/2015/04/resunga.jpg"
            },
            new Region
            {
                Id = Guid.Parse("de86cc6a-026e-491b-ad10-52b15d266a66"),
                Name = "Pokhara",
                Code = "PKH",
                RegionImageUrl =
                    "https://images.pexels.com/photos/6822183/pexels-photo-6822183.jpeg"
            },
        };
        modelBuilder.Entity<Region>().HasData(regions);
    }
}