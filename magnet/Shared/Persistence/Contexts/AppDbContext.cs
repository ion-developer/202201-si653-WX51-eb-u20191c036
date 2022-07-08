using Microsoft.EntityFrameworkCore;

namespace magnet.Shared.Persistence.Contexts;

public class AppDbContext : DbContext
{

    public DbSet<Author.Domain.Models.Author> Authors { get; set; }
    public DbSet<Provider.Domain.Models.Provider> Providers { get; set; }

    private readonly IConfiguration _configuration;
        
    public AppDbContext(DbContextOptions options, IConfiguration configuration) : base(options)
    {
        _configuration = configuration;
    }
        
    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
        builder.UseMySQL(_configuration.GetConnectionString("DefaultConnection"));
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.Entity<Author.Domain.Models.Author>().ToTable("Authors");
        builder.Entity<Author.Domain.Models.Author>().HasKey(x => x.Id);
        builder.Entity<Author.Domain.Models.Author>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Author.Domain.Models.Author>().Property(p => p.FirstName).IsRequired().HasMaxLength(30);
        builder.Entity<Author.Domain.Models.Author>().Property(p => p.LastName).IsRequired().HasMaxLength(30); ;
        builder.Entity<Author.Domain.Models.Author>().Property(p => p.Nickname).IsRequired().HasMaxLength(60);
        builder.Entity<Author.Domain.Models.Author>().Property(p => p.PhotoUrl).IsRequired().HasMaxLength(100);
        builder.Entity<Provider.Domain.Models.Provider>().ToTable("Providers");
        builder.Entity<Provider.Domain.Models.Provider>().HasKey(x => x.Id);
        builder.Entity<Provider.Domain.Models.Provider>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Provider.Domain.Models.Provider>().Property(p => p.Name).IsRequired().HasMaxLength(60);
        builder.Entity<Provider.Domain.Models.Provider>().Property(p => p.ApiUrl).HasMaxLength(100); ;
        builder.Entity<Provider.Domain.Models.Provider>().Property(p => p.KeyRequired).HasDefaultValue(false);
        builder.Entity<Provider.Domain.Models.Provider>().Property(p => p.ApiKey).HasMaxLength(100);
    }
}