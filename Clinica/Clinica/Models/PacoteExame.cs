using System;
using System.Collections.Generic;
using Clinica.Interfaces;

namespace Clinica.Models
{
    public class PacoteExame :
        ICloneable,
        IPrototipo<PacoteExame>
    {
        public string NomePacote { get; set; }

        public string OrientacoesJejum { get; set; }

        public string NomePaciente { get; set; }

        public List<Procedimento> Procedimentos { get; set; }

        public PacoteExame(
            string nomePacote,
            string orientacoesJejum)
        {
            NomePacote = nomePacote;
            OrientacoesJejum = orientacoesJejum;
            NomePaciente = "NÃO ATRIBUÍDO";
            Procedimentos = new List<Procedimento>();
        }

        public void AdicionarProcedimento(
            Procedimento procedimento)
        {
            Procedimentos.Add(procedimento);
        }

        // ICloneable + MemberwiseClone.
        // A lista ainda precisa ser recriada manualmente.
        public object Clone()
        {
            PacoteExame pacoteClonado =
                (PacoteExame)MemberwiseClone();

            // Cria uma nova lista.
            pacoteClonado.Procedimentos =
                new List<Procedimento>();

            // Clona cada procedimento individualmente.
            foreach (Procedimento procedimento
                     in Procedimentos)
            {
                Procedimento procedimentoClonado =
                    (Procedimento)procedimento.Clone();

                pacoteClonado.Procedimentos.Add(
                    procedimentoClonado
                );
            }

            return pacoteClonado;
        }

        // Interface genérica.
        // Não é necessário fazer cast no código que chamar esse método.
        public PacoteExame Clonar()
        {
            return (PacoteExame)Clone();
        }

        // Mantém a demonstração de cópia superficial.
        public PacoteExame ClonarSuperficial()
        {
            PacoteExame pacoteClonado =
                new PacoteExame(
                    NomePacote,
                    OrientacoesJejum
                );

            pacoteClonado.NomePaciente = NomePaciente;

            // A mesma lista é reutilizada.
            pacoteClonado.Procedimentos =
                Procedimentos;

            return pacoteClonado;
        }

        public void ExibirResumo()
        {
            Console.WriteLine(
                $"\n[PACOTE]: {NomePacote}"
            );

            Console.WriteLine(
                $"Paciente: {NomePaciente}"
            );

            Console.WriteLine(
                $"Orientação: {OrientacoesJejum}"
            );

            Console.WriteLine(
                "Procedimentos inclusos:"
            );

            decimal total = 0;

            foreach (Procedimento procedimento
                     in Procedimentos)
            {
                Console.WriteLine(
                    $" - {procedimento.Nome}: " +
                    $"R$ {procedimento.Valor:F2}"
                );

                total += procedimento.Valor;
            }

            Console.WriteLine(
                $"Total: R$ {total:F2}"
            );
        }
    }
}
