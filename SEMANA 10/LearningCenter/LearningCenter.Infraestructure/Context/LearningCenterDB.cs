using Microsoft.EntityFrameworkCore;

namespace LearningCenter.Infraestructure.Context;

public class LearningCenterDB:DbContext //Base de datos
{
    public DbSet<Category> Categories { get; set; }
    public DbSet<Tutorial> Tutorials { get; set; }
    public DbSet<User> Users { get; set; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer();
        }
    }
    
    public LearningCenterDB()
    {

    }

    public LearningCenterDB(DbContextOptions<LearningCenterDB> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        
        base.OnModelCreating(builder);
        
        builder.Entity<Category>().ToTable("Categories");
        builder.Entity<Category>().HasKey(p=>p.Id);
        builder.Entity<Category>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Category>().Property(c => c.Name).IsRequired().HasMaxLength(60);
        builder.Entity<Category>().Property(c => c.DateCreated).IsRequired().HasDefaultValue(DateTime.Now);
        builder.Entity<Category>().Property(c => c.IsActive).IsRequired().HasDefaultValue(true);
        
        builder.Entity<Tutorial>().ToTable("Tutorials");
        builder.Entity<Tutorial>().HasKey(p => p.Id);
        builder.Entity<Tutorial>().Property(c => c.DateCreated).IsRequired().HasDefaultValue(DateTime.Now);
        builder.Entity<Tutorial>().Property(c => c.IsActive).IsRequired().HasDefaultValue(true);

        builder.Entity<User>().ToTable("Users");
        builder.Entity<User>().HasKey(p => p.Id);
        builder.Entity<User>().Property(c => c.DateCreated).IsRequired().HasDefaultValue(DateTime.Now);
        builder.Entity<User>().Property(c => c.IsActive).IsRequired().HasDefaultValue(true);
    }
     
}