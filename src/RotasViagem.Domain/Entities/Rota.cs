using RotasViagem.Domain.Validators;

namespace RotasViagem.Domain.Entities;

public class Rota : Base
{

    public string Origem { get; private set; }
    public string Conexao { get; private set; }
    public string Destino { get; private set; }
    public decimal Valor { get; private set; }

    public IEnumerable<Rota> Rotas { get; set; }


    protected Rota() { }

    public Rota(Guid id, string conexao, string origem, string destino, decimal valor)
    {
        Id = Guid.NewGuid();
        Origem = origem;
        Destino = destino;
        Valor = valor;
        Conexao = conexao;
        _errors = new List<string>();

        Validate();
    }

    public bool Validate()
        => base.Validate(new RotaValidator(), this);

}
