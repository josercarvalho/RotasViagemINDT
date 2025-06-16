using System.ComponentModel.DataAnnotations;

namespace RotasViagem.Services.DTOs;

// <summary>
/// Resultado da rota que atenda os critérios selecionados
/// </summary>
public class RotaResponse
{
    [Required]
    public int Id { get; set; }
    [Required(ErrorMessage = "A origem é obrigatória")]
    [StringLength(3, MinimumLength = 3, ErrorMessage = "A origem deve ter exatamente 3 caracteres")]
    public string Origem { get; set; }

    [Required(ErrorMessage = "O destino é obrigatório")]
    [StringLength(3, MinimumLength = 3, ErrorMessage = "O destino deve ter exatamente 3 caracteres")]
    public string Destino { get; set; }

    [Required(ErrorMessage = "O valor é obrigatório")]
    [Range(0.01, double.MaxValue, ErrorMessage = "O valor deve ser maior que zero")]
    public decimal Valor { get; set; }
}
