using Microsoft.EntityFrameworkCore;
using RotasViagem.Domain.Entities;
using RotasViagem.Infra.Mappings;

namespace RotasViagem.Infra.Context
{
    public class RotaDbContext : DbContext
    {
        public RotaDbContext(DbContextOptions<RotaDbContext> options) : base(options) { }

        public DbSet<Rota> Rotas => Set<Rota>();
        public DbSet<User> Users => Set<User>();
        public DbSet<Trecho> Trechos => Set<Trecho>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //modelBuilder.Entity<Trecho>(new TrechoMap().Configure);
            modelBuilder.ApplyConfiguration(new RotaMap());
            modelBuilder.ApplyConfiguration(new TrechoMap());
            modelBuilder.ApplyConfiguration(new UserMap());
        }

    }
}
