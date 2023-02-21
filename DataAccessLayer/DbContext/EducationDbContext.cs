
using educationprogramAPI.DataAccessLayer.DataModel;
using Microsoft.EntityFrameworkCore;

public class EducationDbContext : DbContext
{
    public EducationDbContext(DbContextOptions<EducationDbContext> options) : base(options) {}
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Education>().ToTable("Education", "dbo");
        modelBuilder.Entity<EducationProgram>().ToTable("EducationProgram", "dbo");

        base.OnModelCreating(modelBuilder);
    }

    public DbSet<Education> Education { get; set; } 
    public DbSet<EducationProgram> EducationPrograms { get; set; } 
} 