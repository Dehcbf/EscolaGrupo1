using System;
using System.Collections.Generic;
using EscolaGrupo1.Entities;

namespace EscolaGrupo1.Interfaces.Repositories
{
    public interface IAulaRepository
    {
        void Cadastrar(Aula aula);
        void Atualizar(Aula aula);
        Aula BuscarPorId(Guid id);
    }
}