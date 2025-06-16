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

}
