using EscolaGrupo1.Utils;
using System;

namespace EscolaGrupo1.Entities
{
    public class Professor : BaseEntity
    {
        public Professor(string nome, string email, string materia, Guid id)
        {
            Nome = nome;
            Email = email;
            Materia = materia;
            Id = id;
            Ativo = true;
        }

        public string Nome { get; set; }
        public string Email { get; set; }
        public string Materia { get; set; }
    }
}