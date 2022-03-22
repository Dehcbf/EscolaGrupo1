using System;
using System.Collections.Generic;
using EscolaGrupo1.Utils;

namespace EscolaGrupo1.turmas
{
    public class Turma : BaseEntity
    {
        public Turma(string nome, List<Guid> aulas, List<Guid> alunos)
        {
            Nome = nome;
            Ativo = true;
            IdAula = aulas;
            IdAluno = alunos;
        }
        public List<Guid> IdAula { get; set; }
        public List<Guid> IdAluno { get; set; }
        public string Nome { get; set; }
    }
}