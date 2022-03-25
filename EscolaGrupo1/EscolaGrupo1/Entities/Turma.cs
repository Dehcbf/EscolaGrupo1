using System;
using System.Collections.Generic;
using EscolaGrupo1.Utils;

namespace EscolaGrupo1.Entities
{
    public class Turma : BaseEntity
    {
        public Turma(string nome, List<string> aulas, List<string> alunos)
        {
            Nome = nome;
            Ativo = true;
            Aulas = aulas;
            Alunos = alunos;
        }
        public List<string> Aulas { get; set; }
        public List<string> Alunos { get; set; }
        public string Nome { get; set; }
    }
}