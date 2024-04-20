namespace Infrastructure.DataContext.Configurations;

public class DossierConfiguration : IEntityTypeConfiguration<Dossier>
{
    public void Configure(EntityTypeBuilder<Dossier> builder)
    {
        builder
            .HasOne(s => s.Plaintiff)
            .WithMany()
            .HasForeignKey(s => s.PlaintiffId)
            .OnDelete(DeleteBehavior.Restrict);

        builder
            .HasOne(s => s.Defendant)
            .WithMany()
            .HasForeignKey(s => s.DefendantId)
            .OnDelete(DeleteBehavior.Restrict);

        builder
            .HasOne(s => s.Responsible)
            .WithMany()
            .HasForeignKey(s => s.ResponsibleId)
            .OnDelete(DeleteBehavior.Restrict);

        builder
            .HasOne(s => s.OverallProcess)
            .WithMany()
            .HasForeignKey(s => s.OverallProcessId)
            .IsRequired();

        builder
            .HasOne(s => s.Matter)
            .WithMany()
            .HasForeignKey(s => s.MatterId)
            .IsRequired(false);

    }
}