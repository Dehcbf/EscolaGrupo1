using EscolaGrupo1.Services;
using System;

namespace EscolaGrupo1.Menus
{
    public class MenuNota
    {
        public void Menu()
        {
            var notaService = new NotaService();

            Console.WriteLine("MENU DE NOTA");
            Console.WriteLine("Escolha uma das opções...");
            Console.WriteLine("1. Cadastrar nota");
            Console.WriteLine("2. Atualizar nota");
            Console.WriteLine("3. Deletar nota");
            Console.WriteLine("4. Ver notas aluno");
            Console.WriteLine("0. Sair");

            switch (Console.ReadLine())
            {
                case "1":
                    Console.Title = "Cadastro de notas";
                    notaService.CadastrarNota();
                    break;
                case "2":
                    Console.Title = "Atualização de notas";
                    notaService.AtualizarNota();
                    break;
                case "3":
                    Console.Title = "Deletar nota";
                    notaService.DeletarNota();
                    break;
                case "4":
                    Console.Title = "Ver notas";
                    notaService.VerTodasNotasPorAluno();
                    break;
                case "0":
                    return;
                default:
                    Console.WriteLine("Opção Inválida, tente novamente...");
                    Console.ReadLine();
                    Menu();
                    break;
            }
        }
    }
}
