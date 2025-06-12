using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RotasViagem.Domain.Entities;

namespace RotasViagem.Infra.Mappings;

public class UserMap : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id);

        builder.Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(80);

        builder.Property(x => x.Password)
            .IsRequired()
            .HasMaxLength(1000);

        builder.Property(x => x.Email)
            .IsRequired()
            .HasMaxLength(180);
    }
}
