using EscolaGrupo1.Utils;

namespace EscolaGrupo1.Entities
{
    public class Nota : BaseEntity
    {
        public string NomeTurma { get; set; }
        public string Materia { get; set; }
        public string Aluno { get; set; }
        public double NotaAluno { get; set; }

        public Nota(string nomeTurma, string materia, string aluno, double notaAluno)
        {
            NomeTurma = nomeTurma;
            Materia = materia;
            Aluno = aluno;
            NotaAluno = notaAluno;
        }
    }
}
