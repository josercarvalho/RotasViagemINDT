﻿using Microsoft.EntityFrameworkCore;
using RotasViagem.Domain.Entities;
using RotasViagem.Infra.Context;
using RotasViagem.Infra.Interfaces;

namespace RotasViagem.Infra.Repositories
{
    public class RotaRepository : BaseRepository<Rota>, IRotaRepository
    {
        private readonly RotaDbContext _context;
        public RotaRepository(RotaDbContext context) : base(context) 
        {
            _context = context;
        }

        /// <summary>
        /// Busca a melhor rota entre origem e destino com o menor custo total.
        /// </summary>
        public async Task<(List<string> Caminho, decimal Custo)> BuscarMelhorRotaAsync(string origem, string destino)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(origem);
            ArgumentException.ThrowIfNullOrWhiteSpace(destino);

            var rotas = await _context.Rotas.ToListAsync();
            var resultado = Buscar(origem, destino, rotas, new List<string>(), 0);
            return resultado ?? (new List<string>(), decimal.MaxValue);
        }

        private (List<string>, decimal)? Buscar(string atual, string destino, List<Rota> rotas, List<string> visitados, decimal custoAtual)
        {
            if (visitados.Contains(atual)) return null;

            visitados.Add(atual);
            if (atual == destino) return (new List<string> { atual }, custoAtual);

            var melhores = rotas
                .Where(r => r.Origem == atual)
                .Select(r =>
                {
                    var resultado = Buscar(r.Destino, destino, rotas, new List<string>(visitados), custoAtual + r.Valor);
                    if (resultado != null)
                        return (new List<string> { atual }.Concat(resultado.Value.Item1).ToList(), resultado.Value.Item2);
                    return ((List<string>?)null, decimal.MaxValue);
                })
                .Where(r => r.Item1 != null)
                .OrderBy(r => r.Item2)
                .FirstOrDefault();

            return melhores.Item1 != null ? (melhores.Item1!, melhores.Item2) : null;
        }
    }
}
