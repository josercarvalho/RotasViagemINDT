using Microsoft.EntityFrameworkCore;
using RotasViagem.Domain.Entities;
using RotasViagem.Infra.Mappings;

namespace RotasViagem.Infra.Context;

public class RotaDbContext : DbContext
{
    public DbSet<Rota> Rotas { get; set; }
    public DbSet<Trecho> Trechos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=rotas.db");

        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Trecho>(new TrechoMap().Configure);
        modelBuilder.Entity<Rota>(new RotaMap().Configure);
    }
}

