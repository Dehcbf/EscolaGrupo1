using EscolaGrupo1.Utils;
using System.Collections.Generic;

namespace EscolaGrupo1.Entities
{
    public class Professor : BaseEntity
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Materia { get; set; }
        public List<Presenca> Presencas { get; set; }
    }
}