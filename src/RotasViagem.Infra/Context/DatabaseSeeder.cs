using RotasViagem.Domain.Entities;
using System.Drawing;

namespace RotasViagem.Infra.Context;

public static class DatabaseSeeder
{
    public static void Seed(this RotaDbContext context)
    {
        if (context.Rotas.Any()) return;

        var trecho = new List<Trecho>
        {
            new Trecho ( "GRU", "BRC", 10 ),
            new Trecho ( "GRU", "SCL", 5  ),
            new Trecho ( "GRU", "CDG", 75 ),
            new Trecho ( "GRU", "SCL", 20 ),
            new Trecho ( "GRU", "ORL", 56 ),
            new Trecho ( "GRU", "CDG", 5  ),
            new Trecho ( "GRU", "ORL", 20 ),
            new Trecho ( "CDG", "ORL", 13 ),
            new Trecho ( "CDG", "GRU", 11 ),
            new Trecho ( "CDG", "SCL", 9  )
        };


        context.Rotas.AddRange((IEnumerable<Rota>)trecho);
        context.SaveChanges();
    }
}
