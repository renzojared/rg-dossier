namespace Application.Interfaces.Repositories;

public interface IEntities
{
    DbSet<Court> Courts { get; }
    DbSet<Dossier> Dossiers { get; }
    DbSet<DossierPerson> DossierPersons { get; }
    DbSet<Matter> Matters { get; }
    DbSet<OverallProcess> OverallProcesses { get; }
    DbSet<Person> Persons { get; }
    DbSet<Responsible> Responsibles { get; }
}