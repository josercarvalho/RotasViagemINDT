using RotasViagem.Domain.Exceptions;
using RotasViagem.Domain.Validators;

namespace RotasViagem.Domain.Entities;

public class Rota : Base
{

    public string Origem { get; private set; }
    public string Destino { get; private set; }
    public decimal Valor { get; private set; }
    public string Conexao { get; private set; }

    public IEnumerable<Rota> Rotas { get; set; }


    protected Rota() { }

    public Rota( string conexao, string origem, string destino, decimal valor)
    {
        Origem = origem;
        Destino = destino;
        Valor = valor;
        Conexao = conexao;
        _errors = new List<string>();

        Validate();
    }

    public override bool Validate()
    {
        var validator = new RotaValidator();
        var validation = validator.Validate(this);

        if (!validation.IsValid)
        {
            foreach (var error in validation.Errors)
                _errors.Add(error.ErrorMessage);

            throw new DomainException("Alguns campos estão inválidos, por favor corrija-os!", _errors);
        }

        return true;
    }

}
