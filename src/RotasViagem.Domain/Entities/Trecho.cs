using RotasViagem.Domain.Exceptions;
using RotasViagem.Domain.Validators;

namespace RotasViagem.Domain.Entities
{
    public class Trecho : Base
    {

        public string Origem { get; private set; }
        public string Destino { get; private set; }
        public decimal Valor { get; private set; }

        protected Trecho() { }

        public Trecho(string origem, string destino, decimal valor)
        {
            Origem = origem;
            Destino = destino;
            Valor = valor;

            Validate();
        }

        public override bool Validate()
        {
            var validator = new TrechoValidator();
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
}
