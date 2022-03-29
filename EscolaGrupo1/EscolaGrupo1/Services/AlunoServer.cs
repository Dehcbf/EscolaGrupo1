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

        public void CadastroAluno(Aluno aluno)
        {
            _alunoRepository.Create(aluno);
        }

        public void ExcluirAluno(string nome)
        {
            var aluno = _alunoRepository.GetAll().Find(x => x.Nome == nome);
            aluno.Ativo = false;
            var alunoDeletar = _alunoRepository.GetAll().FindIndex(x => x.Nome == nome);

            _alunoRepository.Delete(alunoDeletar);
            _alunoRepository.Create(aluno);

            Console.WriteLine("Aluno excluído com sucesso");
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

        public Aluno GetByNome(string nomeAluno) => _alunoRepository.GetByName(nomeAluno);
    }
}
