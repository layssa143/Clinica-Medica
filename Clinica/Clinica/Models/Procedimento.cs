using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinica.Models
{
        public class Procedimento
        {
            public string Nome { get; set; }
            public decimal Valor { get; set; }

            public Procedimento(string nome, decimal valor)
            {
                Nome = nome;
                Valor = valor;
            }

            // Clonagem manual do procedimento.
            // Cria um novo objeto com os mesmos dados.
            public Procedimento Clonar()
            {
                return new Procedimento(Nome, Valor);
            }
        }
    

}
