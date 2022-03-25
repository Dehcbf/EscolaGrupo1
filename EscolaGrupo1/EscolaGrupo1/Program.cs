using System;
using EscolaGrupo1.Menus;

namespace EscolaGrupo1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StartMenu();
        }

        public static void StartMenu()
        {
            Console.Title = "Escola Grupo 1";
            Console.WriteLine("SISTEMA DE ESCOLA");
            Console.WriteLine("Escolha um dos menus a seguir: ");
            Console.WriteLine("1. Menu de Alunos");
            Console.WriteLine("2. Menu de Professores");
            Console.WriteLine("3. Menu de Aulas");
            Console.WriteLine("4. Menu de Notas");
            Console.WriteLine("5. Menu de Turmas");
            Console.WriteLine("0. Sair");
            Console.Write("Opção: ");
            switch (Console.ReadLine())
            {
                case "1":
                    Console.Title = "Menu de Alunos";
                    
                    break;
                case "2":
                    Console.Clear();
                    Console.Title = "Menu de Professores";
                    var menuProfessor = new MenuProfessor();
                    menuProfessor.Menu();
                    break;
                case "3":
                    Console.Clear();
                    Console.Title = "Menu de Aulas";
                    var menuAula = new MenuAula();
                    menuAula.Menu();
                    break;
                case "4":
                    Console.Title = "Menu de Notas";
                    
                    break;
                case "5":
                    Console.Title = "Menu de Turmas";
                    var menuturma = new MenuTurmas();
                    menuturma.Menu();
                    break;
                case "0":
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Opção Inválida, tente novamente...");
                    break;
            }
            StartMenu();
        }
    }
}
