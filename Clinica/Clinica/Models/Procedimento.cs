using System;
using Clinica.Interfaces;

namespace Clinica.Models
{
    public class Procedimento :
        ICloneable,
        IPrototipo<Procedimento>
    {
        public string Nome { get; set; }

        public decimal Valor { get; set; }

        public Procedimento(
            string nome,
            decimal valor)
        {
            Nome = nome;
            Valor = valor;
        }

        // Implementação do ICloneable.
        public object Clone()
        {
            return MemberwiseClone();
        }

        // Implementação da interface genérica.
        public Procedimento Clonar()
        {
            return (Procedimento)Clone();
        }
    }
}
