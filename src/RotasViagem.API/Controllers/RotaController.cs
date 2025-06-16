using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RotasViagem.Domain.Entities;
using RotasViagem.Infra.Interfaces;
using RotasViagem.Services.DTOs;
using FluentValidation;

namespace RotasViagem.Api.Controllers;

[ApiController]
[Route("api/rotas")]
public class RotaController : ControllerBase
{
    private readonly IRotaRepository _repository;
    private readonly IMapper _mapper;

    public RotaController(IRotaRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> Listar()
    {
        var rotas = await _repository.GetAllAsync();
        var result = _mapper.Map<List<RotaResponse>>(rotas);
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Criar([FromBody] RotaResponse novaRota)
    {
       
        var rota = _mapper.Map<Rota>(novaRota);
        await _repository.CreateAsync(rota);
        var result = _mapper.Map<RotaResponse>(rota);
        return Created("", result);
    }

    [HttpPut]
    public async Task<IActionResult> Atualizar([FromBody] RotaResponse rotaAtualizada)
    {
        var retorno = await _repository.GetByIdAsync(rotaAtualizada.Id);
        if (retorno is null) return NotFound("Rota não encontrada");

        var rota = _mapper.Map<Rota>(rotaAtualizada);
        await _repository.UpdateAsync(rota);
        return NoContent();
    }

    [HttpDelete("id")]
    public async Task<IActionResult> Remover(int id)
    {
        var rota = await _repository.GetByIdAsync(id);
        if (rota is null) return NotFound("Rota não encontrada");

        await _repository.RemoveAsync(id);
        return NoContent();
    }

    [HttpGet("melhor-rota")]
    public async Task<IActionResult> ConsultarMelhorRota([FromQuery] string origem, [FromQuery] string destino)
    {
        if (string.IsNullOrWhiteSpace(origem) || string.IsNullOrWhiteSpace(destino))
            return BadRequest("Origem e destino são obrigatórios.");

        var (caminho, custo) = await _repository.BuscarMelhorRotaAsync(origem.ToUpper(), destino.ToUpper());

        if (!caminho.Any())
            return NotFound("Não foi possível encontrar uma rota.");

        if (custo == decimal.MaxValue)
            return NotFound("Rota não encontrada");

        var rotaFormatada = string.Join(" - ", caminho);
        return Ok($"{rotaFormatada} ao custo de ${custo}");
    }
}
