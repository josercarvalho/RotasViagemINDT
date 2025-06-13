namespace RotasViagem.Services.DTOs;

public class RotaCreateRequest
{
    public required string Origem { get; set; }
    public required string Destino { get; set; }
    public decimal Valor { get; set; } = 0;
}
