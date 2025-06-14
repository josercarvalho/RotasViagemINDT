using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using RotasViagem.Domain.Entities;
using RotasViagem.Infra.Interfaces;
using RotasViagem.Services.DTOs;
using RotasViagem.Services.Interfaces;

namespace RotasViagem.Aplication.Controllers;

/// <summary>
/// Define os endpoints de rota usando Minimal API.
/// </summary>
public static class RotaController
{
    public static void MapRotasEndpoints(this WebApplication app)
    {
        app.MapGet("/api/rotas", async Task<Ok<List<RotaResponse>>> (IRotaRepository db, IMapper mapper) =>
        {
            var rotas = await db.GetAllAsync();
            var result = mapper.Map<List<RotaResponse>>(rotas);
            return TypedResults.Ok(result);
        })
        .WithName("ObterTodasAsRotas")
        .WithDescription("Retorna a lista de todas as rotas cadastradas.")
        .WithTags("Rotas");

        app.MapPost("/api/rotas", async Task<Created<RotaResponse>> (IRotaRepository db, IMapper mapper, RotaCreateRequest request) =>
        {
            var rota = mapper.Map<Rota>(request);
            await db.CreateAsync(rota);
            var result = mapper.Map<RotaResponse>(rota);
            return TypedResults.Created($"/api/rotas/{rota.Id}", result);
        })
        .WithName("CriarRota")
        .WithDescription("Cadastra uma nova rota com origem, destino e valor.")
        .WithTags("Rotas");

        app.MapPut("/api/rotas/{id}", async Task<Results<NoContent, NotFound>> (int id, IRotaRepository db, RotaCreateRequest rotaAtualizada) =>
        {
            var rota = await db.GetByIdAsync(id);
            if (rota is null) return TypedResults.NotFound();

            rota.SetOrigem(rotaAtualizada.Origem);
            rota.SetOrigem(rotaAtualizada.Destino);
            rota.Valor = rotaAtualizada.Valor;

            await db.CreateAsync(rota);
            return TypedResults.NoContent();
        })
        .WithName("AtualizarRota")
        .WithDescription("Atualiza os dados de uma rota existente pelo ID.")
        .WithTags("Rotas");

        app.MapDelete("/api/rotas/{id}", async Task<Results<NoContent, NotFound>> (int id, IRotaRepository db) =>
        {
            var rota = await db.GetByIdAsync(id);
            if (rota is null) return TypedResults.NotFound();
                        
            await db.RemoveAsync(rota.Id);
            return TypedResults.NoContent();
        })
        .WithName("DeletarRota")
        .WithDescription("Remove uma rota do sistema pelo ID.")
        .WithTags("Rotas");

        app.MapGet("/api/rotas/melhor", async Task<Results<Ok<string>, NotFound<string>, BadRequest<string>>> (string origem, string destino, IRotaService service) =>
        {
            if (string.IsNullOrWhiteSpace(origem) || string.IsNullOrWhiteSpace(destino))
                return TypedResults.BadRequest("Origem e destino são obrigatórios.");

            //var service = new RotaService(db);
            var (caminho, custo) = await service.BuscarMelhorRotaAsync(origem.ToUpper(), destino.ToUpper());

            if (custo == decimal.MaxValue)
                return TypedResults.NotFound("Rota não encontrada");

            return TypedResults.Ok($"{string.Join(" - ", caminho)} ao custo de ${custo}");
        })
        .WithName("BuscarMelhorRota")
        .WithDescription("Retorna a rota mais barata entre dois pontos, independente de conexões.")
        .WithTags("Rotas");
    }
}
