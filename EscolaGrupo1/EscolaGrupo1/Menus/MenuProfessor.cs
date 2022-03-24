using System;
using EscolaGrupo1.Entities;
using EscolaGrupo1.Professores.Service;

namespace EscolaGrupo1.Menus
{
    public class MenuProfessor
    {
        public void Menu() 
        {
            var service = new ProfessorService();

            Console.WriteLine("MENU DE PROFESSOR");
            Console.WriteLine("Escolha uma das opções...");
            Console.WriteLine("1. Visualizar Professores");
            Console.WriteLine("2. Cadastrar Professor");
            Console.WriteLine("3. Atualizar Professor");
            Console.WriteLine("4. Excluir Professor");
            Console.WriteLine("0. Sair");
            Console.Write("Opção: ");
            switch (Console.ReadLine())
            {
                case "1":
                    Console.Title = "Visualização de Professores";
                    var professores = service.ObterTodosProfessores();
                    Console.WriteLine("--------------------------------------------");
                    foreach (var professor in professores)
                    {
                        Console.WriteLine($"Nome do professor: {professor.Nome}");
                        Console.WriteLine($"E-mail do professor: {professor.Email}");
                        Console.WriteLine($"Matéria do professor: {professor.Materia}");
                        Console.WriteLine("--------------------------------------------");
                    }
                    break;
                case "2":
                    Console.Title = "Cadastro de Professores";
                    Console.WriteLine("Insira o nome do professor: ");
                    var nome = Console.ReadLine();
                    Console.WriteLine("Insira o e-mail do professor: ");
                    var email = Console.ReadLine();
                    Console.WriteLine("Insira a matéria do professor: ");
                    var materia = Console.ReadLine();
                    service.CadastrarProfessor(new Professor(nome, email, materia, Guid.NewGuid()));
                    break;
                case "3":
                    Console.Title = "Atualização de Professores";
                    service.AtualizarProfessor();
                    break;
                case "4":
                    Console.Title = "Exclusão de Professores";
                    Console.WriteLine("Insira o e-mail do professor a ser excluído: ");
                    service.ExcluirProfessor(Console.ReadLine());
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
