using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RotasViagem.Domain.Entities;

namespace RotasViagem.Infra.Mappings
{
    public class TrechoMap : IEntityTypeConfiguration<Trecho>
    {

        public void Configure(EntityTypeBuilder<Trecho> builder)
        {
            builder.ToTable("trecho");

            builder.HasKey(c => c.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(c => c.Origem).IsRequired().HasColumnName("Origem").HasMaxLength(3);
            builder.Property(c => c.Destino).IsRequired().HasColumnName("Destino").HasMaxLength(3);
            builder.Property(c => c.Valor).IsRequired().HasColumnName("Valor").HasColumnType("decimal(6,2)");
            
            builder.HasAlternateKey(c => new { c.Origem, c.Destino });
        }

    }
}
