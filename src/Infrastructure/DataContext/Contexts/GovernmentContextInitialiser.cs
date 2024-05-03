using Domain.Enums;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.DataContext.Contexts;

public class GovernmentContextInitialiser(
    GovernmentContext context,
    UserManager<GovernmentUser> userManager,
    RoleManager<IdentityRole> roleManager)
{
    public async Task InitialiseAsync()
        => await context.Database.MigrateAsync();

    public async Task SeedAsync()
        => await TrySeedAsync();

    public async Task TrySeedAsync()
    {
        //Default roles
        var administratorRole = new IdentityRole(Roles.Administrator);

        if (roleManager.Roles.All(s => s.Name != administratorRole.Name))
            await roleManager.CreateAsync(administratorRole);

        var administrator = new GovernmentUser { UserName = "admin@localhost", Email = "admin@localhost" };
        if (userManager.Users.All(s => s.UserName != administrator.UserName))
        {
            await userManager.CreateAsync(administrator, "Rleon123!");
            if (!string.IsNullOrWhiteSpace(administratorRole.Name))
                await userManager.AddToRolesAsync(administrator, new[] { administratorRole.Name, });
        }

        //Default data
        if (!context.OverallProcesses.Any())
        {
            var overallProcesses = InitialOverallProcesses();

            await context.OverallProcesses.AddRangeAsync(overallProcesses);

            if (!context.Matters.Any())
            {
                await context.Matters.AddRangeAsync([
                    new Matter
                    {
                        Description = "Administrativo Municipal", OverallProcess = overallProcesses[0]
                    },
                    new Matter { Description = "Anulación de Laudo", OverallProcess = overallProcesses[0] },
                    new Matter { Description = "Arbitraje", OverallProcess = overallProcesses[0] },
                    new Matter { Description = "Civiles - Callao", OverallProcess = overallProcesses[0] },
                    new Matter { Description = "Civiles - Disa", OverallProcess = overallProcesses[1] },
                    new Matter { Description = "Civiles - Lima", OverallProcess = overallProcesses[1] },
                    new Matter { Description = "Coactivo Conadis", OverallProcess = overallProcesses[1] },
                    new Matter { Description = "Coactivo Essalud", OverallProcess = overallProcesses[1] }
                ]);
            }
        }

        if (!context.Courts.Any())
        {
            await context.Courts.AddRangeAsync(InitialCourts());
        }

        if (!context.Persons.Any())
        {
            var persons = InitialPersons();
            await context.Persons.AddRangeAsync(persons);

            if (!context.Responsibles.Any())
                await context.Responsibles.AddAsync(new Responsible { Person = persons[0] });
        }

        //TODO: USE DOCKER
        if (context.ChangeTracker.HasChanges()) 
            await context.SaveChangesAsync();
    }

    private List<OverallProcess> InitialOverallProcesses()
    {
        return
        [
            new OverallProcess { Description = "Administrativo Municipal" },
            new OverallProcess { Description = "Anulación de Laudo" },
            new OverallProcess { Description = "Arbitraje" },
            new OverallProcess { Description = "Civiles - Callao" },
            new OverallProcess { Description = "Civiles - Disa" },
            new OverallProcess { Description = "Civiles - Lima" },
            new OverallProcess { Description = "Coactivo Conadis" },
            new OverallProcess { Description = "Coactivo Essalud" }
        ];
    }

    private List<Court> InitialCourts()
    {
        return
        [
            new Court { Name = "Juzgado de Lima" },
            new Court { Name = "Juzgado de Huacho" },
            new Court { Name = "Juzago I" },
            new Court { Name = "Juzgado II" },
            new Court { Name = "Juzgado Internacional" },
        ];
    }

    private List<Person> InitialPersons()
    {
        return
        [
            new Person
            {
                DocumentType = DocumentType.Nic, DocumentNumber = "12345678", FirstName = "Renzo",
                PaternalSurname = "Jared", Email = "rjared@sample"
            },
            new Person
            {
                DocumentType = DocumentType.ForeignCard, DocumentNumber = "123456789", FirstName = "Emilia",
                PaternalSurname = "Luana", Email = "eluana@sample"
            },
            new Person
            {
                DocumentType = DocumentType.Passport, DocumentNumber = "1234567890", FirstName = "Karina",
                PaternalSurname = "Mercedes", Email = "kmercedes@sample"
            },
        ];
    }
}