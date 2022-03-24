using System;
using EscolaGrupo1.Entities;

namespace EscolaGrupo1.Interfaces.Services
{
    public interface IAulaService
    {
        void Cadastrar();
        void Atualizar();
        Aula BuscarPorId();
        void Deletar();
        void AlocarProfessor();
    }
}