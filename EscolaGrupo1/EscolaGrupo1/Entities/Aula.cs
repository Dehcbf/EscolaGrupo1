using System;
using EscolaGrupo1.Utils;

namespace EscolaGrupo1.Entities
{
    public class Aula : BaseEntity
    {
        public string NomeMateria { get; private set; }
        public Guid ProfessorId { get; set; }

        public Aula(string nomeMateria)
        {
            Id = Guid.NewGuid();
            NomeMateria = nomeMateria;
        }

        public void Atualizar(string nomeMateria)
        {
            NomeMateria = nomeMateria;
        }
    }
}