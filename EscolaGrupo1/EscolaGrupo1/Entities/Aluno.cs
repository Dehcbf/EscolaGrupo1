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
    }
}
