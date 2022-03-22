using EscolaGrupo1.Entities;
using EscolaGrupo1.Repositories;
using System;
using System.Threading;

namespace EscolaGrupo1.Services
{
    public class AlunoServer
    {
        private AlunoRepository _alunoRepository { get; set; }

        public AlunoServer()
        {
            _alunoRepository = new AlunoRepository();
        }

        public void CadastroAluno()
        {
            Console.Clear();
            Console.WriteLine("Cadastro de Alunoss\n");
            Console.Write("Nome: ");
            var nome = Console.ReadLine();

            while (!ValidacaoDeNome(nome))
            {
                Console.Write("Nome: ");
                nome = Console.ReadLine();
            }
            var aluno = new Aluno(nome);

            _alunoRepository.Create(aluno);
        }

        private static bool ValidacaoDeNome(string nome)
        {
            if (string.IsNullOrWhiteSpace(nome))
            {
                Console.WriteLine("Nome não pode ser vazio!");
                Thread.Sleep(2000);
                Console.Clear();
                return false;
            }

            return true;
        }
    }
}
