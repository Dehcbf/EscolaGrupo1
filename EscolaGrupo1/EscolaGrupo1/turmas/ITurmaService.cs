using System;
using System.Collections.Generic;

namespace EscolaGrupo1.turmas
{
    public interface ITurmaService
    {
        void CadastrarTurma(string nomeTurma, List<Guid> IdAula, List<Guid> IdAluno);
        void EditarTurma(string nomeTurma, List<Guid> IdAula, List<Guid> IdAluno, Guid IdTurma);
        void DeletarTurma(Guid IdTurma);
        List<Turma> BuscarTurma();
    }
}