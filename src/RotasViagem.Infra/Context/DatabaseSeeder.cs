using RotasViagem.Domain.Entities;
using System.Drawing;

namespace RotasViagem.Infra.Context;

public static class DatabaseSeeder
{
    public static void Seed(this RotaDbContext context)
    {
        if (context.Rotas.Any()) return;

        var Rota = new List<Rota>
        {
            new Rota ( "GRU", "BRC", 10 ),
            new Rota ( "BRC", "SCL", 5  ),
            new Rota ( "GRU", "CDG", 75 ),
            new Rota ( "GRU", "SCL", 20 ),
            new Rota ( "GRU", "ORL", 56 ),
            new Rota ( "ORL", "CDG", 5  ),
            new Rota ( "GRU", "ORL", 20 ),
            new Rota ( "CDG", "ORL", 13 ),
            new Rota ( "CDG", "GRU", 11 ),
            new Rota ( "CDG", "SCL", 9  )
        };


        context.Rotas.AddRange((IEnumerable<Rota>)Rota);
        context.SaveChanges();
    }
}
