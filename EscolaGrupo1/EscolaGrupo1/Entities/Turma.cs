using EscolaGrupo1.Observer;
using EscolaGrupo1.Utils;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EscolaGrupo1.Entities
{
    public class Turma : BaseEntity, IObserver
    {
        public Turma(string nome, List<string> aulas, List<Aluno> alunos)
        {
            Nome = nome;
            Ativo = true;
            Aulas = aulas;
            Alunos = alunos;
        }
        public List<string> Aulas { get; set; }
        public List<Aluno> Alunos { get; set; }
        public string Nome { get; set; }

        public void InserirAluno(Aluno newAluno)
        {
            Alunos.Add(newAluno);
        }

        public void RemoveAluno(Aluno aluno)
        {
            Alunos.Remove(aluno);
        }

        public void Update(ISubject subject)
        {
            Console.WriteLine("SISTEMA DE ESCOLA");
            var aluno = (Aluno)subject.GetProcess().First();
            Alunos.Remove(aluno);
        }
    }
}