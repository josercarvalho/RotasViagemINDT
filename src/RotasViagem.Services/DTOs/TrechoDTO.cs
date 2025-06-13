using System.ComponentModel.DataAnnotations;

namespace RotasViagem.Services.DTOs;

/// <summary>
/// Trecho de viagem para a rota.
/// </summary>
public class TrechoDTO : DTOBase
{

    /// <summary>
    /// Id do Terminal de origem do trecho.
    /// </summary>
    [Required]
    public int Id { get; set; }

    /// <summary>
    /// Sigla do Terminal de origem do trecho.
    /// </summary>
    [Required]
    [StringLength(3)]
    public string Origem { get; set; }

    /// <summary>
    /// Sigla do Terminal de destino do trecho.
    /// </summary>
    [Required]
    [StringLength(3)]
    public string Destino { get; set; }

    /// <summary>
    /// Valor do trecho.
    /// </summary>
    [Required]
    [Range(1, 999999)]
    public double Valor { get; set; }
}