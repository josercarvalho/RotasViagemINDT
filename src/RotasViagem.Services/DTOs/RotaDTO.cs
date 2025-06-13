using System.ComponentModel.DataAnnotations;

namespace RotasViagem.Services.DTOs;

// <summary>
/// Resultado da rota que atenda os critérios selecionados
/// </summary>
public class RotaDTO : DTOBase
{
    /// <summary>
    /// Id relacionado ao techo da rota.
    /// </summary>
    [Required]
    public int Id { get; set; }

    /// <summary>
    /// Siglas relacionadas aos techos da rota.
    /// </summary>
    [Required]
    public string Conexao { get; set; }

    /// <summary>
    /// Somatório do valor de cada trecho contabilizando o valor total da rota.
    /// </summary>
    [Required]
    public double Valor { get; set; }
}
