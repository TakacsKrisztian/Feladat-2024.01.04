using Microsoft.EntityFrameworkCore;

    public class PoliticalDbContext : DbContext
{
    public PoliticalDbContext(DbContextOptions options) : base(options)
    {
    }


    public DbSet<PoliticalParty> PoliticalParties { get; set; } = null!;
    public DbSet<Politician> Politicians { get; set; } = null!;


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseMySql("server=localhost; database=Politics; user=root; password=", ServerVersion.AutoDetect("server=localhost; database=Politics; user=root; password="));
        }
    }

}