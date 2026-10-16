using Clinica.Models;
using Clinica.Service;

var clinica = new ClinicaService();

Console.WriteLine(
    "=== SISTEMA DA CLÍNICA VIDA & SAÚDE ===\n"
);

// ==================================================
// CADASTRO DE PACIENTES
// ==================================================

var paciente1 = new Paciente(
    1,
    "Maria Oliveira",
    "111.222.333-44",
    "(11) 98888-7777",
    new DateTime(1990, 5, 15)
);

var paciente2 = new Paciente(
    2,
    "João Souza",
    "555.666.777-88",
    "(11) 97777-6666",
    new DateTime(1985, 10, 20)
);

clinica.CadastrarPaciente(paciente1);
clinica.CadastrarPaciente(paciente2);

// ==================================================
// CADASTRO DE MÉDICOS
// ==================================================

var medico1 = new Medico(
    1,
    "Helena Rios",
    "123.456.789-00",
    "(11) 91111-2222",
    "CRM/SP 123456",
    "Cardiologia"
);

var medico2 = new Medico(
    2,
    "Roberto Alves",
    "987.654.321-11",
    "(11) 93333-4444",
    "CRM/SP 654321",
    "Ortopedia"
);

clinica.CadastrarMedico(medico1);
clinica.CadastrarMedico(medico2);

// ==================================================
// EXIBIÇÃO DOS CADASTROS
// ==================================================

Console.WriteLine(
    "--- Cadastros Realizados ---"
);

paciente1.ExibirFicha();
medico1.ExibirFicha();

// ==================================================
// AGENDAMENTO DE CONSULTAS
// ==================================================

Console.WriteLine(
    "\n--- Agendamentos ---"
);

clinica.AgendarConsulta(
    101,
    DateTime.Now.AddDays(2),
    1,
    1
);

clinica.AgendarConsulta(
    102,
    DateTime.Now.AddDays(3),
    2,
    2
);

clinica.ExibirRelatorioGeral();

// ==================================================
// CANCELAMENTO DE CONSULTA
// ==================================================

Console.WriteLine(
    "\n--- Cancelamento de Consulta ---"
);

var consultaParaCancelar =
    clinica.Consultas.FirstOrDefault(
        consulta => consulta.Codigo == 101
    );

consultaParaCancelar?.Cancelar();

clinica.ExibirRelatorioGeral();

// ==================================================
// IMPLEMENTAÇÃO DO PROTOTYPE
// ==================================================

Console.WriteLine(
    "\n=== PROTOTYPE: PACOTES DE EXAMES ==="
);

// Cria o gerenciador de protótipos.
var gerenciador =
    new GerenciadorPrototipos();

// Cria o pacote que será usado como modelo.
var checkupCardio =
    new PacoteExame(
        "Check-up Cardiológico",
        "Jejum de 8h e evitar cafeína"
    );

// Adiciona procedimentos ao modelo.
checkupCardio.AdicionarProcedimento(
    new Procedimento(
        "Eletrocardiograma",
        150.00m
    )
);

checkupCardio.AdicionarProcedimento(
    new Procedimento(
        "Ecocardiograma",
        350.00m
    )
);

// Cadastra o pacote no catálogo.
gerenciador.CadastrarPrototipo(
    "CARDIO_PADRAO",
    checkupCardio
);

// Exibe o modelo original.
Console.WriteLine(
    "\n--- Modelo Base ---"
);

checkupCardio.ExibirResumo();

// ==================================================
// TESTE DA CÓPIA PROFUNDA
// ==================================================

Console.WriteLine(
    "\n--- Cópia Profunda ---"
);

var atendimentoCarlos =
    gerenciador.ObterClone(
        "CARDIO_PADRAO"
    );

if (atendimentoCarlos != null)
{
    atendimentoCarlos.NomePaciente =
        "Carlos Eduardo";

    atendimentoCarlos.AdicionarProcedimento(
        new Procedimento(
            "Holter 24h",
            250.00m
        )
    );

    atendimentoCarlos.ExibirResumo();
}

// Confirma que o modelo original não mudou.
Console.WriteLine(
    "\n--- Modelo Original Após o Clone ---"
);

checkupCardio.ExibirResumo();

// ==================================================
// TESTE DA CÓPIA SUPERFICIAL
// ==================================================

Console.WriteLine(
    "\n--- Cópia Superficial ---"
);

var atendimentoAna =
    checkupCardio.ClonarSuperficial();

atendimentoAna.NomePaciente =
    "Ana Maria";

atendimentoAna.AdicionarProcedimento(
    new Procedimento(
        "Glicemia em Jejum",
        30.00m
    )
);

Console.WriteLine(
    "\nAtendimento da Ana:"
);

atendimentoAna.ExibirResumo();

// O modelo original também será alterado.
Console.WriteLine(
    "\nModelo original após cópia superficial:"
);

checkupCardio.ExibirResumo();
