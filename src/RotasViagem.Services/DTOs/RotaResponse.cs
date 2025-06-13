using System.ComponentModel.DataAnnotations;

namespace RotasViagem.Services.DTOs;

// <summary>
/// Resultado da rota que atenda os critérios selecionados
/// </summary>
public class RotaResponse 
{
    public int Id { get; set; }
    public string Origem { get; set; } = string.Empty;
    public string Destino { get; set; } = string.Empty;
    public decimal Valor { get; set; }
}
