using Microsoft.EntityFrameworkCore;

namespace NotShop.Models.Entities;

public class PgContext : DbContext
{
    private IConfiguration _configuration;
    
    public PgContext(IConfiguration configuration, DbContextOptions<PgContext> options) : base(options)
    {
        _configuration = configuration;

    }
/*
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(_configuration.GetConnectionString("PgDbConnection"));

    }
  */

    public DbSet<Group> Groups { get; set; }
    public DbSet<Subgroup> Subgroups { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Subcategory> Subcategories { get; set; }
    public DbSet<Item> Items { get; set; }
    public DbSet<ItemDetail> ItemDetails { get; set; }
    
    public DbSet<Brand> Brands { get; set; }
    public DbSet<Size> Sizes { get; set; }
    public DbSet<Color> Colors { get; set; }
}