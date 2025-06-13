using RotasViagem.Domain.Exceptions;
using RotasViagem.Domain.Validators;

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

    public Rota( string origem, string destino, decimal valor)
    {
        Origem = origem;
        Destino = destino;
        Valor = valor;
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
