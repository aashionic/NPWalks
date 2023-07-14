using Microsoft.EntityFrameworkCore;
using NPWalks.API.Models.Domain;

namespace NPWalks.API.Data;

public class NPWalksDbContext : DbContext
{
    //constructor
    public NPWalksDbContext(DbContextOptions dbContextOptions) :base(dbContextOptions)//pass dbContextOptions to the base class
    {

    }

    //DbSet : A property of the dbContext class that represents the collection of the entities in the database.
    public DbSet<Difficulty> Difficulties { get; set; }
    public DbSet<Region> Regions { get; set; }
    public DbSet<Walk> Walks { get; set; }
}