using System;

namespace EscolaGrupo1.Utils
{
    public class BaseEntity
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public bool Ativo { get; set; }
    }
}