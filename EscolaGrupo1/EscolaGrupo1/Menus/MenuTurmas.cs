using System;
using System.Linq;
using EscolaGrupo1.Repositories;
using EscolaGrupo1.Services;

namespace EscolaGrupo1.Menus
{
    public class MenuTurmas
    {
        public void Menu() 
        {
            var service = new TurmaService();
            Console.WriteLine("MENU DAS TURMAS");
            Console.WriteLine("Escolha uma das opções...");
            Console.WriteLine("1. Visualizar Turmas");
            Console.WriteLine("2. Cadastrar Turma");
            Console.WriteLine("3. Atualizar Turma");
            Console.WriteLine("4. Excluir Turma");
            Console.WriteLine("0. Sair");
            Console.Write("Opção: ");
            switch (Console.ReadLine())
            {
                case "1":
                    Console.Title = "Visualização das Turmas";
                    var turmas = service.GetAll();
                    Console.WriteLine("--------------------------------------------");
                    foreach (var turma in turmas)
                    {
                        Console.WriteLine($"Nome da turma: {turma.Nome}");
                        Console.WriteLine();
                        
                        Console.WriteLine($"Alunos: ");
                        foreach (var aluno in turma.Alunos)
                        {
                            Console.WriteLine($"Nome: {aluno}");
                        }
                        Console.WriteLine();
                        
                        Console.WriteLine($"Aulas: ");
                        foreach (var aluno in turma.Aulas)
                        {
                            Console.WriteLine($"Nome da aula: {aluno}");
                        }
                        Console.WriteLine();
                        Console.WriteLine("--------------------------------------------");
                    }
                    break;
                case "2":
                    Console.Title = "Cadastro de Turmas";
                    Console.WriteLine("Insira o nome da turma: ");
                    var nome = Console.ReadLine();
                    Console.WriteLine("Insira o nome das aulas separado por virgula: ");
                    var aulas = Console.ReadLine().Split(",").ToList();
                    Console.WriteLine("Insira os alunos: ");
                    var alunos = new AlunoRepository().GetAll().Where(x => Console.ReadLine().Split(",").ToList().Contains(x.Nome)).ToList();
                    service.CadastrarTurma(nome, aulas, alunos);
                    break;
                case "3":
                    Console.WriteLine("Em manutenção tente mais tarde");
                    break;
                case "4":
                    Console.WriteLine("Em manutenção tente mais tarde");
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
