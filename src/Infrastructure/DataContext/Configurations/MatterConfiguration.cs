namespace Infrastructure.DataContext.Configurations;

public class MatterConfiguration : IEntityTypeConfiguration<Matter>
{
    public void Configure(EntityTypeBuilder<Matter> builder)
    {
        builder
            .HasOne(s => s.OverallProcess);
    }
}