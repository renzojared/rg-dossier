namespace Infrastructure.DataContext.Configurations;

public class PersonConfiguration : IEntityTypeConfiguration<Person>
{
    public void Configure(EntityTypeBuilder<Person> builder)
    {
        builder.Ignore(s => s.FullName);
        builder.Ignore(s => s.OnlyNames);
        builder.Ignore(s => s.OnlySurnames);

        builder
            .HasMany(s => s.DossierPersons)
            .WithOne(s => s.Person)
            .HasForeignKey(s => s.PersonId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}