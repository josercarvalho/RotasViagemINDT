using Microsoft.EntityFrameworkCore;
using RotasViagem.Domain.Entities;
using RotasViagem.Infra.Context;
using RotasViagem.Infra.Repositories;
using RotasViagem.Services.Services;

namespace RotaViagem.Tests
{
    public class RotaServiceTests
    {
        private static RotaDbContext GetDbContext()
        {
            var options = new DbContextOptionsBuilder<RotaDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            var context = new RotaDbContext(options);
            context.Rotas.AddRange(new List<Rota>
            {
                new Rota ( "GRU", "BRC", 10 ),
                new Rota ( "BRC", "SCL", 5  ),
                new Rota ( "GRU", "CDG", 75 ),
                new Rota ( "GRU", "SCL", 20 ),
                new Rota ( "GRU", "ORL", 56 ),
                new Rota ( "ORL", "CDG", 5  ),
                new Rota ( "SCL", "ORL", 20 ),
                new Rota ( "CDG", "ORL", 13 ),
                new Rota ( "CDG", "GRU", 11 ),
                new Rota ( "CDG", "SCL", 9  )
            });

            context.SaveChanges();
            return context;
        }

        [Fact(DisplayName = "Deve retornar a rota mais barata de GRU para CDG com custo 40")]
        public async Task MelhorRota_GRU_CDG_DeveRetornarRotaDe40()
        {
            var context = GetDbContext();
            var service = new RotaRepository(context);

            var (caminho, custo) = await service.BuscarMelhorRotaAsync("GRU", "CDG");

            Assert.Equal(40, custo);
            Assert.Equal(new[] { "GRU", "BRC", "SCL", "ORL", "CDG" }, caminho);
        }

        [Fact(DisplayName = "Deve retornar rota direta de BRC para SCL com custo 5")]
        public async Task MelhorRota_BRC_SCL_DeveRetornar5()
        {
            var context = GetDbContext();
            var service = new RotaRepository(context);

            var (caminho, custo) = await service.BuscarMelhorRotaAsync("BRC", "SCL");

            Assert.Equal(5, custo);
            Assert.Equal(new[] { "BRC", "SCL" }, caminho);
        }

        [Fact(DisplayName = "Deve retornar MaxValue e caminho vazio quando não houver rota disponível")]
        public async Task MelhorRota_Inexistente_DeveRetornarMaxValue()
        {
            var context = GetDbContext();
            var service = new RotaRepository(context);

            var (caminho, custo) = await service.BuscarMelhorRotaAsync("AAA", "BBB");

            Assert.Equal(decimal.MaxValue, custo);
            Assert.Empty(caminho);
        }

        [Theory(DisplayName = "Deve lançar ArgumentNullException quando origem ou destino forem nulos")]
        [InlineData(null, "CDG")]
        [InlineData("GRU", null)]
        public async Task BuscarMelhorRotaAsync_DeveLancar_ArgumentNullException(string? origem, string? destino)
        {
            var context = GetDbContext();
            var service = new RotaRepository(context);

            await Assert.ThrowsAsync<ArgumentNullException>(() => service.BuscarMelhorRotaAsync(origem!, destino!));
        }

        [Theory(DisplayName = "Deve lan�ar ArgumentException quando origem ou destino forem vazios")]
        [InlineData("", "CDG")]
        [InlineData("GRU", "")]
        public async Task BuscarMelhorRotaAsync_DeveLancar_ArgumentException_QuandoVazios(string origem, string destino)
        {
            var context = GetDbContext();
            var service = new RotaRepository(context);

            await Assert.ThrowsAsync<ArgumentException>(() => service.BuscarMelhorRotaAsync(origem, destino));
        }
    }
}