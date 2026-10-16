using System;
using System.Collections.Generic;

namespace Clinica.Models
{
    public class PacoteExame
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

        // CÓPIA PROFUNDA
        public PacoteExame Clonar()
        {
            // Cria um novo pacote na memória.
            PacoteExame pacoteClonado =
                new PacoteExame(
                    NomePacote,
                    OrientacoesJejum
                );

            pacoteClonado.NomePaciente = NomePaciente;

            // Cria novos procedimentos para o novo pacote.
            foreach (Procedimento procedimento
                     in Procedimentos)
            {
                Procedimento procedimentoClonado =
                    procedimento.Clonar();

                pacoteClonado.Procedimentos.Add(
                    procedimentoClonado
                );
            }

            return pacoteClonado;
        }

        // CÓPIA SUPERFICIAL
        public PacoteExame ClonarSuperficial()
        {
            PacoteExame pacoteClonado =
                new PacoteExame(
                    NomePacote,
                    OrientacoesJejum
                );

            pacoteClonado.NomePaciente = NomePaciente;

            // Atenção:
            // Aqui a mesma lista é reutilizada.
            pacoteClonado.Procedimentos = Procedimentos;

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
