namespace Application.Interfaces.Repositories;

public interface IEntities
{
    DbSet<Dossier> Dossiers { get; }
    DbSet<Court> Courts { get; }
    DbSet<Matter> Matters { get; }
    DbSet<OverallProcess> OverallProcesses { get; }
    DbSet<Person> Persons { get; }
}