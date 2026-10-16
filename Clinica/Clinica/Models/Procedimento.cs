using System;

namespace Clinica.Models
{
    public class Procedimento : ICloneable
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

        // Método exigido pela interface ICloneable.
        public object Clone()
        {
            return new Procedimento(
                Nome,
                Valor
            );
        }
    }
}
