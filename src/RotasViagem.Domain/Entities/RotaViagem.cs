using RotasViagem.Domain.Validators;

namespace RotasViagem.Domain.Entities;

public class RotaViagem : Base
{
    
    public string Origem { get; private set; }
    public string Destino { get; private set; }
    public decimal Valor { get; private set; }
    public bool Ativo { get; private set; }

    protected RotaViagem(){}

    public RotaViagem(Guid id, string origem, string destino, decimal valor, bool ativo)
    {
        Id = Guid.NewGuid();
        Origem = origem;
        Destino = destino;
        Valor = valor;
        Ativo = ativo;
        _errors = new List<string>();
        Validate();
    }

    public bool Validate()
        => base.Validate(new RotaViagemValidator(), this);

}
