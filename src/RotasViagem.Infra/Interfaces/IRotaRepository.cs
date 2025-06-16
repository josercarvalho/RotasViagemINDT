using RotasViagem.Domain.Entities;

namespace RotasViagem.Infra.Interfaces
{
    public interface IRotaRepository : IBaseRepository<Rota>
    {
        Task<(List<string> Caminho, decimal Custo)> BuscarMelhorRotaAsync(string origem, string destino);
    }
}
