using FluentValidation;
using RotasViagem.Domain.Entities;
using System.Collections;

namespace RotasViagem.Domain.Validators;

//internal class RotaViagemValidator : AbstractValidator<RotaViagem>
public class RotaViagemValidator : AbstractValidator<RotaViagem>, IValidator<RotaViagem>, IValidator, IEnumerable<IValidationRule>, IEnumerable
{

    public RotaViagemValidator()
    {
        RuleFor(x => x.Origem)
            .NotEmpty()
                .WithMessage("O campo origem é obrigatório.");

        RuleFor(x => x.Origem)
            .MaximumLength(3)
                .WithMessage("A origem deve conter no máxim 3 caracteres.");

        RuleFor(x => x.Destino)
        .NotEmpty()
            .WithMessage("O campo destino é obrigatório.");

        RuleFor(x => x.Destino)
            .MaximumLength(3)
                .WithMessage("O destino deve conter no máxim 3 caracteres.");

        RuleFor(x => new { x.Origem, x.Destino }).Custom((value, context) =>
        {
            if (value.Origem != null && value.Destino != null
                    && value.Origem.ToLower() == value.Destino.ToLower())
                context.AddFailure("A origem e o Destino devem ser diferentes.");
        });

        RuleFor(x => x.Valor)
        .NotEmpty()
            .WithMessage("O campo valor é obrigatório.");

        RuleFor(x => x.Valor).Custom((value, context) =>
        {
            if (value <= 0)
                context.AddFailure("O valor deve ser maior que zero");
        });
    }

}
