using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace NPWalks.API.Data;

public class NPWalksAuthDbContext : IdentityDbContext
{
    public NPWalksAuthDbContext(DbContextOptions<NPWalksAuthDbContext> options)
        : base(options) { }
}
