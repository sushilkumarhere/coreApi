// File: Configurations/YourEntityConfiguration.cs
using exceltosql.Controllers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class YourEntityConfiguration : IEntityTypeConfiguration<emp>
{
    public void Configure(EntityTypeBuilder<emp> builder)
    {
        // Configuration for YourEntity
        builder.Property(e => e.CreatedOn)
            .HasDefaultValueSql("GETDATE()")
            .ValueGeneratedOnAdd();

        builder.Property(e => e.UpdatedOn)
            .HasDefaultValueSql("GETDATE()")
            .ValueGeneratedOnAddOrUpdate();

        // Other configurations for YourEntity
    }
}
