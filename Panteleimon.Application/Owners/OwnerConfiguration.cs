using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Panteleimon.Domain.Owners;

namespace Panteleimon.Application.Owners;

internal sealed class OwnerConfiguration : IEntityTypeConfiguration<Owner>
{
    public void Configure(EntityTypeBuilder<Owner> builder)
    {
        builder.ToTable("owners");

        builder.HasKey(o => o.Id);
        builder.Property(o => o.Id).ValueGeneratedNever();

        builder.Property(o => o.Name)
            .HasMaxLength(Owner.NameMaxLength)
            .IsRequired();

        builder.HasIndex(o => o.Name).IsUnique();
    }
}