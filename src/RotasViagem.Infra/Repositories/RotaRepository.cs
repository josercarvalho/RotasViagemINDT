using Microsoft.EntityFrameworkCore;
using RotasViagem.Domain.Entities;
using RotasViagem.Infra.Context;
using RotasViagem.Infra.Interfaces;

namespace RotasViagem.Infra.Repositories
{
    public class RotaRepository : BaseRepository<Rota>, IRotaRepository
    {
        public RotaRepository(RotaDbContext context) : base(context)
        {
        }
    }
}
