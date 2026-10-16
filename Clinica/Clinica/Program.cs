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

Console.WriteLine("--- Cadastros Realizados ---");

paciente1.ExibirFicha();
medico1.ExibirFicha();

// ==================================================
// AGENDAMENTO DE CONSULTAS
// ==================================================

Console.WriteLine("\n--- Agendamentos ---");

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
// PROTOTYPE - CRIAÇÃO DO MODELO
// ==================================================

Console.WriteLine(
    "\n=== PROTOTYPE: PACOTES DE EXAMES ==="
);

var gerenciador =
    new GerenciadorPrototipos();

var checkupCardio =
    new PacoteExame(
        "Check-up Cardiológico",
        "Jejum de 8h e evitar cafeína"
    );

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

// Cadastra o pacote original no registro de protótipos.
gerenciador.CadastrarPrototipo(
    "CARDIO_PADRAO",
    checkupCardio
);

Console.WriteLine(
    "\n--- Modelo Original ---"
);

checkupCardio.ExibirResumo();

// ==================================================
// CÓPIA PROFUNDA PELO GERENCIADOR
// ==================================================

Console.WriteLine(
    "\n--- Cópia Profunda pelo Gerenciador ---"
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

Console.WriteLine(
    "\n--- Modelo Após Cópia Profunda ---"
);

checkupCardio.ExibirResumo();

// O modelo original continua com apenas dois exames.

// ==================================================
// TESTE DA INTERFACE ICloneable
// ==================================================

Console.WriteLine(
    "\n--- Teste da Interface ICloneable ---"
);

// O método Clone() retorna object.
// Por isso, é necessário fazer o cast para PacoteExame.
var cloneICloneable =
    (PacoteExame)checkupCardio.Clone();

cloneICloneable.NomePaciente =
    "Paciente ICloneable";

cloneICloneable.AdicionarProcedimento(
    new Procedimento(
        "Exame de Sangue",
        80.00m
    )
);

cloneICloneable.ExibirResumo();

Console.WriteLine(
    "\n--- Modelo Após Teste do ICloneable ---"
);

checkupCardio.ExibirResumo();

// O modelo original não recebe o Exame de Sangue.

// ==================================================
// TESTE DA INTERFACE GENÉRICA IPrototipo<T>
// ==================================================

Console.WriteLine(
    "\n--- Teste da Interface Genérica ---"
);

// O método Clonar() da interface genérica
// já retorna PacoteExame.
// Portanto, não precisamos fazer cast.
PacoteExame cloneGenerico =
    checkupCardio.Clonar();

cloneGenerico.NomePaciente =
    "Paciente Genérico";

cloneGenerico.AdicionarProcedimento(
    new Procedimento(
        "Ultrassonografia",
        200.00m
    )
);

cloneGenerico.ExibirResumo();

Console.WriteLine(
    "\n--- Modelo Após Teste da Interface Genérica ---"
);

checkupCardio.ExibirResumo();

// O modelo original continua intacto.

// ==================================================
// TESTE DA CÓPIA SUPERFICIAL
// ==================================================

Console.WriteLine(
    "\n--- Teste da Cópia Superficial ---"
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
    "\n--- Atendimento da Ana ---"
);

atendimentoAna.ExibirResumo();

Console.WriteLine(
    "\n--- Modelo Após Cópia Superficial ---"
);

checkupCardio.ExibirResumo();

// O exame Glicemia em Jejum também aparecerá no modelo original,
// porque a cópia superficial utiliza a mesma lista.
