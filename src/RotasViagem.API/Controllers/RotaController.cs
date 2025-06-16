using Microsoft.AspNetCore.Mvc;
using RotasViagem.Domain.Entities;
using RotasViagem.Infra.Interfaces;

namespace RotasViagem.Api.Controllers;

[ApiController]
[Route("api/rotas")]
public class RotaController : ControllerBase
{
    private readonly IRotaRepository _repository;

    public RotaController(IRotaRepository repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public async Task<IActionResult> Listar()
    {
        var rotas = await _repository.GetAllAsync();
        return Ok(rotas);
    }

    [HttpPost]
    public async Task<IActionResult> Criar([FromBody] Rota novaRota)
    {
        await _repository.CreateAsync(novaRota);

        return Created("", novaRota);
    }

    [HttpPut]
    public async Task<IActionResult> Atualizar([FromBody] Rota rota)
    {
        await _repository.UpdateAsync(rota);
        return NoContent();
    }

    [HttpDelete("id")]
    public async Task<IActionResult> Remover(int id)
    {
        await _repository.RemoveAsync(id);
        return NoContent();
    }

    [HttpGet("melhor-rota")]
    public async Task<IActionResult> ConsultarMelhorRota([FromQuery] string origem, [FromQuery] string destino)
    {
        var (caminho, custo) = await _repository.BuscarMelhorRotaAsync(origem.ToUpper(), destino.ToUpper());

        if (!caminho.Any())
            return NotFound("Não foi possível encontrar uma rota.");

        var rotaFormatada = string.Join(" - ", caminho);
        return Ok($"{rotaFormatada} ao custo de ${custo}");
    }
}
