using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RotasViagem.Domain.Entities;

namespace RotasViagem.Infra.Mappings;

public class MapBase<T> : IEntityTypeConfiguration<T> where T : Base
{
    public virtual void Configure(EntityTypeBuilder<T> builder)
    {
    }
}
