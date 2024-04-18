using System.Reflection;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Infrastructure.DataContext.Contexts;

public class GovernmentContext(IOptions<DbOptions> options) : IdentityDbContext<GovernmentUser>
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer(options.Value.ConnectionString);

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }

    public DbSet<Dossier> Dossiers => Set<Dossier>();
    public DbSet<Court> Courts => Set<Court>();
    public DbSet<Matter> Matters => Set<Matter>();
    public DbSet<OverallProcess> OverallProcesses => Set<OverallProcess>();
    public DbSet<Person> Persons => Set<Person>();
}