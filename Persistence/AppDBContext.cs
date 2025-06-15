using Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Persistence.IdentityEnitities;

namespace Persistence;

public class AppDBContext(DbContextOptions options)  : IdentityDbContext(options)
{
    public DbSet<Activity> Activities { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<City> Cities { get; set; }

    public DbSet<AppUser> Users { get; set; }
}