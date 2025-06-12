using RotasViagem.Domain.Entities;

namespace RotasViagem.Infra.Context;

public static class DatabaseSeeder
{
    public static void Seed(this RotaDbContext context)
    {
        if (context.Rotas.Any()) return;

        var rotas = new List<Rota> { };
    //{
    //     new (Guid.NewGuid(),"GRU", "BRC", 10),
    //    new (Guid.NewGuid(), "GRU", "CDG", 75),
    //    new (Guid.NewGuid(), "GRU", "SCL", 20),
    //    new (Guid.NewGuid(), "GRU", "ORL", 56),
    //    new (Guid.NewGuid(), "ORL", "CDG", 5),
    //    new (Guid.NewGuid(), "SCL", "ORL", 20),
    //    new (Guid.NewGuid(), "BRC", "SCL", 5)
    //};

        context.Rotas.AddRange(rotas);
        context.SaveChanges();
    }
}
