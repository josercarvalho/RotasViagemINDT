using RotasViagem.Domain.Validators;

namespace RotasViagem.Domain.Entities
{
    public class Trecho : Base
    {

        public string Origem { get; private set; }
        public string Destino { get; private set; }
        public decimal Valor { get; private set; }

        public Trecho() { }

        public Trecho(string origem, string destino, decimal valor)
        {
            Origem = origem;
            Destino = destino;
            Valor = valor;

            Validate();
        }

        public bool Validate()
            => base.Validate(new TrechoValidator(), this);
    }
}
