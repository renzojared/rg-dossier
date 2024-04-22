namespace Infrastructure.DataContext.Configurations;

public class DossierPersonConfiguration : IEntityTypeConfiguration<DossierPerson>
{
    public void Configure(EntityTypeBuilder<DossierPerson> builder)
    {
        builder
            .Property(s => s.PersonId)
            .IsRequired();

        builder
            .Property(s => s.DossierId)
            .IsRequired();
    }
}