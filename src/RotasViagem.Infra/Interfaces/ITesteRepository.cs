using RotasViagem.Domain.Entities;

namespace RotasViagem.Infra.Interfaces
{
    public interface ITesteRepository
    {
        void AdicionarRota(Rota rota);
        List<Rota> ObterRotas();
    }
}
