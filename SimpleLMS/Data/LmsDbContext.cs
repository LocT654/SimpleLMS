using Microsoft.EntityFrameworkCore;
using System.Reflection;

public class LmsDbContext : DbContext
{
    public DbSet<Course> Courses { get; set; }
    public DbSet<Module> Modules { get; set; }
    public DbSet<Assignment> Assignments { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=lms.db");
    }
}
