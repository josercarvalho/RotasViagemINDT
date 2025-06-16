namespace RotasViagem.Domain.Entities;

public class Rota : Base
{

    /// <summary>
    /// Código do aeroporto de origem (ex: GRU).
    /// </summary>
    public string Origem { get; private set; }

    /// <summary>
    /// Código do aeroporto de destino (ex: CDG).
    /// </summary>
    public string Destino { get; private set; }

    /// <summary>
    /// Valor (custo) da rota.
    /// </summary>
    public decimal Valor { get; set; }


    protected Rota() { }

    public Rota(string origem, string destino, decimal valor)
    {
        Origem = origem;
        Destino = destino;
        Valor = valor;       
    }

    public void SetOrigem(string origem) { Origem = origem; } 

    public void SetDestino(string destino) { Destino = destino; }

}
