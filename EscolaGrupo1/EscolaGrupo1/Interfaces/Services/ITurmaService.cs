using System;
using System.Collections.Generic;
using EscolaGrupo1.Entities;

namespace EscolaGrupo1.Interfaces.Services
{
    public interface ITurmaService
    {
        void CadastrarTurma(string nomeTurma, List<Guid> IdAula, List<Guid> IdAluno);
        void EditarTurma(string nomeTurma, List<Guid> IdAula, List<Guid> IdAluno, Guid IdTurma);
        void DeletarTurma(Guid IdTurma);
        List<Turma> BuscarTurma();
    }
}