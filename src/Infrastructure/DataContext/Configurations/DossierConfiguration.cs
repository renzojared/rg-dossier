namespace Infrastructure.DataContext.Configurations;

public class DossierConfiguration : IEntityTypeConfiguration<Dossier>
{
    public void Configure(EntityTypeBuilder<Dossier> builder)
    {
        builder
            .HasOne<OverallProcess>()
            .WithMany()
            .HasForeignKey(s => s.OverallProcessId)
            .IsRequired();

        builder
            .HasOne<Matter>()
            .WithMany()
            .HasForeignKey(s => s.MatterId)
            .IsRequired(false);

        builder
            .HasMany(s => s.DossierPersons)
            .WithOne(s => s.Dossier)
            .HasForeignKey(s => s.DossierId)
            .OnDelete(DeleteBehavior.NoAction);

        builder
            .Property(s => s.EndDate)
            .IsRequired(false);
    }
}