using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RotasViagem.Domain.Entities;

namespace RotasViagem.Infra.Mappings
{
    internal class RotaMap : IEntityTypeConfiguration<Rota>
    {
        public void Configure(EntityTypeBuilder<Rota> builder)
        {
            builder.ToTable("rota");

            builder.HasKey(c => c.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(c => c.Origem).IsRequired().HasColumnName("Origem").HasMaxLength(3);
            builder.Property(c => c.Destino).IsRequired().HasColumnName("Destino").HasMaxLength(3);
            builder.Property(c => c.Valor).IsRequired().HasColumnName("Valor").HasColumnType("decimal(6,2)");

        }        
    }
}
