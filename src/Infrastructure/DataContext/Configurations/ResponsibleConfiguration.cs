namespace Infrastructure.DataContext.Configurations;

public class ResponsibleConfiguration : IEntityTypeConfiguration<Responsible>
{
    public void Configure(EntityTypeBuilder<Responsible> builder)
    {
        builder
            .HasOne(s => s.Person)
            .WithOne()
            .HasForeignKey<Responsible>(s => s.PersonId);
    }
}