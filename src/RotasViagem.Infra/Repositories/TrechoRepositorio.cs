using RotasViagem.Domain.Entities;
using RotasViagem.Infra.Context;

namespace RotasViagem.Infra.Repositories
{
    internal class TrechoRepositorio : BaseRepository<Trecho>
    {
        public TrechoRepositorio(RotaDbContext context) : base(context)
        {
        }
    }
}
