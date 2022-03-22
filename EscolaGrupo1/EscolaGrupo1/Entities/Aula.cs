using System;
using EscolaGrupo1.Utils;

namespace EscolaGrupo1.Entities
{
    public class Aula : BaseEntity
    {
        private string NomeMateria { get; set; }
        private Guid ProfessorId { get; set; }

        public Aula(string nomeMateria)
        {
            Id = Guid.NewGuid();
            NomeMateria = nomeMateria;
        }

        public void AlocarProfessor(Guid professorId)
        {
            ProfessorId = professorId;
        }

        public void Atualizar(string nomeMateria)
        {
            NomeMateria = nomeMateria;
        }
    }
}