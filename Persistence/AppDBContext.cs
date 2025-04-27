using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistence;

public class AppDBContext(DbContextOptions options)  : DbContext(options)
{
    public DbSet<Activity> Activities { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<City> Cities { get; set; }
}