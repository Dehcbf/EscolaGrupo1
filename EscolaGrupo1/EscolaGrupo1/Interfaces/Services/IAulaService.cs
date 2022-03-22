using System;

namespace EscolaGrupo1.Interfaces.Services
{
    public interface IAulaService
    {
        void Cadastrar(string nomeMateria);
        void Atualizar(Guid id, string nomeMateria);
        void BuscarPorId(Guid id);
        void Deletar(Guid id);
        void AlocarProfessor(Guid aulaId, Guid professorId);
    }
}