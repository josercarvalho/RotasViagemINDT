using FluentValidation.Results;
using FluentValidation;
using System.Text;

namespace RotasViagem.Domain.Entities;

public abstract class Base
{
    /// <summary>
    /// Identificador único da rota.
    /// </summary>
    public int Id { get; init; }

    internal List<string> _errors;
    public IReadOnlyCollection<string> Errors
    {
        get
        {
            return _errors;
        }
    }

    public abstract bool Validate();
}
