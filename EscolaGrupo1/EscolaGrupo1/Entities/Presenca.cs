using System.Collections.Generic;

namespace EscolaGrupo1.Entities
{
    public class Presenca
    {
        public string Turma { get; set; }
        public List<string> AlunosPresentes { get; set; }
        public string DataAula { get; set; }
    }
}