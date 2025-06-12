using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RotasViagem.Domain.Entities;

namespace RotasViagem.Infra.Mappings
{
    public class TrechoMap : MapBase<Trecho>
    {
        public override void Configure(EntityTypeBuilder<Trecho> builder)
        {
            base.Configure(builder);

            builder.Property(c => c.Origem).IsRequired().HasMaxLength(3);
            builder.Property(c => c.Destino).IsRequired().HasMaxLength(3);
            builder.Property(c => c.Valor).IsRequired();
            builder.HasKey(c => c.Id);

            //builder.ToTable("trecho");
            //builder.Property(c => c.Origem).IsRequired().HasColumnName("Origem").HasMaxLength(3);
            //builder.Property(c => c.Destino).IsRequired().HasColumnName("Destino").HasMaxLength(3);
            //builder.Property(c => c.Valor).IsRequired().HasColumnName("Valor").HasColumnType("decimal(6,2)");
            //builder.HasKey(c => c.Id);
            builder.HasAlternateKey(c => new { c.Origem, c.Destino });
        }
    }
}
