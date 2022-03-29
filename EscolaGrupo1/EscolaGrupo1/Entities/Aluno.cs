using EscolaGrupo1.Utils;

namespace EscolaGrupo1.Entities
{
    public class Aluno : BaseEntity
    {
        public Aluno(string nome)
        {
            Nome = nome;
            Ativo = true;
        }

        public string Nome { get; set; }

        public void DesativarAluno()
        {
            Ativo = false;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || obj.GetType() != typeof(Aluno))
                return false;

            var other = obj as Aluno;
            return Nome == other.Nome && Ativo == other.Ativo;
        }
    }
}
