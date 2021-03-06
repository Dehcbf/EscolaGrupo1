using EscolaGrupo1.Entities;
using EscolaGrupo1.Observer;
using EscolaGrupo1.Services;
using System;

namespace EscolaGrupo1.Menus
{
    public class MenuAluno
    {
        private readonly TurmaService _turmaService;
        private readonly AlunoServer _alunoService;

        public MenuAluno()
        {
            _turmaService = new TurmaService();
            _alunoService = new AlunoServer();
        }

        public void Menu()
        {

            Console.WriteLine("MENU DE AULA");
            Console.WriteLine("Escolha uma das opções...");
            Console.WriteLine("1. Criar Aluno");
            Console.WriteLine("2. Remover Aluno");
            Console.WriteLine("0. Sair");
            Console.Write("Opção: ");
            switch (Console.ReadLine())
            {
                case "1":
                    Console.Title = "Criacao de Aluno";
                    Console.WriteLine($"Forneça o nome do aluno: ");

                    var nomeAlunoA = Console.ReadLine();
                    var alunoA = new Aluno(nomeAlunoA);

                    Console.WriteLine($"Forneça a turma do Aluno: ");

                    var turmasA = _turmaService.GetTurmas();
                    turmasA.ForEach(turma => Console.WriteLine(turma.Nome));
                    var turmaNameA = Console.ReadLine();
                    _alunoService.CadastroAluno(alunoA);

                    var turmaDataA = _turmaService.GetByName(turmaNameA);
                    turmaDataA.InserirAluno(alunoA);
                    _turmaService.AtualizarTurma(turmaDataA);

                    Console.WriteLine($"Turma atualizada com sucesso");
                    break;
                case "2":
                    Console.Title = "Remover de Aluno";
                    Console.WriteLine($"Forneça o nome do aluno: ");

                    var subject = new Subject();
                    var nomeAlunoB = Console.ReadLine();
                    var alunoB = _alunoService.GetByNome(nomeAlunoB);

                    var turmaDataB = _turmaService.GetByAlunoName(alunoB);

                    subject.Attach(turmaDataB);
                    subject.NotifyWithSave(alunoB);

                    _turmaService.AtualizarTurma(turmaDataB);
                    _alunoService.ExcluirAluno(nomeAlunoB);

                    Console.WriteLine($"Turma atualizada com sucesso");

                    break;
                case "0":
                    return;
                default:
                    Console.WriteLine("Opção Inválida, tente novamente...");
                    Console.ReadLine();
                    Menu();
                    break;
            }
            Menu();
        }
    }
}
