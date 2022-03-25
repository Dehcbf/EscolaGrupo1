using System;
using System.Collections.Generic;
using EscolaGrupo1.Entities;

namespace EscolaGrupo1.Interfaces.Services
{
    public interface IAulaService
    {
        Guid Cadastrar(string nomeMateria);
        void Atualizar(Guid aulaId, string nomeMateria);
        List<Aula> BuscarTodos();
        Aula BuscarPorId(Guid aulaId);
        void Deletar(Guid aulaId);
        void AlocarProfessor(Guid aulaId, Guid professorId);
    }
}