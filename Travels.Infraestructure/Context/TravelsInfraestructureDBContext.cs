using Microsoft.EntityFrameworkCore;
using Travels.Infraestructure.Models;

namespace TravelsInfraestructure.Context;
public class TravelsInfraestructureDBContext: DbContext
{
    public TravelsInfraestructureDBContext()
    {
        
    }
    public TravelsInfraestructureDBContext(DbContextOptions<TravelsInfraestructureDBContext> options) : base(options)
    {
       
    }
    public DbSet<Destination> Destinations { get; set; }
    
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            var serverVersion = new MySqlServerVersion(new Version(8, 0, 33));
            optionsBuilder.UseMySql("Server=localhost,3306;Uid=root;Pwd=UPC@intranet_17;Database=traveleres",
                serverVersion);
        }
    }
    
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<Destination>().ToTable("Destinations");
        builder.Entity<Destination>().HasKey(p => p.id);
        builder.Entity<Destination>().Property(p => p.id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Destination>().Property(p => p.name).IsRequired();

        builder.Entity<Destination>().HasIndex(p => p.name).IsUnique();
    }
    
}