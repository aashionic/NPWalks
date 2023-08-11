using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace NPWalks.API.Data;

public class NPWalksAuthDbContext : IdentityDbContext
{
    public NPWalksAuthDbContext(DbContextOptions<NPWalksAuthDbContext> options)
        : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        var readerRoleId = "8F7A64C3-1A99-4D32-97E5-404B1D3CFDD7";
        var writerRoleId = "634273FE-B4B5-472C-B26A-6A89D0BC9216";
        var roles = new List<IdentityRole>
        {
        new IdentityRole
        {
            Id=readerRoleId,
            ConcurrencyStamp = readerRoleId,
            NormalizedName = "Reader".ToUpper()
        },
        new IdentityRole
        {
            Id = writerRoleId,
            ConcurrencyStamp = writerRoleId,
            NormalizedName = "Writer".ToUpper()
        }
        };
        builder.Entity<IdentityRole>().HasData(roles);
    }
}
