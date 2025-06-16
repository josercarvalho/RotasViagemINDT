using FluentValidation;
using RotasViagem.Services.DTOs;

namespace RotasViagem.Services.Validator;

public class RotaValidator : AbstractValidator<RotaResponse>
{
    public RotaValidator()
    {
        RuleFor(x => x.Origem)
            .NotNull()
            .NotEmpty()
                .WithMessage("O campo origem é obrigatório.");

        RuleFor(x => x.Origem)
            .MaximumLength(3)
                .WithMessage("A origem deve conter no máxim 3 caracteres.");

        RuleFor(x => x.Destino)
            .NotNull()
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
