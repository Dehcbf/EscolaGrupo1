﻿using System;

namespace EscolaGrupo1.Services
{
    internal class MenuService
    {
        public static void Iniciar()
        {
            Console.Title = "Lets Code Player";
            Console.Clear();
            Console.WriteLine("Seja bem vindo ou menu\n");

            Console.WriteLine("Digite a opção que você deseja\n");
            Console.WriteLine("1 - ");
            Console.WriteLine("0 - Sair\n");
            Console.Write("Opção: ");

            switch (Console.ReadLine())
            {
                case "1":
                    Console.WriteLine("cadastro aluno");
                    break;

            }
        }
    }
}