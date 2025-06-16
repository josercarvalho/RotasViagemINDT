using Microsoft.EntityFrameworkCore;
using RotasViagem.Domain.Entities;
using RotasViagem.Infra.Mappings;

namespace RotasViagem.Infra.Context;

public class RotaDbContext : DbContext
{
    public RotaDbContext(DbContextOptions<RotaDbContext> options) : base(options) { }

    public DbSet<Rota> Rotas => Set<Rota>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Rota>(new RotaMap().Configure);
    }
}

