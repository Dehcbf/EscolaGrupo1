using EscolaGrupo1.Entities;
using EscolaGrupo1.Professores.Service;
using EscolaGrupo1.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscolaGrupo1.Menus
{
    public class MenuAula
    {
        public void Menu()
        {
            var aulaService = new AulaService();
            var professorService = new ProfessorService();
            
            Console.WriteLine("MENU DE AULA");
            Console.WriteLine("Escolha uma das opções...");
            Console.WriteLine("1. Visualizar Aulas");
            Console.WriteLine("2. Cadastrar Aulas");
            Console.WriteLine("3. Atualizar Aulas");
            Console.WriteLine("4. Alocar Professor");
            Console.WriteLine("5. Excluir Aulas");
            Console.WriteLine("0. Sair");
            Console.Write("Opção: ");
            switch (Console.ReadLine())
            {
                case "1":
                    Console.Title = "Visualização de Aulas";
                    var teste = professorService.ObterTodosProfessores();
                    var aulas = aulaService.BuscarTodos();
                    Console.WriteLine("--------------------------------------------");
                    foreach (var aula in aulas)
                    {
                        Console.WriteLine($"Matéria da Aula: {aula.NomeMateria}");
                        var professor = aula.ProfessorId != Guid.Empty ? professorService.ObterTodosProfessores().Find(x => x.Id == aula.ProfessorId).Nome : "Nenhum Professor Alocado a Essa Aula.";
                        Console.WriteLine($"Professor da Aula: {professor}");
                        Console.WriteLine("--------------------------------------------");
                    }
                    break;
                case "2":
                    Console.Title = "Cadastro de Aulas";
                    Console.WriteLine("Insira a matéria da aula: ");
                    var nomeMateria = Console.ReadLine();
                    var returnAulaId = aulaService.Cadastrar(nomeMateria);
                    if(returnAulaId != Guid.Empty)
                        Console.WriteLine($"Id da Aula: {returnAulaId}");
                    break;
                case "3":
                    Console.Title = "Atualização de Aulas";
                    Console.WriteLine("Insira o id da aula que deseja atualizar: ");
                    Guid.TryParse(Console.ReadLine(), out Guid aulaId);
                    Console.WriteLine("Insira a matéria da aula: ");
                    var materia = Console.ReadLine();
                    aulaService.Atualizar(aulaId, materia);
                    break;
                case "4":
                    Console.Title = "Alocação de Professor a Aula";
                    Console.WriteLine("Insira o id da aula que deseja alocar um professor: ");
                    Guid.TryParse(Console.ReadLine(), out Guid resultAulaId);
                    Console.WriteLine("Insira o id do professor a ser alocado: ");
                    Guid.TryParse(Console.ReadLine(), out Guid resultProfessorId);
                    aulaService.AlocarProfessor(resultAulaId, resultProfessorId);
                    break;
                case "5":
                    Console.Title = "Exclusão de Aulas";
                    Console.WriteLine("Insira o id da aula que deseja deletar: ");
                    Guid.TryParse(Console.ReadLine(), out Guid result);
                    aulaService.Deletar(result);
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
